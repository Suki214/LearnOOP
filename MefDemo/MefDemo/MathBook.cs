using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefDemo
{
    [Export("MathBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }
        public string GetBookName()
        {
            return "MathBook";
        }
    }
}
