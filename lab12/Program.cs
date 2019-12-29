using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab12.inherit;
using System.Reflection;
using lab12.refl;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {

            Reflection refl = new Reflection();
            Cat cat = new Cat("Vasia", 14);
            //refl.getAllFields(cat);
            //refl.getAllPubMethods(cat);
            //refl.getMethWithCertainParam(cat, "String", "Int32");
            //refl.getInterface(cat);

            //refl.callMeth(cat, "eat");

            refl.saveAllClassInf(cat);
        }

    }
}
