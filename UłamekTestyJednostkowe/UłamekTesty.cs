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
    }
}