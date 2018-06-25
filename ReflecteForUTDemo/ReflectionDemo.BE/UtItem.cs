using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflecteForUTDemo
{
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
