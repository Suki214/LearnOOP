using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.Composition;
using BankInterface;

namespace BankInterface
{
    [MetadataAttribute ]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
    public class ExportCardAttribute : ExportAttribute
    {
        public ExportCardAttribute():base(typeof(ICard))
        {
        }

        public string CardType { get; set; }
    }
}
