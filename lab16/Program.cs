using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;
namespace ConsoleApp1
{
   
    class Program
    {
        static double result = 0;
        static int[,] resM;
        static double result1 = 1;
        static void Main(string[] args)
        {
            //task1and2();
            // task3();
            //task4();
            // task5();
            //task6();


            //task7();
           // task8();

        }

        private static void task8()
        {
            FactorialAsync();   // вызов асинхронного метода

            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");
        }

        static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Факториал равен {result}");
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial());                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }


        private static void task7()
        {
            Customer []customer = new Customer[5];
            customer[0] = new Customer(true,"Ivan");
            customer[1] = new Customer(true,"Pavel");
            customer[2] = new Customer(true,"Nickita");
            customer[3] = new Customer(true,"Uric");
            customer[4] = new Customer(true,"Zhekichan");

            Provider[] providers = new Provider[3];
            providers[0] = new Provider("first", 100);
            providers[1] = new Provider("second", 500);
            providers[2] = new Provider("third", 1000);

            Storage storage = new Storage(customer);

            ProviderAction providerAction = new ProviderAction(providers,storage);
            CustomerAction customerAction = new CustomerAction(customer, storage);
            Thread myThread1 = new Thread(new ThreadStart(providerAction.start));
            Thread myThread2 = new Thread(new ThreadStart(customerAction.start));
            myThread1.Start();
            myThread2.Start();
            myThread1.Join();
        }


        private static void task6()
        {
            Console.WriteLine("Основной поток запущен");

         
            Parallel.Invoke(MyMeth, MyMeth2);

            Console.WriteLine("Основной поток завершен");
        }
        static void MyMeth()
        {
            Console.WriteLine("MyMeth запущен");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("--> MyMeth Count=" + count);
            }
            Console.WriteLine("MyMeth завершен");
        }
        static void MyMeth2()
        {
            Console.WriteLine("MyMeth2 запущен");
            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("--> MyMeth2 Count=" + count);
            }
            Console.WriteLine("MyMeth2 завершен");
        }


        private static void task5()
        {
            // withFor();
           // withForEach();


        }
        private static void withForEach()
        {
            Stopwatch wt = new Stopwatch();

            wt.Start();
            ParallelLoopResult r = Parallel.ForEach<int>(new List<int>() { 100000, 300000, 500000, 800000 },
                   Factorial1);
            wt.Stop();
            show(wt.Elapsed);

            Stopwatch wt1 = new Stopwatch();
            wt1.Start();
            double result = 1;

            for (int i = 1; i <= 100000; i++)
            {
                result *= i;
            }
            result = 1;

            for (int i = 1; i <= 300000; i++)
            {
                result *= i;
            }
            result = 1;

            for (int i = 1; i <= 500000; i++)
            {
                result *= i;
            }
            result = 1;

            for (int i = 1; i <= 800000; i++)
            {
                result *= i;
            }
            wt1.Stop();
            show(wt1.Elapsed);
        }
        static void Factorial1(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
          
           
        }
        static void withFor()
        {
            Stopwatch wt = new Stopwatch();
            wt.Start();
            Parallel.For(1, 1000000 + 1, Factorial);
            wt.Stop();
            show(wt.Elapsed);
            show("\n________________\n");
            Stopwatch wt1 = new Stopwatch();
            wt1.Start();
            double result = 1;
            for (int y = 1; y <= 1000000; y++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    result *= i;
                }
            }
            wt1.Stop();
            show(wt1.Elapsed);
            //show(result);
            //show(result1);
        }
        static void Factorial(int x)
        {
            for (int i = 1; i <= 10; i++)
            {
                result1*= i;
            }


        }


        private static void task4()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });


            Task task2 = task1.ContinueWith(for4);

            task1.Start();


            task2.Wait();
            Console.WriteLine("Выполняется работа метода task4");
        }
        static void for4(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);
        }


        private static void task3()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task<double> tsk1 = Task<double>.Factory.StartNew(() => task11(token));
            Task<int> tsk2 = Task<int>.Factory.StartNew(() => task12(token));
            Task<int> tsk3 = Task<int>.Factory.StartNew(() => task31());
            Task<double> tsk4 = Task<double>.Factory.StartNew(() => task32(tsk1.Result, tsk2.Result, tsk3.Result));

            show(tsk1.Result);
            show(tsk2.Result);
            show(tsk3.Result);
            show(tsk4.Result);

            tsk1.Dispose();
            tsk2.Dispose();
            tsk3.Dispose();
            tsk4.Dispose();
        }
        private static double task32(double result1, int result2, int result3)
        {
            return result1 + result2 + result3;
        }
        static int task31()
        {
            return 123456;
        }


        private static void task1and2()
        {
            Stopwatch wt = new Stopwatch();
            wt.Start();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task = new Task(() => task11(token));
            Task task01 = new Task(() => task12(token));

            task.Start();
            task01.Start();

            //show(task.Id);
            //show(task.IsCompleted);
            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();

            if (s == "y")
                cancelTokenSource.Cancel();
            task.Wait();
            task01.Wait();

            show(result);
            Print(resM);
            wt.Stop();
            show(wt.Elapsed);
        }
        static double task11(CancellationToken token)
        {

            for (int i = 2; i < 30_000; i++)
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
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана токеном");
                        return result;
                    }
                    result += i;
                }
            }
            return result;
        }
        static int task12(CancellationToken token)
        {
            Random r = new Random();

            int[,] A = new int[10, 10];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {

                    A[i, j] = r.Next(1, 10);
                }
            }

            int[,] B = new int[10, 10];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {

                    B[i, j] = r.Next(1, 10);
                }
            }

            Console.WriteLine("\nМатрица A:");
            Print(A);
            Console.WriteLine("\nМатрица B:");
            Print(B);

            int result = 0;
            if (A.GetLength(1) != B.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] mat = new int[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Операция прервана токеном");
                            return result;
                        }

                        mat[i, j] += A[i, k] * B[k, j];
                        result += mat[i, j];
                    }
                }
            }
            resM = mat;
            return result;

        }



        static void show<T>(T t)
        {
            Console.WriteLine(t);
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

