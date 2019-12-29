using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba14.inherit;
using System.Xml;
using System.Xml.Linq;

namespace laba14
{
    class Program
    {
        static void Main(string[] args)
        {
            task1a();
            task1b();
            task1c();
            task1d();
            task2();
            task3();

            task4();


        }

        private static void task4()
        {
            XDocument xdoc = XDocument.Load("task4.xml");
            foreach (XElement phoneElement in xdoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");

                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Компания: {companyElement.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
            }
        }

        private static void task3()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("task2.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }


            XmlNodeList childnodes1 = xRoot.SelectNodes("//Cat/name");
            foreach (XmlNode n in childnodes1)
                Console.WriteLine(n.InnerText);
        }

        private static void task2()
        {
            List<Cat> cats = new List<Cat>();
            cats.Add(new Cat("Tom"));
            cats.Add(new Cat("Bill"));

            XmlSerializer serializer = new XmlSerializer(cats.GetType());

            using (TextWriter tw = new StreamWriter("task2.xml", false, Encoding.Default))
            {
                serializer.Serialize(tw, cats);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("task2.xml", FileMode.OpenOrCreate))
            {
                List<Cat> newPerson = (List<Cat>)serializer.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Animal p in newPerson)
                {
                    Console.WriteLine("Имя: {0} ", p.name);
                }
            }
        }

        private static void task1d()
        {
            Cat person = new Cat("Tom");
            Console.WriteLine("Объект создан");

            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(Cat));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("task1d.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("task1d.xml", FileMode.OpenOrCreate))
            {
                Cat newPerson = (Cat)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.name}");
            }

        }

        private static void task1c()
        {
            Cat tom = new Cat { Name="tom"};
            string json = JsonSerializer.Serialize<Cat>(tom);
            Console.WriteLine(json);
            Cat restoredAnimal = JsonSerializer.Deserialize<Cat>(json);
            Console.WriteLine(restoredAnimal.Name);
        }

        private static void task1b()
        {
            Animal cat = new Cat("Tom");
            Animal dog = new Dog("Bill");
            Animal[] people = new Animal[] { cat, dog };

            // создаем объект SoapFormatter
            SoapFormatter formatter = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("task1b.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("task1b.txt", FileMode.OpenOrCreate))
            {
                Animal[] newPeople = (Animal[])formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Animal p in newPeople)
                {
                    Console.WriteLine("Имя: {0} ", p.name);
                }
            }
           // Console.ReadLine();
        }

        private static void task1a()
        {
            Animal cat = new Cat("Tom");
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("task1a.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, cat);

                Console.WriteLine("Объект сериализован");
            }


            using (FileStream fs = new FileStream("task1a.txt", FileMode.OpenOrCreate))
            {
                Animal newCat = (Cat)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newCat.name}");
            }
        }
    }
}
