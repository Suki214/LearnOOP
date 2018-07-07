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
        [Export(typeof(string))]
        private string _privateMusicBookName = "privateMusicBook";

        [Export(typeof(string))]
        public string _publicMusicBookName = "publicMusicBook";

        public string BookName { get; set; }

        [Export(typeof (Func<string>))]
        public string GetBookName()
        {
            return "MusicBook";
        }

        [Export(typeof(Func<int,string>))]
        public string GetBookPrice(int price)
        {
            return price.ToString();
        }
    }
}
