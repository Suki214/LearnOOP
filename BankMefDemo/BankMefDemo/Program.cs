using BanksInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMefDemo
{
    class Program
    {
        [ImportMany(typeof(ICard))]
        public IEnumerable<ICard> cards { get; set; }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Compose();

            foreach(var c in p.cards)
            {
                Console.WriteLine(c.GetAccountInfo());
            }
            Console.ReadKey();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
