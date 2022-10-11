using Helion;

namespace UłamekTestyJednostkowe
{
    [TestClass]
    public class UłamekTesty
    {
        [TestMethod]
        public void TestKonstruktoraIWłasności()
        {
            //przygotowania (arrange)
            int licznik = 1;
            int mianownik = 2;

            //działanie (act)
            Ułamek u = new Ułamek(licznik, mianownik);

            //werfikacja (assert)
            PrivateObject po = new PrivateObject(u);
            int u_licznik = u.Licznik;
            int u_mianownik = (int)po.GetField("mianownik");
            Assert.AreEqual(licznik, u_licznik, "Niezgodność w liczniku");
            Assert.AreEqual(mianownik, u_mianownik, "Niezgodność w mianowniku");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraWyjątek()
        {
            Ułamek u = new Ułamek(1, 0);
        }

        [TestMethod]
        public void TestPolaStatycznegoPołowa()
        {
            Ułamek uP = Ułamek.Połowa;
            Assert.AreEqual(1, uP.Licznik);
            Assert.AreEqual(2, uP.Mianownik);
        }
        [TestMethod]
        public void TestMetodyUprość()
        {
            Ułamek u = new Ułamek(4, -2);
            u.Uprość();
            Assert.AreEqual(-2, u.Licznik);
            Assert.AreEqual(1, u.Mianownik);
        }

        [TestMethod]
        public void TestOperatorów()
        {
            Ułamek a = Ułamek.Połowa;
            Ułamek b = Ułamek.Ćwierć;

            Assert.AreEqual(new Ułamek(3, 4), a + b, "Niepowodzenie przy dodawaniu");
            Assert.AreEqual(Ułamek.Ćwierć, a - b, "Niepowodzenie przy odejmowaniu");
            Assert.AreEqual(new Ułamek(1, 8), a * b, "Niepowodzenie przy mnożeniu");
            Assert.AreEqual(new Ułamek(2), a / b, "Niepowodzenie przy dzieleniu");
        }

        Random r = new Random();
        private int losujLiczbęCałkowitą(int? maksymalnaBezwzględnaWartość = null)
        {
            if (!maksymalnaBezwzględnaWartość.HasValue)
            {
                return r.Next(int.MinValue, int.MaxValue);
            }
            else
            {
                maksymalnaBezwzględnaWartość = Math.Abs(maksymalnaBezwzględnaWartość.Value);
                return r.Next(-maksymalnaBezwzględnaWartość.Value, maksymalnaBezwzględnaWartość.Value);
            }
        }

        private int losujLiczbęCałkowitąRóżnąOdZera(int? maksymalnaBezwzględnaWartość = null)
        {
            int wartosc;
            do
            {
                wartosc = losujLiczbęCałkowitą(maksymalnaBezwzględnaWartość);
            }
            while (wartosc == 0);
            return wartosc;
        }

        [TestMethod]
        public void TestSortowania()
        {
            Ułamek[] tablica = new Ułamek[100];
            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = new Ułamek(losujLiczbęCałkowitą(), losujLiczbęCałkowitąRóżnąOdZera());
            }

            Array.Sort(tablica);

            bool tablicaJestPosortowanaRosnąco = true;
            for (int i = 0; i < tablica.Length - 1; i++)
            {
                if (tablica[i] > tablica[i + 1]) tablicaJestPosortowanaRosnąco = false;
            }
            Assert.IsTrue(tablicaJestPosortowanaRosnąco);
        }
    }
}