using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypOgólny2
{
    public class Para<T1,T2> : IComparable<Para<T1,T2>>
        where T1 : IComparable<T1>
        where T2 : IComparable<T2>
    {
        private T1 pierwszy = default(T1);
        private T2 drugi = default(T2);
        public Para(T1 pierwszy, T2 drugi)
        {
            this.pierwszy = pierwszy;
            this.drugi = drugi;
        }
        public override string ToString()
        {
            return pierwszy.ToString() + "\t" + drugi.ToString();
        }

        public int CompareTo(Para<T1,T2> innaPara)
        {
            int wartosc = this.pierwszy.CompareTo(innaPara.pierwszy);
            if (wartosc != 0) return wartosc;
            return this.drugi.CompareTo(innaPara.drugi);
        }
    }
}
