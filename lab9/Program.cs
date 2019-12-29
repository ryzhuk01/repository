using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(1, 2, 4);
            user.notify += DisplayMessage;

            User.userAction2param move = user.move;
            move(14, 56);

            User.userAction1param squuze= user.squeeze;
            squuze(3);

            Console.WriteLine("User " +user.getX());
            Console.WriteLine("User "+user.getY());
            Console.WriteLine("User "+user.getCapasity());

            User user1 = new User(2, 3, 4);
            user1.notify += DisplayRedMessage;

            User.userAction2param move1 = user1.move;
            move1(2, 14);

            User.userAction1param squuze1 = user1.squeeze;
            squuze1(2);

            Console.WriteLine("User1 " + user1.getX());
            Console.WriteLine("User1 " + user1.getY());
            Console.WriteLine("User1 " + user1.getCapasity());


            User.userReturn sum = (int x,int y)=> { return x + y; };
            Console.WriteLine(sum(5, 4));

            User.userAction1param show = (double value) => { Console.WriteLine(value); };
            show(3);

            User user2 = new User("my long biggg        meesage!!!"); 
            User.Action1<string> add = user2.add;
            add("222");
           
            User.Action2<int, int> delete = user2.delete;
            delete(0, 3); 
            User.Func<int> size = user2.getLenght;
            Console.WriteLine(size());
            User.Action0 up = user2.toUpper;
            up();
            Console.WriteLine(user2.getStr());


        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static void DisplayRedMessage(string message)
        {
           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
          
            Console.ResetColor();
        }
    }
}
