using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableDemo
{
    class PeopleEnum : IEnumerator
    {
        private Person[] _person;
        private int index = -1;
        public PeopleEnum(Person[] list)
        {
            _person = list;
        }
        public object Current
        {
            get
            {
                return _person[index];
            }
        }
        public bool MoveNext()
        {
            index++;
            return (index < _person.Length);
        }
        public void Reset()
        {
            index = -1;
        }
    }
}
