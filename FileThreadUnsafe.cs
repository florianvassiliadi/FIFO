using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp4
{
    public class FileThreadUnsafe<T>
    {
        private T[] tab; private int tete, queue;
        public FileThreadUnsafe(int taille)
        {
            tab = new T[taille]; Init();
        }
        private int Suivant(int i) {
            return (i + 1) % tab.Length;
        }
        
        private void Init() { tete = queue = -1; }
        public void Enfiler(T element) {
            if (Pleine())
                throw new ExceptionFilePleine();
            else if (Vide())
                tab[queue = tete = 0] = element;
            else
            {
                tab[queue = Suivant(queue)] = element;
            }
        }

        public void Defiler()
        {
            if (Vide())
                throw new ExceptionFileVide();
            else if (tete == queue)
                tete = queue = -1;
            else
                tete = tete + 1;
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
            if(Suivant(queue)==tete)
            {
                result = true;
            }
            return result;
        }
        public int NbElements()
        {
            if (Vide()) return 0; else if (tete <= queue) return queue - tete + 1; else return tab.Length + queue - tete + 1;
        }
        //public T Premier()
        //{ // TODO 
        //    T result = new T();
        //    return result;
        //}
        public void Afficher()
        {
            Console.WriteLine();
            int i = tete;
            while(i<=queue)
            {
                int r = i;
                Console.Write(" "+tab[i]);
                i++;
            }
        }
    }
    public class ExceptionFileVide : Exception { }
    public class ExceptionFilePleine : Exception { }
}
