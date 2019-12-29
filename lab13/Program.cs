using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab13.observer.impl;
using lab13.file_manager;
using lab13.observer;
using System.Text.RegularExpressions;

namespace lab13
{
    class Program
    {
        private static BeanObservable bean = new BeanObservable();
        private static BeanObserver observer = new BeanObserver();
        private static VIKLogAction info = new VIKLog();

        static void Main(string[] args)
        {
            bean.addObserver(observer);
            //task2();
           // task3();
           // task4();
            //task5a();
           // task5b();
            //task5c();
            task6();

        }

        private static void task6()
        {
            info.findDataInFile(@"D:\лабы\2курс\ооп\laba13\lab13\lab13\information.txt","17:38");
        }

        private static void task5c()
        {
            bean.task5c();
        }

        private static void task5b()
        {
            bean.task5b1();
            bean.task5b2();
            bean.task5b3();
        }

        private static void task5a()
        {
            bean.task5a1();
            bean.task5a2();
            bean.task5a3();
            bean.task5a4();
            bean.task5a5();
        }

        private static void task4()
        {
            bean.task4a();
            bean.task4b();
            bean.task4c();
            bean.task4d();
        }

        private static void task3()
        {
            bean.task3a();
            bean.task3b();
            bean.task3c();
        }

        private static void task2()
        {

            bean.task2a();
            bean.task2b();
            bean.task2c();

        }
    }
}
    
