using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab11.lab3;

namespace lab11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            task4();
        }

        static void task4()
        {
            List<Team> teams = new List<Team>()
            {

             new Team { Name = "Бавария", Country ="Германия" },
             new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {

              new Player {Name="Месси", Team="Барселона"},
              new Player {Name="Неймар", Team="Барселона"},
              new Player {Name="Роббен", Team="Бавария"}
            };


            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { pl.Name, pl.Team, t.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }

        static void task3()
        {
            string myStr = "my very long     string with some repeating arguments such as daddy yes yes like voleyball bbbbbbaaaaaa bbbbbbbaaaaa";


            int maxA = (from s in myStr.Split(' ')

                            orderby s

                            where s.Contains("d")|| s.Contains("b")
                        from c in s
                            where c=='a'

                            select c).Count();

            show(maxA);
                          

        }
        static void task2()
        {
            Vector[] vectors = new Vector[3];
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = new Vector(new int[] { i-1, i + 1, i + 2 }, 3);
            }
            int have0 = (from v in vectors
                         from a in v.array

                         where a == 0

                         select v).Count();



            show(have0);

            int lowestModule = (from v in vectors
                                from v1 in vectors
                                where Math.Abs(v.sum()) < Math.Abs(v1.sum())
                                select v.sum()).Min();


            show(lowestModule);

            IEnumerable<Vector> masVec = from v in vectors
                                  where v.array.Length == 4
                                  select v;


            show(masVec);

            int maxVec = (from v in vectors
                          select v.sum()).Max();

            show(maxVec);

            Vector firstNegative = (from v in vectors
                                    from a in v.array
                                    where a < 0
                                    select v).First();

            show(firstNegative);

            IEnumerable<Vector> orderedList = from v in vectors
                                              orderby v.array.Length
                                              select v;

            show(orderedList);

        }

        static void task1()
        {
            string[] str = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            IEnumerable<string> len6 = from s in str
                                       where s.Length > 6
                                       select s;

            IEnumerable<string> summer = from s in str
                                         where s.Equals("June") || s.Equals("July") || s.Equals("August")
                                         select s;

            IEnumerable<string> winter = from s in str
                                         where s.Equals("December") || s.Equals("January") || s.Equals("February")
                                         select s;

            IEnumerable<string> order = from s in str
                                        orderby s
                                        select s;

            IEnumerable<string> len5andU = from s in str
                                           where s.Contains("u") && s.Length > 4
                                           select s;

            show(len6);
            show(summer);
            show(winter);
            show(order);
            show(len5andU);
        }
        static void show<T>(T t)
        {
           
           
                Console.WriteLine(t);
            Console.WriteLine("\n___________________________\n");


        } static void show<T>(IEnumerable<T> selectedTeams)
        {
            foreach (T s in selectedTeams)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n___________________________\n");
        }
        static void show<T>(IEnumerable<Vector> selectedTeams)
        {
            foreach (Vector s in selectedTeams)
            {
                Console.WriteLine(s.array.Length);
            }

            Console.WriteLine("\n___________________________\n");
        }
       
    }
}
