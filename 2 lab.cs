using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double a4 = 15.7;
            int a = 7;
            char с = 'А';
            float f = 0.5f;
            

            //явное преобор
            int a5 = 11;
 
            byte a6 = (byte)a5;
            byte a7 = Convert.ToByte(a5);
            sbyte a8 = Convert.ToSByte(a5);



            //неявное

            double a9 = a5;
            float a10 = a5;
            long a11 = a5;

            //упаковка
            Int32 x = 5;
            Object o = x;

            // распаковка
            int s9 = (int)o;


            int? xx = null;
            Nullable<int> zz = null;





            string name = "Evgeny";
            Console.WriteLine("My name is {0} ", name);
            Console.WriteLine($"My name is {name}");
            Console.WriteLine("\n compare, contains, substring, insert, replace\n");
            string name1 = "My name is Evgeny";
            string name2 = "Evgeny";
            string str = "123";
            Console.WriteLine(String.Compare(name, name2));
            Console.WriteLine(String.Compare(str, name));
            Console.WriteLine(name1.Contains(name));
            Console.WriteLine(name1.Substring(3));
            Console.WriteLine(name1.Insert(11, "Ryzhuk "));
            Console.WriteLine(name1.Replace("Evgeny" , "John"));



            string s1 = "asd";
            string s2 = "";
            string s3 = null;
            Console.WriteLine("\n is null or empty \n");
            Console.WriteLine(string.IsNullOrEmpty(s1));
            Console.WriteLine(string.IsNullOrEmpty(s2));
            Console.WriteLine(string.IsNullOrEmpty(s3));


            //kортежи


            (int, int) tuple = (5, 3);
            Func(tuple.Item1, tuple.Item2);
            void Func(int l, int p)
            {
                int res = l + p;
                Console.WriteLine($"Sum = {res}");
            }
            

            void checked_t()
            {
                int vr = 1686312345;
                int vs = 343499999;
                int vc = unchecked(vr + vs);
                Console.WriteLine(vc);
            }
            checked_t();

        }
    }
}
