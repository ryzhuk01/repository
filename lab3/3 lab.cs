using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3
{
    public partial class customer
    {
        public int number, balance;
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        
           public static int count = 0;
        public string surname, name;
        readonly string address;

        public object[] arr;
        public override string ToString()
        {
            return (" Имя :" + name + " номер : " + number+ " баланс :" + balance);
        }
        public override bool Equals(object obj)

        {
            customer tmp = obj as customer;
            if (this.name == tmp.name)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return count + 1;
        }
    }

    public partial class customer
    {
        public  int k = 0;
        public customer(string a, string b, int c, int d, int e, string f)
        {
            Console.WriteLine(" constructor with parametrs");
            name = a;
            surname = b;
            number = c;
            balance = d;
            id = GetHashCode();
            address = f;
            count++;
        }

        public customer()
        {
            Console.WriteLine(" constructor withour parametrs");
            id = 0;
            number = 0;
            balance = 0;
            surname = "";
            name = "";
            address = "";
            count++;
        }
        private customer(int z, int v)
        {
            Console.WriteLine(" constructor");
            id = z;
            balance = v;
        }
        static customer()
        {

            Console.WriteLine(" static construtor; the first customer was created");
        }
      


    }
    public partial class customer
    {

        // зачисление
        public void zachisl(int f)
        {
            balance += f;
            Console.WriteLine("zichisleno {0} , balance = {1}", f, this.balance);

        }
        // списание
        public void spisanie(int k)
        {
            if (this.balance < k)
            {
                Console.WriteLine("nedostatochno sredstv");
            }
            else
            {
                this.balance -= k;

                Console.WriteLine("Spisano {0} , balance = {1}", k, this.balance);
            }
        }

        
    }

    class Cmin
    {
        public static int min(int x, int y)
        {
            int z = (x < y) ? x : y;
            return z;
        }
        public static int minabs(ref int x, ref int y)
        {
            x = (x < 0) ? -x : x; y = (y < 0) ? -y : y;
            int z = (x < y) ? x : y;
            return z;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            customer[] arr = new customer[3];

            arr[0] = new customer("kirill", "naibich", 400, 100, 1, "bereza");
            arr[1] = new customer("sanya", "prudilko", 200, 120, 2, "shchuchin");
            arr[2] = new customer("ilya", "smirnov", 150, 110, 3, "osipovichi");
        


            arr[0].zachisl(100);
            arr[1].spisanie(100);
            int x = 100;
            int x2 = 200;
            foreach (customer a in arr)

                if (a.number > x && a.number < x2)
                    Console.WriteLine(a.ToString());

            int с = -4;
            int b = 2;
            Console.WriteLine("a={0}  b={1}", с, b);
            int k = Cmin.min(с, b);
            Console.WriteLine("a={0}  b={1}", с, b);
            Console.WriteLine("k=" + k);
            k = Cmin.minabs(ref с, ref b);
            Console.WriteLine("a={0}  b={1}", с, b);
            Console.WriteLine("k=" + k);

        }

    }
  

    
} 



