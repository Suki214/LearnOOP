using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phones = { "029-88401100", "029-88500321" };
            var qingDao = new Address("Shanxi", "shanxi","123456", phones);
            try
            {
                qingDao = new Address("ShanDong", "qingdao", "123t67", phones);
            }
            catch{   }
           Console.WriteLine( qingDao.ToString());
            //string[] b = qingDao.Phones;
            //b[0] = "1111111";
            phones[0] = "0000000";
            Console.WriteLine(qingDao.Phones[0]);
            Console.ReadLine();
        }        
    }


    //public interface IDriver
    //{
    //     void setCar(ICar car); //车辆型号
    //     void drive();
    //}

    //public class Driver:IDriver
    //{
    //    private ICar car;
    //    public void setCar(ICar car)
    //    {   //setter函数注入依赖
    //        this.car = car;
    //    }
    //    public void drive()
    //    {
    //        this.car.run();
    //    }

    //}

    //public interface ICar
    //{
    //    //是汽车就会跑
    //     void run();
    //}


    class Address
    {
        private readonly string province;
        private readonly string city;
        private readonly string zip;
        private readonly string[] phones;

        public Address(string _province, string _city, string _zip, string[] _phones)
        {
            province = _province;
            city = _city;
            CheckZip(_zip);
            zip = _zip;
            //phones = _phones;
            phones = new string[_phones.Length];
            _phones.CopyTo(phones, 0);
            //public void CopyTo(Array array, int index); //copy array from index
        }
        public string Province        {            get { return province; }        }
        public string City        {            get { return city; }        }
        public string Zip        {            get { return zip; }        }
        public string[] Phones
        {
            get
            {
                //return phones; //This is wise copy
                //以上代码得到1111111的输出
                //following is deep copy, the copied b will not effect the original value a
                string[] rtn = new string[phones.Length];
                phones.CopyTo(rtn, 0);
                return rtn;
                //由于b指向了新创建的这个数组对象，而非Address对象a内部的数组对象，
                //所以对b的修改将不再影响到a。再次运行刚才的代码，可以得到029 - 88401100的输出。
            }
        }
        private void CheckZip(string value)
        {
            string pattern = @"\d{6}";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new Exception("Zip code is invalid");
            }
        }
        public override string ToString()
        {
            return String.Format("Province: {0}, City: {1}, Zip: {2}", province, city, zip);
        }
    }
}
