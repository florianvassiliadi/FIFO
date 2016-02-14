using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp4;

namespace tp4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileThreadUnsafe<String> f = new tp4.FileThreadUnsafe<String>(4);
            f.Enfiler("Florian");
            f.Afficher();

            f.Enfiler("Germain");
            f.Afficher();

            f.Enfiler("Alex");
            f.Afficher();

            f.Enfiler("Math");
            f.Afficher();

            f.Defiler();
            f.Afficher();

            f.Defiler();
            f.Afficher();
            //int cpt = 0;
            //while(cpt<100)
            //{
            //    f.Enfiler(cpt);
            //    f.Afficher();
            //    cpt++;
            //    System.Threading.Thread.Sleep(1000);
            //}
        }
        
    }
}
