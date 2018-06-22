using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordAttributeDemo
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple =true,Inherited =false)]
   public class RecordAttribute:Attribute
    {
        private string recordType;
        private string author;
        private string memo;
        private DateTime date;

        //构造函数，构造函数的参数在特性中也称为”位置参数“
        //构造函数的参数必须为常量，Type类型，或者是常量数组，不能直接传DateTime类型，需要在构造函数里面做强制类型转换
        public RecordAttribute(string _recordType,string _author,string _date)
        {
            recordType = _recordType;
            author = _author;
            date = Convert.ToDateTime(_date);
        }

        //对于位置参数，通常只提供get访问器
        public string RecordType { get { return recordType; } }
        public string Author { get { return author; } }
        public DateTime Date { get { return date; } }

        //构建一个属性，在特性中也叫”命名参数“
        public string Memo
        {
            get
            {
                return memo;
            }
            set
            {
                memo = value;
            }
        }


    }
}
