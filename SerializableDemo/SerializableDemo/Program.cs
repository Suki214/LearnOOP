using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = new Student() { StudentId = 1, Name = "SX", Age = 18 };
            IFormatter formatter = new BinaryFormatter();
            IFormatter formatter1 = new SoapFormatter();
            XmlSerializer formatter2 = new XmlSerializer(typeof(Student));
            Stream stream = new FileStream("C:/data/studentInfo.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.None);
            formatter.Serialize(stream,me);
            stream.Close();

            Stream destream = new FileStream("C:/data/studentInfo.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            var stillme= (Student)formatter.Deserialize(destream);
            destream.Close();
            Console.WriteLine( stillme.DisplayInfo());
            Console.ReadKey();
        }
    }
}
