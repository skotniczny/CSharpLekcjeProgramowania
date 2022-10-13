namespace MaszynaTuringa2
{
    struct Dwójka : IComparable<Dwójka>
    {
        public char StanGłowicy;
        public char WartośćLubPolecenieNaTaśmie;

        public int CompareTo(Dwójka other)
        {
            int wartosc = StanGłowicy.CompareTo(other.StanGłowicy);
            if (wartosc != 0) return wartosc;
            else return WartośćLubPolecenieNaTaśmie.CompareTo(other.WartośćLubPolecenieNaTaśmie);
        }
    }

    class Turing
    {
    }
}
