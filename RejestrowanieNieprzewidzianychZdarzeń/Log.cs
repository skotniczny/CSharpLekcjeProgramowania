using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrowanieNieprzewidzianychZdarzeń
{
    public class Log
    {
        #region Singleton
        private static Log instancja;

        private Log()
        {
            Resetuj();
        }

        public static Log Instancja
        {
            get
            {
                if (instancja == null) instancja = new Log();
                return instancja;
            }
        }
        #endregion

        #region Rejestrowanie zdarzeń
        private List<string> rejestr = null;
        private DateTime czasRozpoczęciaRejestracji;

        public void Resetuj()
        {
            czasRozpoczęciaRejestracji = DateTime.Now;
            rejestr = new List<string>();
            rejestr.Add("#Data rozpoczęcia rejestracji: " + DateTime.Now.ToString());
            rejestr.Add("#Nazwa komputera: " + Environment.MachineName);
        }

        public void Dodaj(string komunikat)
        {
            double liczaMilisekundOdUruchomienia = (DateTime.Now - czasRozpoczęciaRejestracji).TotalMilliseconds;
            rejestr.Add(liczaMilisekundOdUruchomienia.ToString(System.Globalization.CultureInfo.InvariantCulture) + ": " + komunikat);
        }

        public void Zapisz()
        {
            rejestr.Add("#Data zakończenia rejestracji: " + DateTime.Now.ToString());
            System.IO.File.AppendAllLines("Log.txt", rejestr);
            Resetuj();
        }
        #endregion
    }
}
