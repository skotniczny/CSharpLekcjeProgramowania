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
            Assert.AreEqual(licznik, u.Licznik, "Niezgodność w liczniku");
            Assert.AreEqual(mianownik, u.Mianownik, "Niezgodność w mianowniku");
        }
    }
}