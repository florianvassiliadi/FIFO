﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tp4;

namespace tp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //-I
            #region
            FileThreadUnsafe<String> f = new tp4.FileThreadUnsafe<String>(4);
            ajouter(f, new List<string>(new string[] { "Florian", "Vincent", "Alex", "Math" }));

            retirer(f, 2);

            ajouter(f, new List<string>(new string[] { "Michel", "Ari" }));
            f.Afficher();
            #endregion

            //-II
            #region
            //FileThreadUnsafe<String> f2 = new tp4.FileThreadUnsafe<String>(4);

            //Thread t1 = new Thread(() => ajouter(f2, new List<string>(new string[] { "Florian", "Vincent", "Alex", "Math" })));
            //Thread t2 = new Thread(() => retirer(f2, 2));
            //Thread t3 = new Thread(() => ajouter(f2, new List<string>(new string[] { "Michel", "Ari" })));

            //t1.IsBackground = true;
            //t2.IsBackground = true;
            //t3.IsBackground = true;

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            //f2.Afficher();

            #endregion

            //III/IV
            #region
            //FileThreadSafe<String> f3 = new tp4.FileThreadSafe<String>(4);

            //Thread t1 = new Thread(() => ajouter(f3, new List<string>(new string[] { "Florian", "Vincent", "Alex", "Math" })));
            //Thread t2 = new Thread(() => retirer(f3, 2));
            //Thread t3 = new Thread(() => ajouter(f3, new List<string>(new string[] { "Michel", "Ari" })));

            //t1.IsBackground = true;
            //t2.IsBackground = true;
            //t3.IsBackground = true;

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            //f3.Afficher();
            #endregion

            Console.ReadLine();
        }
        public static void ajouter(FileThreadUnsafe<String> f,List<String> noms)
        {
            foreach(var nom in noms)
            {
                f.Enfiler(nom);
            }
        }
        public static void retirer(FileThreadUnsafe<String> f, int cpt)
        {
            for(int i=0;i<2;i++)
            {
                f.Defiler();
            }
        }
        public static void ajouter(FileThreadSafe<String> f, List<String> noms)
        {
            foreach (var nom in noms)
            {
                f.Enfiler(nom);
            }
        }
        public static void retirer(FileThreadSafe<String> f, int cpt)
        {
            for (int i = 0; i < 2; i++)
            {
                f.Defiler();
            }
        }
    }
}
