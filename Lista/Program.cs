namespace Lista
{
    internal class Program
    {
        static void drukujLiczby(IEnumerable<int> liczby)
        {
            foreach (int liczba in liczby)
                Console.Write(liczba + "\t");
            
            Console.WriteLine();
        }

        static T[] przepiszElementyDoTablicy<T>(List<T> lista)
        {
            T[] tablica = new T[lista.Count];
            for (int i = 0; i < lista.Count; ++i)
            {
                tablica[i] = lista[i];
            }
            return tablica;
        }

        static int[] filtrujLiczbyParzyste(int[] liczby)
        {
            List<int> liczbyParzyste = new List<int>();
            foreach (int liczba in liczby)
            {
                if (liczba % 2 == 0)
                    liczbyParzyste.Add(liczba);
            }
            return przepiszElementyDoTablicy(liczbyParzyste);
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] liczby = new int[100];
            for (int i = 0; i < 100; ++i)
            {
                liczby[i] = r.Next(100);
            }
            Console.WriteLine("Wszystkie liczby:");
            drukujLiczby(liczby);
            int[] liczbyParzyste = filtrujLiczbyParzyste(liczby);
            Console.WriteLine("Liczby parzyste:");
            drukujLiczby(liczbyParzyste);
        }
    }
}