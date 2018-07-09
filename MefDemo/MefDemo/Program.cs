using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MefDemo
{
    class Program
    {

        //[Import("MusicBook")]        
        //public IBookService BookService { get; set; }
        //注意：IEnumerable<T> 中的类型必须和类的导出类型匹配，如类上面标注的是[Exprot(typeof(object))]，
        //那么就必须声明为IEnumerable<object> 才能匹配到导出的类。
        //例如：我们在类上面标注[Export("Book")],我们仅仅指定了契约名，而没有指定类型，那么默认为object，
        //此时还用IEnumerable<IBookService> 就匹配不到。
        [ImportMany("MusicBook")]
        //public IEnumerable<IBookService> BookServices { get; set; }
        public IEnumerable<object> BookServices { get; set; }

        //导入属性，不分public，private
        [ImportMany]
        public List<string> InputStrings { get; set; }

        //导入无参方法
        [Import]
        public Func<string> funcWithoudParm { get; set; }

        //导入有参方法
        [Import]
        public Func<int,string> funcWithParm { get; set; }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.Compose();
            if (p.BookServices != null)
            {
                foreach (var service in p.BookServices)
                {
                    //如果以上定义为object，那么需要类型转换一次
                    IBookService s = service as IBookService;
                    Console.WriteLine(s.GetBookName());
                    //Console.WriteLine(service.GetBookName());
                }

                foreach (string s in p.InputStrings)
                {
                    Console.WriteLine(s);
                }

                //调用无参方法
                if (p.funcWithoudParm != null)
                {
                    Console.WriteLine(p.funcWithoudParm());
                }

                //调用有参方法
                if (p.funcWithParm!=null)
                {
                    Console.WriteLine(p.funcWithParm(300));
                }
            }
            Console.ReadKey();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);

        }
    }
}
