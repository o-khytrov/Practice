using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strings
{
    public class IntFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            String s;
            IFormattable formattable = arg as IFormattable;

            if (formattable == null) s = arg.ToString();
            else s = formattable.ToString(format, formatProvider);
            if (arg.GetType() == typeof(Int32))
                return "<B>" + s + "</B>";
            return s;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "Strasse";
            var s3 = "Strasse";
            var s2 = "Straße";

            Console.WriteLine($"== operator {s1 == s2}");
            Console.WriteLine($"Equals operator {s1.Equals(s2)}");
            Console.WriteLine($"Compare operator {String.Compare(s1, s2, true, new CultureInfo("de-De"))}");
            Console.WriteLine($"Compare operator Ordinal {String.Compare(s1, s2, StringComparison.Ordinal)}");
            var i = 123;
            var provider = new IntFormatter();
            var s = String.Format(provider, "{0}", i);
            Console.WriteLine(s);
            Console.WriteLine(String.IsInterned(s1));
            Console.ReadKey();
        }
    }
}
