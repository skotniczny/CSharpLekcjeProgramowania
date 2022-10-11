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
    }
}