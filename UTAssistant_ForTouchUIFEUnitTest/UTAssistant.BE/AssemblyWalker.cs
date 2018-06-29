using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using UTAssistant.BE.Model;

namespace UTAssistant.BE
{
    /// <summary>
    /// must make sure referenced NUnit.Framework dll version is updated to workspace version.
    /// todo: use environment vairable to locate the dll and use it somehow.
    /// </summary>
    public static class AssemblyWalker
    {
        public static UtItem BuildTree( string solutionName, List<string> utAssemblies )
        {
            var root = new UtItem {DisplayName = solutionName};

            foreach( var assemblyString  in utAssemblies )
            {
                root.Children.Add( WalkThroughProject( assemblyString ) );
            }

            return root;
        }

        private static UtItem WalkThroughProject( string assemblyString )
        {
            var projectUtItem = new UtItem();
            projectUtItem.ItemType = ItemType.TestProject;
            Assembly assembly = Assembly.LoadFrom( assemblyString );
            projectUtItem.DisplayName = assembly.GetName().Name;
            Type[] typearr = assembly.GetTypes();

            var typearr1 = typearr[ 0 ].GetCustomAttributes();

            //var allTestClasses = typearr.ToList().Where( t => t.GetCustomAttributes().Any( a => a.GetType() == typeof( TestFixtureAttribute ) ) ).ToList();
            var allTestClasses = typearr.ToList().Where( t => t.GetCustomAttributes().Any( a => a.GetType().ToString ().Equals ("Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute") )).ToList();

            allTestClasses.ForEach( testClass =>
            {
                var testClassItem = new UtItem {DisplayName = testClass.Name, ItemType = ItemType.TestClass, TestClass = testClass};
                var testMethods = WalkThroughTestClass( testClass );
                testMethods.ForEach( x => testClassItem.Children.Add( x ) );
                projectUtItem.Children.Add( testClassItem );
            } );

            return projectUtItem;
        }

        private static List<UtItem> WalkThroughTestClass( Type testClass )
        {
            var testMethods = new List<UtItem>();

            MethodInfo[] methodInfos = testClass.GetMethods();

            //var setupMethod = methodInfos.FirstOrDefault( x => string.Equals( x.Name, "SetUp", StringComparison.CurrentCultureIgnoreCase ) );
            //var tearDownMethod = methodInfos.FirstOrDefault( x => string.Equals( x.Name, "TearDown", StringComparison.CurrentCultureIgnoreCase ) );

            //var setupMethod = methodInfos.FirstOrDefault( x => x.GetCustomAttributes().OfType<SetUpAttribute>().Any() );
            //var tearDownMethod = methodInfos.FirstOrDefault( x => x.GetCustomAttributes().OfType<TearDownAttribute>().Any() );

            foreach( var methodInfo in methodInfos )
            {
                var attributes = methodInfo.GetCustomAttributes();

                var enumerable = attributes as Attribute[] ?? attributes.ToArray();
                bool isTestCaseMethod = enumerable.OfType<TestMethodAttribute>().Any();

                foreach( var attribute in enumerable )
                {
                    var type = attribute.GetType();
                    if(type.ToString().Equals("Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute"))
                    {
                        if( isTestCaseMethod )
                        {
                            continue;
                        }

                        var testMethod = new UtItem
                        {
                            DisplayName = methodInfo.Name,
                            ItemType = ItemType.TestMethod,
                            TestClass = testClass,
                            TestMethod = methodInfo,
                            //SetUpMethod = setupMethod,
                            //TearDownMethod = tearDownMethod
                        };

                        testMethods.Add( testMethod );
                        continue;
                    }

                    if(type.ToString().Equals("Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute"))
                    {
                        var TestMethodAttribute = attribute as TestMethodAttribute;
                        if( TestMethodAttribute == null ) //# To avoid resharper warning
                        {
                            break;
                        }
                        var testCaseMethod = new UtItem
                        {
                            ItemType = ItemType.TestCaseMethod,
                            TestClass = testClass,
                            TestMethod = methodInfo,
                            //SetUpMethod = setupMethod,
                            //TearDownMethod = tearDownMethod
                        };

                        //testCaseMethod.DisplayName = BuildTestCaseMethodDisplayName( methodInfo.Name, TestMethodAttribute );
                        //testCaseMethod.Arguments = TestMethodAttribute.Arguments;

                        testMethods.Add( testCaseMethod );
                    }
                }
            }

            return testMethods;
        }

        //private static string BuildTestCaseMethodDisplayName( string testMethodName, TestMethodAttribute TestMethodAttribute )
        //{
        //    var displayName = string.Format( "{0}({1})",
        //                                     testMethodName,
        //                                     string.Join( ",",
        //                                                  TestMethodAttribute.Arguments.Select( arg =>
        //                                                  {
        //                                                      if( arg is String )
        //                                                      {
        //                                                          return "\"" + arg + "\"";
        //                                                      }
        //                                                      if( arg == null )
        //                                                      {
        //                                                          return "\"" + null + "\"";
        //                                                      }
        //                                                      return "\"" + arg.ToString() + "\"";
        //                                                  } ) ) );

        //    return displayName;
        //}
    }
}