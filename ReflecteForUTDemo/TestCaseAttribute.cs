using System;

namespace ReflecteForUTDemo
{
    public class TestCaseAttribute : Attribute, ITestCase
    {
        public object[] Arguments { get; }
    }
}