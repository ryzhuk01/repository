using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace OOP_Lab4
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

    
}