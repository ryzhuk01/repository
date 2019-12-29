using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
namespace lab15
{
    class Program
    {
        static int w = 0;
        public static void Print(int n)
        {
            Thread.Sleep(4000);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }


        }

        public static void PrintEvenNumber(int n)
        {

            for (int i = 0; i <= n; i++)
            {

                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }


            }


        }

        public static void PrintUnevenNumber(int n)
        {

            for (int i = 0; i <= n; i++)
            {

                if (i % 2 != 0 || i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
                Thread.Sleep(100);
            }

        }
        private static int x; // Закрытая статическая переменная.
        private static object lockObj = new object();// Закрытый обьект-заглушка для оператора lock.
        static void Main(string[] args)
        {


            foreach (Process i in Process.GetProcesses())
            {
                Console.WriteLine($"Имя процесса : {i.ProcessName} | ID процесса : {i.Id}");
                Console.WriteLine("--------------------------------------------------------------------");

            }

            AppDomain domain = AppDomain.CurrentDomain;

            Console.WriteLine($"Имя домена : {domain.FriendlyName}");

            Console.WriteLine($"Базовый каталог : {domain.BaseDirectory}");

            Console.WriteLine($"Детали конфигурации : {domain.SetupInformation}");

            Assembly[] assemblies = domain.GetAssemblies();

            foreach (Assembly i in assemblies)
            {
                Console.WriteLine(i.GetName());
            }

            AppDomain domen1 = AppDomain.CreateDomain("domen1");

            domen1.ExecuteAssembly(@" C:\Users\Илюшка\source\repos\11\11\bin\Debug\11.exe");

            AppDomain.Unload(domen1);

            //4
            Console.WriteLine("___________________");
            Console.WriteLine("Введите число n :");
            int n = Int32.Parse(Console.ReadLine());
            Thread th1 = new Thread(() => Print(n));


            th1.Start();
           

           

            Console.WriteLine($"Имя потока : {th1.Name}");


            Console.WriteLine($"Приотирет потока : {th1.Priority}");

            Console.WriteLine($"ID потока : {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Текущее состояние потока : {th1.ThreadState}");

            Thread.Sleep(4000);

         

            Console.WriteLine($"Текущее состояние потока : {th1.ThreadState}");


            Thread th2 = new Thread(() => PrintEvenNumber(n));
            th2.Priority = ThreadPriority.Highest;
            
            th2.Start();
            th2.Join();

            Thread th3 = new Thread(() => PrintUnevenNumber(n));

            th3.Start();
            Console.WriteLine("Введите число n :");
            n = Int32.Parse(Console.ReadLine());
            Thread th4 = new Thread(() => sync(n));
            Thread th5 = new Thread(() => sync(n));
            th4.Start();
            th4.Name = "Первый поток";
            th5.Start();
            th5.Name = "Второй поток";
            th4.Priority = ThreadPriority.Lowest;
            th5.Priority = ThreadPriority.Lowest;
            Console.WriteLine("Введите число ch :");
            int ch = Int32.Parse(Console.ReadLine());
            
            TimerCallback tm = new TimerCallback(TimerSec); // метод обратного вызова
            Timer tmr = new Timer(tm, ch, 0, 1000);
         
           Thread.Sleep(ch * 1000);
            tmr.Dispose();
            Console.ReadKey();




        }
        public static void TimerSec(object obj)
        {
            w++;
            int x = (int)obj;
            Console.WriteLine("Таймер: {0}", w);
            if (w == x)
            {
                Console.WriteLine("Время вышло!");

                Console.Beep();

            }
        }
        public static void sync(int n)
        {
          
                for (x = 1; x < n; x++)
                {
                lock (lockObj) // Блокирование объекта потоком.
                {
                   
                    Thread.Sleep(1000);
                    Console.WriteLine(x+ " " + Thread.CurrentThread.Name);
                    
                    
                }
                }
            
        }

    }
    }

