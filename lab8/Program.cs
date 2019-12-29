using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Lab4
{
    interface IMyInterface<T>
    {
        void add(T obj);
        void del(T obj);
        void show();
    }

    public class Owner
    {
        int id;
        public string name;
        public string organization;

        public Owner(ref int counter)
        {
            this.id = counter++;
            this.name = "Ryzhuk Evgeny";
            this.organization = "BSTU";
        }
    }

    public class Set<T> : IMyInterface<T>
    {
        public int counter;
        private char[] str;
        private int length;
        public T[] set;
        public readonly int maxsize;
        public Owner infAboutCreator;
        public Date creationTime;
        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public char[] Str
        {
            get { return this.str; }
            set { this.str = value; }
        }
        public char this[int i]
        {
            get { return str[i]; }
            set { str[i] = value; }
        }

        public class Date
        {
            public DateTime time;
            public Date()
            {
                this.time = DateTime.Now;
            }

        }


        public Set()
        {

            this.counter++;
            this.maxsize = 100;
            this.str = new char[100];
            this.set = new T[maxsize];
            this.length = 0;
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = new Date();
        }
        public Set(string input)
        {
            this.set = new T[maxsize];
            this.counter++;
            this.maxsize = 100;
            this.str = new char[100];
            this.length = 0;
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = new Date();

            for (int i = 0; i < input.Length && i < this.maxsize; i++)
            {
                this.str[i] = input[i];
                this.length++;
            }
        }


        public bool isFull()
        {
            return (counter == maxsize);
        }

        public void add(T elem)
        {
            if (isFull())
            {
                throw new SetIsFull("Set is full!");
            }
            for (int i = 0; i < counter; i++)
            {
                if (set[i].Equals(elem))
                {
                    return;
                }
            }
            set[counter++] = elem;
        }

        public void del(T elem)
        {
            int? c = null;
            for (int i = 0; i < counter; i++)
            {
                if (set[i].Equals(elem))
                {
                    c = i;
                    break;
                }
            }

            if (c == null)
                throw new ElementDoesNotExist("There is no such element!");

            for (int i = (int)c; i < counter - 1; i++)
            {
                set[i] = set[i + 1];
            }
            counter--;
        }

        public void show()
        {
            Console.WriteLine("Elements:");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(set[i]);
            }
            Console.WriteLine();
        }







        

        public static bool operator <(Set<T> var1, Set<T> var2)
        {
            if (var1.length < var2.length)
                return true;
            else
                return false;
        }

        public static bool operator >(Set<T> var1, Set<T> var2)
        {
            if (var1.length > var2.length)
                return true;
            else
                return false;
        }

        public static bool operator ==(Set<T> var1, Set<T> var2)
        {
            if (var1.length == var2.length)
                return true;
            else
                return false;
        }

        public static bool operator !=(Set<T> var1, Set<T> var2)
        {
            if (var1.length != var2.length)
                return true;
            else
                return false;
        }

        public static Set<T> operator +(Set<T> var, int i)
        {

            Set<T> temp = new Set<T>();

            for (int j = 0; j < var.length; j++)
                temp.str[j] = var.str[j];
            temp.length = var.length;

            string tempStr = i.ToString();

            for (int k = temp.length, j = 0; j < tempStr.Length; k++, j++)
            {
                temp.str[k] = tempStr[j];
                temp.length++;
            }

            return temp;
        }
        public static Set<T> operator *(Set<T> var, char c)
        {
            Set<T> temp = new Set<T>();

            for (int i = 0; i < var.length; i++)
                temp.str[i] = c;
            temp.length = var.length;

            return temp;
        }

    }
   

    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Set<string> a = new Set<string>();
                Set<string> b = new Set<string>();
                Console.WriteLine(" владелец:  " + a.infAboutCreator.name + "  организация:  " + a.infAboutCreator.organization + " дата и время создания:  " + a.creationTime.time);


                string writePath = @"D:\zxc\a.txt";
                using (var file = new StreamWriter(writePath, true))
                {

                    file.WriteLine($"Имя : { a.infAboutCreator.name}");
                    file.WriteLine($"Организация : { a.infAboutCreator.organization}");


                }

                using (var file = new StreamReader(writePath))
                {
                    var read = file.ReadToEnd();
                    Console.WriteLine($"Чтение из файла : {read}");
                }
                Console.WriteLine("___________________");
                }




               
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally!");
            }


           
        }
    }
}