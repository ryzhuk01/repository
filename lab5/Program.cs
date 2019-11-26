using System;

namespace ConsoleApp1
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
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

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
            Product product = (Product)obj;
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
        public Furniture() : base()
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

        public cupboard() : base()
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

        public Bed() : base()
        {
            BedType = "NoName Filling";
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

        public Hanger() : base()
        {
            HangerCoast = "price is not set";
        }

        public Hanger(string organization, string product, string manufacturer, string coast) : base(organization, product)
        {
            HangerCoast = coast;
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

            public chair() : base()
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

            public sofa() : base()
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


        class Program
        {
            static void Main(string[] args)
            {
                Product product = new Product("123", "213");
                Furniture tech = new Furniture("456", "789", "456789");
                closet closet1 = new closet();
                IMyInterface myInterface = closet1;
                IAnotherInterface[] arr = new IAnotherInterface[3];
                arr[0] = product;
                arr[1] = tech;
                arr[2] = closet1;

                Console.WriteLine(product.ToString());
                Console.WriteLine(tech.ToString());
                Console.WriteLine(closet1.MyFunc());
                Console.WriteLine(myInterface.MyFunc());
                Console.WriteLine($"myInterface is IMyInterface = {myInterface is IMyInterface}");
                Console.WriteLine($"myInterface is Tabet = {myInterface is closet}");
                foreach (IAnotherInterface x in arr)
                {
                    Print.IAmPrinting(x);
                }
            }
        }
    }
