using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba15
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
           // task1();
           //task2();
            //task3();

            //task4();
           // task5(4);

        }

        private static void task5(int num)
        {
            Thread myThread1 = new Thread(new ParameterizedThreadStart(launch));
            myThread1.Start(num);
        }
        private static void launch(object amount)
        {
            for(int i=0; i < (int)amount; i++)
            {
                Thread.Sleep(1000);
                boom();
            }
        }

        private static void boom()
        {
            Console.WriteLine("boom");
        }

        private static void task4()
        {
            Thread myThread1 = new Thread(new ThreadStart(even));
            Thread myThread2 = new Thread(new ThreadStart(odd));
            
            myThread1.Start();
           // Thread.Sleep(500);
           // myThread1.Priority=ThreadPriority.Highest;
            myThread2.Start();
            //myThread1.Priority = ThreadPriority.Lowest;

        }

        private static void even()
        {
            for (int i = 1; i < 20; i++)
            {

                lock (locker)
                {
                    Thread.Sleep(10);
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                        savet4(i);
                    }
                }
                
            }

        
        }
        private static void odd()
        {

            for (int i = 1; i < 20; i++)
            {
                lock (locker)
                {
                    Thread.Sleep(10);
                    if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                        savet4(i);
                    }
                }
                
            }
        }
        private static void savet4(int i)
        {
            string wayToFile = @"D:\лабы\2курс\ооп\laba15\laba15\laba15\task4.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(wayToFile, true, System.Text.Encoding.Default))
                {
                         sw.WriteLine(i);
                        
                    
             

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        private static void task3()
        {
           
                    Thread myThread1 = new Thread(new ThreadStart(writeToFile));
                    Thread myThread2 = new Thread(new ThreadStart(writeToConsole));
                    myThread1.Start(); Console.WriteLine(myThread1.Priority);
                    Thread.Sleep(300);
                    myThread2.Start(); Console.WriteLine(myThread2.ThreadState);

           
           
           
}

        private static void task2()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"Inf: {domain.SetupInformation}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
            Console.WriteLine("\n create \n");
           //D:\лабы\2курс\ооп
           AppDomain appDomain = null;
            try
            {
                string path = @"D:\лабы\2курс\ооп\System.Runtime.Serialization.Formatters.Soap.dll";
                byte[] buffer = File.ReadAllBytes(path);

                appDomain = AppDomain.CreateDomain("Test");
                Assembly assm = appDomain.Load(buffer);

                Type[] types = assm.GetTypes();
                foreach (Type type in types)
                {
                    Console.WriteLine(type.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (appDomain != null)
                {

                    AppDomain.Unload(appDomain);
                }
            }



        }

        private static void task1()
        {
            Process process = Process.GetCurrentProcess();

            // выводим id и имя процесса
            Console.WriteLine($"ID: {process.Id} ,  Name: {process.ProcessName} , prior {process.BasePriority}," +
                $" launch time {process.StartTime} , VirtualMemorySize64 {process.VirtualMemorySize64} ,MachineName {process.MachineName}");

        }

        public static void writeToFile()
        {


            string wayToFile = @"D:\лабы\2курс\ооп\laba15\laba15\laba15\task3.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(wayToFile, false, System.Text.Encoding.Default))
                {
                    for (int i = 2; i < 50; i++)
                    {
                        bool access = true;
                        for (int y = 2; y < i; y++)
                        {
                            if (i % y == 0)
                            {
                                access = false;
                            }
                        }
                        if (access)
                        {
                            Console.WriteLine("запись в файл");
                            sw.WriteLine(i);
                        }
                    }


                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void writeToConsole()
        {
            for (int i = 2; i < 50; i++)
            {
                bool access = true;
                for (int y = 2; y < i; y++)
                {
                    if (i % y == 0)
                    {
                        access = false;
                    }
                }
                if (access)
                {
                    Console.WriteLine(i);
                }
            }



        }

    }
}
