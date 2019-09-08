using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_BeginRead
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new FileStream("file.txt", FileMode.Open, FileAccess.Read);
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            IAsyncResult asyncResult = stream.BeginRead(array, 0, array.Length, null, null);
            Console.WriteLine("Чтение файла...");

            stream.EndRead(asyncResult);

            foreach (byte item in array)
            {
                Console.WriteLine(item + " ");
            }

            stream.Close();
        }
    }
}
