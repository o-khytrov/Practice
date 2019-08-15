using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class UserCollection : IEnumerator, IEnumerable
    {
        private string[] ar = new string[] { "John", "Mary", "Bob", "Albert" };

        int position = -1;

        public object Current => ar[position];

        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        public bool MoveNext()
        {
            if (position < ar.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
