using System;
using CalculatorDemo.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ReflecteForUTDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string method = "AddResultTest";
            AddTests add = new AddTests();
            //Type t = typeof(AddTests);
            ////PropertyInfo[] p = t.GetProperty();
            //Console.WriteLine("list all classes and methods that has attribute setup");
            ////Console.WriteLine(t.GetMethod(method));
            //var solution = "TouchUI";
            //var assemblyList = new List<string>
            //{
            //    @"C:\Users\sxu\source\repos\CalculatorDemo\CalculatorDemoTests\bin\Debug\CalculatorDemoTests.dll",
            //};

            //var treeRoot = Program.BuildTree(solution, assemblyList);


            ////foreach (var record in treeRoot)
            ////{
            ////    Console.WriteLine(record.ToString());
            ////    //Console.WriteLine(record.t);
            ////}
            Type ty0 = Type.GetType("System.IO.Stream");
            Type ty = Type.GetType("ReflecteForUTDemo.TestAttribute");//Must contain the namespace, or it returns null

            Type ty1 = typeof(TestAttribute);

            string name = "abc";
            Type ty2 = name.GetType();

            TestAttribute ta = new TestAttribute();
            Type ty3 = ta.GetType();
            Console.WriteLine(ty);

            Console.ReadKey();
        }


        public static UtItem BuildTree(string solutionName, List<string> utAssemblies)
        {
            var root = new UtItem { DisplayName = solutionName };
            foreach(var assemblyString in utAssemblies)
            {
                root.Children.Add(WalkThroughProject(assemblyString));
            }
            return root;
        }

        //assemblyString = CalculatorDemoTests
        static UtItem WalkThroughProject(string assemblyString)
        {
            var projectUtItem = new UtItem();
            projectUtItem.ItemType = ItemType.TestProject;
            Assembly assembly = Assembly.LoadFrom(assemblyString);
            projectUtItem.DisplayName = assembly.GetName().Name;
            Type[] typearr = assembly.GetTypes();

            //var typearr1 = typearr[0].GetCustomAttributes();
            var allTestClasses = typearr.ToList().Where(t => t.GetCustomAttributes().Any(a => a.GetType() == typeof(TestClassAttribute))).ToList();

            allTestClasses.ForEach(testClass =>
            {
                var testClassItem = new UtItem { DisplayName = testClass.Name, ItemType = ItemType.TestClass, TestClass = testClass };
                var testMethods = WalkThroughTestClass(testClass);
                testMethods.ForEach(x => testClassItem.Children.Add(x));
                projectUtItem.Children.Add(testClassItem);
            });

            return projectUtItem;
        }

        private static List<UtItem> WalkThroughTestClass(Type testClass)
        {
            var testMethods = new List<UtItem>();
            MethodInfo[] methodInfos = testClass.GetMethods();

            var setupMethod = methodInfos.FirstOrDefault(x => x.GetCustomAttributes().OfType<TestMethodAttribute>().Any());
            var tearDownMethod = methodInfos.FirstOrDefault(x => x.GetCustomAttributes().OfType<TestMethodAttribute>().Any());

            foreach(var methodInfo in methodInfos)
            {
                var attributes = methodInfo.GetCustomAttributes();

                var enumerable = attributes as Attribute[] ?? attributes.ToArray();
                bool isTestCaseMethod = enumerable.OfType<TestClassAttribute>().Any();

                foreach(var attribute in enumerable)
                {
                    var type = attribute.GetType();
                    if (type == typeof(TestMethodAttribute))
                    {
                        if (isTestCaseMethod)
                        {
                            continue;
                        }

                        var testMethod = new UtItem
                        {
                            DisplayName = methodInfo.Name,
                            ItemType = ItemType.TestMethod,
                            TestClass = testClass,
                            TestMethod = methodInfo,
                            SetUpMethod = setupMethod,
                            TearDownMethod = tearDownMethod
                        };

                        testMethods.Add(testMethod);
                        continue;
                    }

                    if (type == typeof(TestMethodAttribute))
                    {
                        var testCaseAttribute = attribute as TestMethodAttribute;
                        if(testCaseAttribute == null)
                        {
                            break;
                        }
                        var testCaseMethod = new UtItem
                        {
                            ItemType = ItemType.TestCaseMethod,
                            TestClass = testClass,
                            TestMethod = methodInfo,
                            SetUpMethod = setupMethod,
                            TearDownMethod = tearDownMethod
                        };

                        //testCaseMethod.DisplayName = BuildTestCaseMethodDisplayName(methodInfo.Name, testCaseAttribute);
                        //testCaseMethod.Arguments = testCaseAttribute.Arguments;

                        testMethods.Add(testCaseMethod);
                    }
                }
            }
            return testMethods;
        }

        private static string BuildTestCaseMethodDisplayName(string testMethodName, TestCaseAttribute testCaseAttribute)
        {
            var displayName = string.Format("{0}({1})",
                testMethodName,
                string.Join(",",
                testCaseAttribute.Arguments.Select(arg => {
                    if(arg is string)
                    {
                        return "\"" + arg + "\"";
                    }
                    if (arg == null)
                    {
                        return "\"" + null + "\"";

                    }
                    return "\"" + arg.ToString() + "\"";
                })));

            return displayName;
        }
    }

    public enum ItemType
    {
        TestProject,
        TestClass,
        TestMethod,
        TestCaseMethod
    }
    public class UtItem
    {
        public string DisplayName { get; set; }

        public ItemType ItemType { get; set; }

        public Type TestClass { get; set; }

        public MethodInfo TestMethod { get; set; }

        public object[] Arguments { get; set; }

        public MethodInfo SetUpMethod { get; set; }

        public MethodInfo TearDownMethod { get; set; }

        private readonly List<UtItem> myChildren = new List<UtItem>();

        public IList<UtItem> Children
        {
            get
            {
                return myChildren;
            }
        }
    }
}
