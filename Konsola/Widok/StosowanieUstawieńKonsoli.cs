using Konsola.Model;

namespace Konsola.Widok
{
    public class StosowanieUstawieńKonsoli
    {
        public static bool ZastosujUstawienia(UstawieniaKonsoli ustawienia, bool wyczyśćKonsolę = true)
        {
            try
            {
                Console.BackgroundColor = ustawienia.KolorTła;
                Console.ForegroundColor = ustawienia.KolorCzcionki;
                Console.SetWindowSize(ustawienia.RozmiarOkna.Szerokość, ustawienia.RozmiarOkna.Wysokość);
                Console.SetBufferSize(ustawienia.RozmiarBufora.Szerokość, ustawienia.RozmiarBufora.Wysokość);
                Console.Title = ustawienia.Tytuł;
                if (wyczyśćKonsolę)
                {
                    Console.Clear();
                }
                return true;
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine($"Wystąpił błąd: {exc.Message}");
                return false;
            }
        }
    }
}
