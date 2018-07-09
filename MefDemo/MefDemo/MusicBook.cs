using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefDemo
{
    [Export("MusicBook", typeof(IBookService))]
    public class MusicBook : IBookService
    {
        //导出私有属性
        [Export(typeof(string))]
        private string _privateMusicBookName = "privateMusicBook";

        //导出公有有属性
        [Export(typeof(string))]
        public string _publicMusicBookName = "publicMusicBook";

        public string BookName { get; set; }

        //导出无参方法
        [Export(typeof (Func<string>))]
        public string GetBookName()
        {
            return "MusicBook";
        }

        //导出有参方法
        [Export(typeof(Func<int,string>))]
        public string GetBookPrice(int price)
        {
            return price.ToString();
        }
    }
}
