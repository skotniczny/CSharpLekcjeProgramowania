using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace WariancjaTypówParametrycznych
{
    interface ITypInwariantny<Typ>
    {
        void Nic();
        void PrzyjmijObiekt(Typ typ);
        Typ ZwróćObiekt();
        Typ PrzyjmijIZwróćObiekt(Typ typ);
    }

    interface ITypKontrwariantny<in Typ> // można bezpiecznie tylko przypisać (in){
    {
        void Nic();
        void PrzyjmijObiekt(Typ obiekt);
    }

    interface ITypKowariantny<out Typ> //można bezpiecznie tylko odbierać wartości (out)
    {
        void Nic();
        Typ ZwróćObiekt();
    }

    class TypInwariantny<T> : ITypInwariantny<T>
    {
        public void Nic() { }
        public void PrzyjmijObiekt(T obiekt)
        {
            WriteLine(obiekt.ToString());
        }
        public T ZwróćObiekt()
        {
            return default(T);
        }
        public T PrzyjmijIZwróćObiekt(T obiekt)
        {
            WriteLine(obiekt.ToString());
            return obiekt;
        }
    }

    class TypKontrwariantny<T> : ITypKontrwariantny<T>
    {
        public void Nic() { }
        public void PrzyjmijObiekt(T obiekt)
        {
            WriteLine(obiekt.ToString());
        }
    }

    class TypKowariantny<T> : ITypKowariantny<T>
    {
        public void Nic() { }
        public T ZwróćObiekt()
        {
            return default(T);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ITypInwariantny<object> o11 = new TypInwariantny<object>();
            TypInwariantny<object> o12 = new TypInwariantny<object>();

            ITypInwariantny<string> o13 = new TypInwariantny<string>();
            TypInwariantny<string> o14 = new TypInwariantny<string>();

            //ITypInwariantny<object> 015 = new TypInwariantny<string>(); //błąd kompilacji
            //TypInwariantny<object> 016 = new TypInwariantny<string>(); //błąd kompilacji

            //ITypInwariantny<string> o17 = new TypInwariantny<object>(); //błąd kompilacji
            //TypInwariantny<string> o18 = new TypInwariantny<object>(); //błąd kompilacji

            ITypKontrwariantny<object> o21 = new TypKontrwariantny<object>();
            TypKontrwariantny<object> o22 = new TypKontrwariantny<object>();

            ITypKontrwariantny<string> o23 = new TypKontrwariantny<string>();
            TypKontrwariantny<string> o24 = new TypKontrwariantny<string>();

            //ITypKontrwariantny<object> o25 = new TypKontrwariantny<string>();
            //TypKontrwariantny<object> o26 = new TypKontrwariantny<string>();

            ITypKontrwariantny<string> o27 = new TypKontrwariantny<object>();
            //TypKontrwariantny<string> o28 = new TypKontrwariantny<object>();

            o27.PrzyjmijObiekt("łańcuch");

            ITypKowariantny<object> o31 = new TypKowariantny<object>();
            TypKowariantny<object> o32 = new TypKowariantny<object>();

            ITypKowariantny<string> o33 = new TypKowariantny<string>();
            TypKowariantny<string> o34 = new TypKowariantny<string>();

            ITypKowariantny<object> o35 = new TypKowariantny<string>();
            //TypKowariantny<object> o36 = new TypKowariantny<string>();

            //ITypKowariantny<string> o37 = new TypKowariantny<object>();
            //TypKowariantny<string> o38 = new TypKowariantny<object>();

            object[] tablica = new string[5];

            IEnumerable<object> _tablica = tablica;

            Action<object> a1 = (object o) => { WriteLine(o.ToString()); };
            Action<string> a3 = (string s) => { WriteLine(s); };
            //Action<object> a5 = a3;
            Action<string> a7 = a1;

            Func<object> f1 = () => { return new object(); };
            Func<string> f3 = () => { return "łańcuch"; };
            Func<object> f5 = f3;
            //Func<string> f7 = f1;
        }
    }
}