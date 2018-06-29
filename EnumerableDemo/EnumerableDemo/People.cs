using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableDemo
{
    class People : IEnumerable
    {
        private Person[] _people;
        public People(Person[] arrayP)
        {
            _people = new Person[arrayP.Length];
            for(int i = 0; i < arrayP.Length; i++)
            {
                _people[i] = arrayP[i];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }
}
