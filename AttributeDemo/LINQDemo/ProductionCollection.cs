using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class ProductionCollection:IEnumerable<Product>
    {
        private Hashtable table;
        //private List<Product> list = new List<Product>();
        private Product product1;
        private Product product2;
        private Product product3;
        private Product product4;
        private Product product5;
        private Product product6;

        //public ProductionCollection()
        //{
        //    table = new Hashtable();
        //}

        public ProductionCollection(params Product[] array)
        {
            table = new Hashtable();
            foreach(Product item in array)
            {
                this.Add(item);
            }
        }
        //public ProductionCollection(Product product) { }

        public ProductionCollection(Product product, Product product1, Product product2, Product product3, Product product4, Product product5, Product product6) : this(product)
        {
            this.product1 = product1;
            this.product2 = product2;
            this.product3 = product3;
            this.product4 = product4;
            this.product5 = product5;
            this.product6 = product6;
            //table.Add(1, product1);
            //table.Add(2, product2);
            //table.Add(3, product3);
            //table.Add(4, product4);
            //table.Add(5, product5);
            //table.Add(6, product6);

        }
        public int Count => table.Keys.Count;
        public void Add(Product item)
        {
            foreach(string key in table.Keys)
            {
                if (item.Code == key)
                {
                    throw new Exception("There is already a duplicate product");
                }
                table.Add(item.Code ,item);
            }
        }
        //public void Insert(int index, Product item) { }
        //public bool Remove(Product item)
        //{
        //    return true;
        //}
        //public bool RemoveAt(int index)
        //{
        //    return true;
        //}
        //public void Clear()
        //{
        //   table.Clear();
        //}
        public ICollection Keys
        {
            get
            {
                return table.Keys;
            }
        }
        private string GetKey(int index)
        {
            if(index<0 ||index > table.Count)
            {
                throw new Exception("Index out of range");
            }
            string selected = "";
            int i = 0;
            foreach(string key in table.Keys)
            {
                if (i == index)
                {
                    selected = key;
                    break;
                }
                i++;
            }
            return selected;
        }

        public Product this[int index]
        {
            get
            {
                string key = GetKey(index);
                return table[index] as Product;
            }
            set
            {
                string key = GetKey(index);
                table[key] = value;
            }
        }

        private string GetKey(string key)
        {
            foreach (string k in table.Keys)
            {
                if (k == key)
                {
                    return key;
                }
            }
            throw new Exception("There is no such key exists");
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ProductEnumerator(this);
        }

        public Product this[string key]
        {
            get
            {
                string selected = GetKey(key);
                return table[selected] as Product;
            }
            set
            {
                string selected = GetKey(key);
                table.Remove(table[selected]);
                this.Add(value);
            }
        }


        public class ProductEnumerator : IEnumerator<Product>
        {
            private ProductionCollection productionCollection;
            private int index;
            public ProductEnumerator(ProductionCollection productionCollection)
            {
                this.productionCollection = productionCollection;
                index = -1;
            }

            public Product Current => productionCollection[index];

            object IEnumerator.Current => productionCollection[index];

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                index++;
                if (index > productionCollection.Count)
                {
                    return false;
                }
                else { return true; }
            }

            public void Reset()
            {
                index = -1;
            }
        }

    }




    
}
