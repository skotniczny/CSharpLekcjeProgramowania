using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace KursyWalut
{
    public struct KursyWalutyNBP
    {
        public string NazwaWaluty;
        public string KodWaluty;
        public double Przelicznik;
        public decimal KursKupna;
        public decimal KursSprzedaży;

        public string ToString(IFormatProvider formatProvider)
        {
            return $"{KodWaluty} {KursKupna.ToString(formatProvider)} {KursSprzedaży.ToString(formatProvider)}";
        }

        public override string ToString()
        {
            return ToString(new CultureInfo("pl"));
        }
    }

    public struct TabelaKursówNBP
    {
        public string NumerTabeli;
        public DateTime DataNotowania;
        public DateTime DataPublikacji;
        public Dictionary<string, KursyWalutyNBP> Pozycje;
    }

    public static class PomocnikNbp
    {
        private static KursyWalutyNBP parsujPozycjęTabeliKUrsówWalutNBP(XElement elementPozycja, IFormatProvider formatProvider)
        {
            KursyWalutyNBP pozycja = new KursyWalutyNBP();
            pozycja.NazwaWaluty = elementPozycja.Element("nazwa_waluty").Value;
            pozycja.Przelicznik = double.Parse(elementPozycja.Element("przelicznik").Value, formatProvider);
            pozycja.KodWaluty = elementPozycja.Element("kod_waluty").Value;
            pozycja.KursKupna = decimal.Parse(elementPozycja.Element("kurs_kupna").Value, formatProvider);
            pozycja.KursSprzedaży = decimal.Parse(elementPozycja.Element("kurs_sprzedazy").Value, formatProvider);
            return pozycja;
        }

        private static string pobierzPlik(string adres)
        {
            using HttpClient klientSieciowy = new HttpClient();
            using Stream strumień = klientSieciowy.GetStreamAsync(adres).Result;
            return new StreamReader(strumień).ReadToEnd();
        }

        public static TabelaKursówNBP PobierzAktualnąTabelęKursówWalutNBP()
        {
            string adres = "http://www.nbp.pl/kursy/xml/LastC.xml";
            //XDocument xml = XDocument.Load(adres);
            string zawartośćPlikuXml = pobierzPlik(adres);
            XDocument xml = XDocument.Parse(zawartośćPlikuXml);

            IFormatProvider formatProvider = new CultureInfo("pl");

            TabelaKursówNBP tabela = new TabelaKursówNBP();
            tabela.NumerTabeli = xml.Root.Element("numer_tabeli").Value;
            tabela.DataNotowania = DateTime.Parse(xml.Root.Element("data_notowania").Value, formatProvider);
            tabela.DataPublikacji = DateTime.Parse(xml.Root.Element("data_publikacji").Value, formatProvider);

            tabela.Pozycje = new Dictionary<string, KursyWalutyNBP>();
            foreach (XElement elementPozycja in xml.Root.Elements("pozycja"))
            {
                KursyWalutyNBP pozycja = parsujPozycjęTabeliKUrsówWalutNBP(elementPozycja, formatProvider);
                tabela.Pozycje.Add(pozycja.KodWaluty, pozycja);
            }

            return tabela;
        }
    }
}
