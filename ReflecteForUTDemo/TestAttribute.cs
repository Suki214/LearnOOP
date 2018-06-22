using System;

namespace ReflecteForUTDemo
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false,Inherited =false)]
    public class TestAttribute : Attribute
    {
        public TestAttribute() { }

        public string Description { get; set; }

    }
}