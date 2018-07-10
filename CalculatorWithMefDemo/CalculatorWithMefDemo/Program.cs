using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithMefDemo
{
    class Program
    {
        private CompositionContainer container;

        [Import(typeof(ICalculator))]
        public ICalculator calculators;

        private Program()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog( typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"C:\Users\sxu\source\OOPProjects\LearnOOP\CalculatorWithMefDemo\CalculatorWithMefDemo\Extensions"));

            container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(this);
            }
            catch(CompositionException e)
            {
               Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            string s;
            Console.WriteLine("Please enter conmmand, Enter Q to quit");

            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine( p.calculators.Calculator(s));
            }
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbal",'+')]
    class Add : IOperation
    {
        public int Operate(int x, int y)
        {
            return x + y;
        }
    }

    [Export(typeof (IOperation))]
    [ExportMetadata("Symbal",'-')]
    class Subtract : IOperation
    {
        public int Operate(int x, int y)
        {
            return x - y;
        }
    }

    [Export(typeof(ICalculator))]
    class MyCalculator : ICalculator
    {
        [ImportMany]
        public List<Lazy<IOperation, IOperationData>> operations;

        public string Calculator(string input)
        {
            int left;
            int right;
            int fn = FindFirstNonDigit(input);
            if (fn == -1)
            {
                return "Cannot parse this command";
            }
            try
            {
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                //if with this Console.WriteLine in this method, it will raise error for following variable left and right
                //Error: Use of unassigned local variable 'left'
                //Error: Use of unassigned local variable 'right'
                //Console.WriteLine("Cannot parse this command");

                //Need to correct to a return statement:
                //return "Cannot parse this command";
                return "Cannot parse this command";
            }

            char operation = input[fn];

            if (operations != null)
            {
                foreach (Lazy<IOperation,IOperationData> op in operations)
                {
                    if (op.Metadata.Symbal.Equals(operation))
                    {
                        return op.Value.Operate(left, right).ToString();
                    }
                }                
            }
            return "Operation is not found";
        }

        private int FindFirstNonDigit(string input)
        {
            for(int i=0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
