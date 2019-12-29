using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class User
    {
        public delegate void userAction2param(int x, int y);
        public delegate void userAction1param(double value);
        public delegate int userReturn(int x, int y);

        public delegate void actionMessage(string message);
        public event actionMessage notify;

        public delegate void actionRedMessage(string message, double value);
        public event actionRedMessage notifyRed;

        public delegate void Action1<T>( T obj);
        public delegate void Action0();
        public delegate void Action2<T,V>( T obj , V obj2) where T:V;
        public delegate int Func<T>();

        private int x;
        private int y;
        private double capacity;
        private string str;

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public double getCapasity()
        {
            return capacity;
        }

        public string getStr()
        {
            return str;
        }
        public User(int x, int y, double capacity)
        {
            this.x = x;
            this.y = y;
            this.capacity = capacity;
        }

        public User(string str)
        {
            this.str = str;
        }
        public void move(int x, int y)
        {
            this.x = x;
            this.y = y;
            notify?.Invoke("User has been moved");
            notifyRed?.Invoke("User has been moved with redText", x + y);
        }
        public void squeeze(double value)
        {
            capacity /= value;
            notify?.Invoke("User has been squeezed");
            notifyRed?.Invoke("User has been moved with redText", value);
        }

        public void add(string word)
        {
            str += word;
        }

        public void delete(int begin , int end)
        {
            string newStr="";
            for(int i = 0; i < str.Length; i++)
            {
                if (i < begin || i > end)
                {
                    newStr += str[i];
                  

                }
            }
            str = newStr;
        }
        
        public int getLenght()
        {
            return str.Length;
        }

        public void toUpper()
        {
            str=str.ToUpper();
        }
    }
}
