using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Еquality
{
    public struct Profit : IComparable, IComparable<Profit>, IEquatable<Profit>
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public int CompareTo(object obj)
        {
            return CompareTo(obj);
        }

        public int CompareTo(Profit other)
        {
            if (other.Amount == this.Amount)
                return 0;
            if (other.Amount > this.Amount)
                return -1;
            else
                return 1;
        }

        public bool Equals(Profit other)
        {
            return (CompareTo(other) == 0);
        }

        public static bool operator >(Profit p1, Profit p2)
        {

            return (p1.CompareTo(p2) > 0);
        }
        public static bool operator <(Profit p1, Profit p2)
        {

            return ((p1.CompareTo(p2))<0);
        }
        public static bool operator >=(Profit p1, Profit p2)
        {

            return p1.CompareTo(p2)<=0;
        }
        public static bool operator <=(Profit p1, Profit p2)
        {

            return p1.CompareTo(p2)>=0;
        }

        public static bool operator ==(Profit p1, Profit p2)
        {

            return (p1.CompareTo(p2)==0);
        }
        public static bool operator !=(Profit p1, Profit p2)
        {

            return (p1.CompareTo(p2) != 0);
        }
    }
}
