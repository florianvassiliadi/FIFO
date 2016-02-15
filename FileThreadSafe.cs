using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tp4
{
    public class FileThreadSafe<T>
    {
        //Grace à ces locks on s'assure qu'il n'y a  
        //pas d'écritures simultanées dans la file
        private Object _lock;
        //*****************************************
        //*****************************************

        private T[] tab; private int tete, queue;
        public FileThreadSafe(int taille)
        {
            tab = new T[taille]; Init();
            _lock= new Object();
        }
        private int Suivant(int i)
        {
            return (i + 1) % tab.Length;
        }

        private void Init() { tete = queue = -1; }
        public void Enfiler(T element)
        {
            lock (_lock)
            {
                //Si la file est pleine on attend qu'un autre thread defile
                if (Pleine())
                {
                    while (Pleine())
                    {
                        Monitor.Wait(_lock);
                    }
                }
                else if (Vide())
                    tab[queue = tete = 0] = element;
                else
                {
                    tab[queue = Suivant(queue)] = element;
                }
                Monitor.Pulse(_lock);
            }
        }

        public void Defiler()
        {
            lock (_lock)
            {
                //Si la file est vide on attend qu'un autre thread enfile
                if (Vide())
                { 
                    while (Vide())
                    { 
                        Monitor.Wait(_lock);
                    }
                }
                tete = (tete + 1) % tab.Length;
                Monitor.Pulse(_lock);
            }
        }
        public bool Vide()
        {
            bool result = false;
            if (tete == -1)
                result = true;
            return result;
        }
        public bool Pleine()
        {
            bool result = false;
            if (Suivant(queue) == tete)
            {
                result = true;
            }
            return result;
        }
        public int NbElements()
        {
            if (Vide()) return 0; else if (tete <= queue) return queue - tete + 1; else return tab.Length + queue - tete + 1;
        }
        public T Premier()
        {
            return tab[tete];
        }
        public void Afficher()
        {
            Console.WriteLine();
            int i = 0;
            while (i <= tab.Length)
            {
                try
                {

                    Console.Write(" " + tab[i]);
                }
                catch (Exception e) { }
                i++;
            }
        }
    }
}
