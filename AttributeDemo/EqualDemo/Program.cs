using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new KeyData() { Data = 1 };
            //var b = new KeyData() { Data = 1 };
            //var c = new KeyData() { Data = 2 };
            //Console.WriteLine("a.Equals(b) is  {0}", a.Equals(b));//without override Equals, it returns false
            //Console.WriteLine("a.Equals(c) is  {0}", a.Equals(c));
            //Console.WriteLine("a.hashcode {0}", a.GetHashCode());
            //Console.WriteLine("b.hashcode {0}", b.GetHashCode());
            //Console.WriteLine("c.hashcode {0}", c.GetHashCode());
            //Console.WriteLine("c.hashcode {0}", c.GetHashCode());

            //var va = new KeyValue() { Data = 1 };
            //var vb = new KeyValue() { Data = 1 };
            //var vc = new KeyValue() { Data = 2 };
            //Console.WriteLine("va = vb is  {0}", va!=vb);//without declare == and !=, there will be compile error like following:
            //Console.WriteLine("va = vc is  {0}", va==vc);//Operator '!=' cannot be applied to operands of type 'KeyValue' and 'KeyValue'
            //Console.WriteLine("va.hashcode {0}", va.GetHashCode());
            //Console.WriteLine("vb.hashcode {0}", vb.GetHashCode());
            //Console.WriteLine("vc.hashcode {0}", vc.GetHashCode());


            HashCodeValue hashCodeValue = new HashCodeValue();

            //if (hashCodeValue.TestHashCode())
            //{
            //    Console.WriteLine("same");
            //}
            //else
            //{
            //    Console.WriteLine("Diff");
            //}

            Console.WriteLine((hashCodeValue.GetHashCode()==hashCodeValue.Number.GetHashCode()).ToString());

            Console.ReadKey();
        }

        //此Equals取决于== 和object.Equals()
        //public static bool Equals(object left, object right)
        //{            
        //    if (left == right)
        //        return true;
        //    if ((left == null) || (right == null))
        //        return false;
        //    return left.Equals(right);
        //}

    }

    public class KeyData
    {
        private int nData;
        public int Data
        {
            get { return nData; }
            set { nData = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            KeyData keyData = obj as KeyData;
            return this.Data == keyData.Data;
        }
    }

    public struct KeyValue
    {
        private int nData;
        public int Data
        {
            get { return nData; }
            set { nData = value; }
        }

        public static bool operator ==(KeyValue left, KeyValue right)
        {
            return left.Data == right.Data;
        }

        public static bool operator !=(KeyValue left, KeyValue right)
        {
            return left.Data != right.Data;
        }
    }


    public struct HashCodeValue
    {
        private int number;//todo
        private readonly DateTime datetime;
        

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public HashCodeValue(int _number)
        {
            number = _number;
            datetime = DateTime.Now;
        }

        public bool TestHashCode()
        {
            Console.WriteLine(this.GetHashCode());
            Console.WriteLine(number.GetHashCode());
            return this.GetHashCode() == number.GetHashCode();
        }
    }


}
