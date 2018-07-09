using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefProfoundDemo
{
    class Program
    {
        [ImportMany(AllowRecomposition =true)]
        public IEnumerable<Lazy<ICard,IMetaData>> Cards { get; set; }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Compose();

            if(p.Cards != null)
            {
                foreach(var c in p.Cards)
                {
                    if (c.Metadata.CardType == "BankOFChina")
                    {
                        Console.WriteLine("There is a china bank card");
                        Console.WriteLine(c.Value.GetCardInfo());
                    }

                    if (c.Metadata.CardType == "BankOfNY")
                    {
                        Console.WriteLine("There is a china NY Bank card");
                        Console.WriteLine(c.Value.GetCardInfo());
                    }
                }
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
