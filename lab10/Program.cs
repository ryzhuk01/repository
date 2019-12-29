using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace lab10
    {
        interface IMyInterface
        {
            string MyFunc();
        }

        interface IAnotherInterface
        {
            string ToString();
        }

        class Product : IAnotherInterface
        {
            public string OrganizationName;
            public string ProductName;

            public Product()
            {
                OrganizationName = "NoName organization";
                ProductName = "NoName product";
            }

            public Product(string organization, string product)
            {
                OrganizationName = organization;
                ProductName = product;
            }

            public override bool Equals(object obj)
            {
                Product product = obj as Product;
                return ((this.OrganizationName == product.OrganizationName) && (this.ProductName == product.ProductName));
            }

            public override int GetHashCode()
            {
                return this.OrganizationName.GetHashCode() + this.ProductName.GetHashCode();
            }

            public override string ToString()
            {
                return this.OrganizationName + " " + this.ProductName;
            }
        }

        class Furniture : Product, IAnotherInterface
        {


            public string FurnitureType { get; set; }
            public Furniture()
            {
                FurnitureType = "NoName FurnitureType";
            }

            public Furniture(string organization, string product, string furnituretype) : base(organization, product)
            {
                FurnitureType = furnituretype;
            }

            public override string ToString()
            {
                return base.ToString() + " " + this.FurnitureType;
            }
        }

        abstract class cupboard : Furniture, IAnotherInterface
        {
            public string name { get; set; }



            public override string ToString()
            {
                return base.ToString() + " " + this.name;
            }

            public cupboard()
            {
                name = "NoName cupboard";
            }

            public cupboard(string organization, string product, string SweetsType, string Name) : base(organization, product, SweetsType)
            {
                name = Name;
            }

            public abstract string MyFunc();
        }

        sealed class Bed : Furniture, IAnotherInterface
        {
            public string BedType { get; set; }

            public override string ToString()
            {
                return base.ToString() + " " + this.BedType;
            }

            public Bed()
            {
                BedType = "NoName bed";
            }

            public Bed(string organization, string product, string manufacturer, string bedtype) : base(organization, product, manufacturer)
            {
                BedType = bedtype;
            }
        }

        class Hanger : Product, IAnotherInterface
        {
            public string HangerCoast { get; set; }

            public override string ToString()
            {
                return base.ToString() + " " + this.HangerCoast;
            }

            public Hanger()
            {
                HangerCoast = "price is not set";
            }

            public Hanger(string organization, string product, string manufacturer, string coast) : base(organization, product)
            {
                HangerCoast = coast;
            }
        }


    class cupboard1 : cupboard, IMyInterface, IAnotherInterface
    {
        static int count = 0;
        public string Resolution { get; set; }

        public cupboard1()
        {
            ProductName = "cupboard1 " + (count++);
        }

        ~cupboard1()
        {
            count--;
        }

        public override string MyFunc()
        {
            return "Переопределение";
        }
        string IMyInterface.MyFunc()
        {
            return "Реализация метода интерфейса";
        }

        public override string ToString()
        {
            return this.ProductName;
        }
    }




    class closet : cupboard, IMyInterface, IAnotherInterface
        {
            public string Resolution { get; set; }
            public override string MyFunc()
            {
                return "Переопределение";
            }
            string IMyInterface.MyFunc()
            {
                return "Реализация метода интерфейса";
            }

            public override string ToString()
            {
                return base.ToString() + " " + this.Resolution;
            }
        }



        class chair : Furniture, IAnotherInterface
        {
            public string ChairType { get; set; }

            public override string ToString()
            {
                return base.ToString() + " " + this.ChairType;
            }

            public chair()
            {
                ChairType = "NoType";
            }

            public chair(string organization, string product, string manufacturer, string chairtype) : base(organization, product, manufacturer)
            {
                ChairType = chairtype;
            }
        }
        class sofa : Furniture, IAnotherInterface
        {
            public string SofaType { get; set; }

            public override string ToString()
            {
                return base.ToString() + " " + this.SofaType;
            }

            public sofa()
            {
                SofaType = "NoType";
            }

            public sofa(string organization, string product, string manufacturer, string sofatype) : base(organization, product, manufacturer)
            {
                SofaType = sofatype;
            }
        }

        class Print
        {
            public static void IAmPrinting(IAnotherInterface obj)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    static class StaticClass
    {
        public static void method(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Student student = new Student("name", "2");
            Dictionary<double, double> dictionary = new Dictionary<double, double>();
            Dictionary<double, cupboard1> TabletDictionary = new Dictionary<double, cupboard1>();
            Queue<double> queue = new Queue<double>();
            Queue<cupboard1> TabletQueue = new Queue<cupboard1>();
            cupboard1[] arr = new cupboard1[5];
            ObservableCollection<cupboard1> tablets = new ObservableCollection<cupboard1>();
            tablets.CollectionChanged += StaticClass.method;

            ArrayList list = new ArrayList(10)
            {
                10, 20, 30, 40, 50
            };
            list.Add("string");
            list.Add(student);
            list.RemoveAt(2);
            Console.WriteLine($"Nubmer of elements: {list.Count}");
            foreach (object x in list)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine($"List contains 30 = {list.Contains(30)}");
            Console.WriteLine();

            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());
            dictionary.Add(random.NextDouble(), random.NextDouble());

            foreach (KeyValuePair<double, double> x in dictionary)
            {
                Console.WriteLine(x);
                queue.Enqueue(x.Value);
            }
            Console.WriteLine();

            foreach (double x in queue)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new cupboard1();
                TabletDictionary.Add(arr[i].GetHashCode(), arr[i]);
            }
            Console.WriteLine();

            foreach (KeyValuePair<double, cupboard1> x in TabletDictionary)
            {
                Console.WriteLine(x);
                TabletQueue.Enqueue(x.Value);
            }
            Console.WriteLine();

            foreach (cupboard1 x in TabletQueue)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            foreach (cupboard1 x in arr)
            {
                tablets.Add(x);
            }
            tablets.RemoveAt(3);
        }
    }
}