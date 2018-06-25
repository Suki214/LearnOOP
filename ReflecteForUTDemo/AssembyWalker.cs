using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflecteForUTDemo
{
    public static class AssemblyWalker
    {
        public static UtItem BuildTree(string solutionName, List<string> utAssemblies)
        {
            var root = new UtItem { DisplayName = solutionName };
            foreach (var assemblyString in utAssemblies)
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
            var allTestClasses = typearr.ToList().Where(t => t.GetCustomAttributes().Any(a => a.GetType().ToString().Equals("Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute"))).ToList();

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

            foreach (var methodInfo in methodInfos)
            {
                var attributes = methodInfo.GetCustomAttributes();

                var enumerable = attributes as Attribute[] ?? attributes.ToArray();
                bool isTestCaseMethod = enumerable.OfType<TestClassAttribute>().Any();

                foreach (var attribute in enumerable)
                {
                    var type = attribute.GetType();
                    if (type.ToString().Equals("Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute"))
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
                            TestMethod = methodInfo
                        };

                        testMethods.Add(testMethod);
                        continue;
                    }                   
                }
            }
            return testMethods;
        }
    }
}
