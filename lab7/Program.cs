using System;

namespace lab6
{
    interface IMyInterface
    {
        string MyFunc();
    }

    interface IAnotherInterface
    {
        string ToString();
    }

    public partial class Product : Base, IAnotherInterface
    {
        public string OrganizationName { get; set; }
        public string ProductName { get; set; }

        public Product()
        {
            OrganizationName = "NoName organization";
            ProductName = "NoName product";
        }

        public Product(string organization, string product, int price, int mas)
        {
            OrganizationName = organization;
            ProductName = product;
            info.price = price;
            info.mas = mas;
        }


    }

    class Furniture : Product, IAnotherInterface
    {
        public string FurnitureType { get; set; }
        public Furniture() : base()
        {
            FurnitureType = "NoName FurnitureType";
        }

        public Furniture(string organization, string product, string furnituretype, int price, int mas) : base(organization, product, price, mas)
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

        public cupboard(string organization, string product, string SweetsType, string Name, int price, int mas) : base(organization, product, SweetsType, price, mas)
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

        public Bed(string organization, string product, string manufacturer, string bedtype, int price, int mas) : base(organization, product, manufacturer, price, mas)
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

        public Hanger(string organization, string product, string manufacturer, string coast, int price, int mas) : base(organization, product, price, mas)
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

        public chair(string organization, string product, string manufacturer, string chairtype, int price, int mas) : base(organization, product, manufacturer, price, mas)
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

        public sofa(string organization, string product, string manufacturer, string sofatype, int price, int mas) : base(organization, product, manufacturer, price, mas)
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
            Product product = new Product("org1", "prod1", 200, 700);
            Furniture furn = new Furniture("org2", "prod2", "furniture1", 600, 2000);
            closet closet1 = new closet();
            warehouse warehouse1 = new warehouse(10);
            closet1.info.price = 300;
            closet1.info.mas = 3000;
            IAnotherInterface[] arr = new IAnotherInterface[3];
            arr[0] = product;
            arr[1] = furn;
            arr[2] = closet1;

            try
            {
                warehouse WrongLab = new warehouse(100);
                //WrongLab.Del(closet1);
                //arr[4].ToString();
                warehouse1.Add(product);
                warehouse1.Add(furn);
                warehouse1.Add(closet1);
                warehouse1.Add(new Furniture("org2", "prod4", "furniture2", 1000, 1500));
                warehouse1.Add(new Product("org1", "prod5", 400, 200));

                warehouse1.show();

                controller.sort(warehouse1);
                warehouse1.show();
                warehouse1.Del(closet1);
                warehouse1.show();
                Console.WriteLine("asdasdasdsadasdasd");
                warehouse1.sortByMas(700);
                //WrongLab.Del(scanner);

            }
            catch (LabIsFull ex)
            {
                Console.WriteLine("WarehouseIsFull Exception");
                Console.WriteLine(ex.Message);
            }
            catch (ElementDoesNotExist ex)
            {
                Console.WriteLine("ElementDoesNotExist Exception");
                Console.WriteLine(ex.Message);
            }
            catch (LabIsEmpty ex)
            {
                Console.WriteLine("WarehouseIsEmpty Exception");
                Console.WriteLine(ex.Message);
            }
            catch (WrongSize ex)
            {
                Console.WriteLine("WrongSize Exception");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Another Exception");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
