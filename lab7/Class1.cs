using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    partial class Product
    {
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
    enum list
    {
        one = 1,
        two,
        three,
        nine = 9,
        ten
    }
    public class warehouse
    {

        public Base[] elems;
        public int count = 0;
        public int size;
        list list = new list();
        public warehouse()
        {
            size = 100;
            elems = new Base[100];
        }


        public warehouse(int c)
        {
            if (c <= 0)
                throw new WrongSize("Wrong size for warehouse!");
            size = c;
            elems = new Base[c];
        }


        public bool isFull()
        {

            return (count == size);
        }

        public bool isEmpty()
        {
            return (count == 0);
        }


        public void Add(Base el)
        {
            if (isFull())
                throw new LabIsFull("Warehouse is full!"); ;
            elems[count++] = el;
        }


        public void Del(Base el)
        {
            int num = 0;
            if (isEmpty())
                throw new LabIsEmpty("Warehouse is empty!"); 
            for (int i = 0; i < count; i++)
            {
                if (elems[i].Equals(el))
                    num = i;
            }
            if (num == null)
            {
                throw new ElementDoesNotExist("There is no element!");
            }
            for (int i = num; i < count; i++)
            {
                elems[i] = elems[i + 1];
            }
            count--;
        }


        public void sortByMas(int mass)
        {

            for (int i = 0; i < count - 1; i++)
            {
                if (elems[i].info.mas == mass)
                {
                    Console.WriteLine(elems[i].ToString());
                }

            }
        }



        public void show()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(elems[i].ToString());
            }
            Console.WriteLine();
        }

    }



    public abstract class Base
    {
        public struct Info
        {

            public int price;
            public int mas;
        }
        public Info info = new Info();
    }


    public static class controller
    {


        public static void sort(warehouse warehouse)
        {
            Base elem;
            for (int i = 0; i < warehouse.count - 1; i++)
            {
                for (int j = 0; j < warehouse.count - i - 1; j++)
                {
                    if ((warehouse.elems[j].info.mas) / (warehouse.elems[j].info.price) < (warehouse.elems[j + 1].info.mas) / (warehouse.elems[j + 1].info.price))
                    {
                        elem = warehouse.elems[j];
                        warehouse.elems[j] = warehouse.elems[j + 1];
                        warehouse.elems[j + 1] = elem;
                    }
                }
            }
        }
    }
}