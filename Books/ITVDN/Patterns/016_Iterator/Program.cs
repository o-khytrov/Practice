using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_Iterator
{
    //Также известен как курсор 
    //Представляет удобный и безопасный способ доступа к элементам коллекции (составного объекта), при этом не расскрывая внутреннего 
    //представления этой коллекции

    class Bank : IEnumerable
    {
        List<Baknote> bankVaul = new List<Baknote>
        {
            new Baknote(),new Baknote(),new Baknote(),new Baknote()
        };

        public Baknote this[int index]
        {
            get { return bankVaul[index]; }
            set { bankVaul[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return new Cashier(this);
        }
        public int Count { get { return bankVaul.Count; } }
    }

    internal class Cashier : IEnumerator
    {
        private Bank bank;

        public Cashier(Bank bank)
        {
            this.bank = bank;
        }

        private int current = -1;

        public object Current => bank[current];

        public bool MoveNext()
        {
            if (current < bank.Count-1)
            {
                current++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            current = -1;
        }
    }

    internal class Baknote
    {
        public string Nominal = "100 $";
    }
    class Program
    {

        static void Main(string[] args)
        {
            var bank = new Bank();
            foreach (Baknote banknote in bank)
            {
                Console.WriteLine(banknote.Nominal);
            }

            Console.ReadKey();
        }
    }
}

