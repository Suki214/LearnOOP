using System;
using CalculatorDemo.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace ReflecteForUTDemo
{
   public class Program
    {
        static void Main(string[] args)
        {
            AddTests add = new AddTests();
            Type t = typeof(AddTests);
            Console.WriteLine("list all classes and methods that has attribute setup");

            var solution = "ReflectionDemo";
            var assemblyList = new List<string>
            {
                @"C:\Users\sxu\source\repos\CalculatorDemo\CalculatorDemoTests\bin\Debug\CalculatorDemoTests.dll",
            };

            var treeRoot = AssemblyWalker.BuildTree(solution, assemblyList);
            Console.ReadKey();
        }

        public UtItem GetTree()
        {
            var solution = "ReflectionDemo";
            var assemblyList = new List<string>
            {
                @"C:\Users\sxu\source\repos\CalculatorDemo\CalculatorDemoTests\bin\Debug\CalculatorDemoTests.dll",
            };
            return AssemblyWalker.BuildTree(solution, assemblyList);
        }        
    }      
}
