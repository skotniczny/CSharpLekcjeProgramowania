using System;
using System.Xml.Linq;

namespace Konsola.Model
{
    public static class PomocnikXml
    {
        public static void Zapisz(this UstawieniaKonsoli ustawienia, string ścieżkaPliku)
        {
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment($"Ustawienia zapisane przez program {System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)}"),
                new XElement("ustawienia",
                    new XAttribute("tytuł", ustawienia.Tytuł),
                    new XElement("kolory",
                        new XElement("tło", ustawienia.KolorTła),
                        new XElement("czcionka", ustawienia.KolorCzcionki)
                    ),
                    new XElement("rozmiary",
                        new XElement("okno",
                            new XElement("X", ustawienia.RozmiarOkna.Szerokość),
                            new XElement("Y", ustawienia.RozmiarOkna.Wysokość)
                        ),
                        new XElement("bufor",
                            new XElement("X", ustawienia.RozmiarBufora.Szerokość),
                            new XElement("Y", ustawienia.RozmiarBufora.Wysokość)
                        )
                    )
                )
            );
            xml.Save(ścieżkaPliku);
        }

        public static void Zapisz2(this UstawieniaKonsoli ustawienia, string ścieżkaPliku)
        {
            // definiowanie obiektów
            XDeclaration deklaracja = new XDeclaration("1.0", "utf-8", "yes");
            XComment komentarz = new XComment($"Ustawienia zapisane przez program {System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)}");
            XElement korzeń = new XElement("ustawienia");
            XAttribute tytuł = new XAttribute("tytuł", ustawienia.Tytuł);
            XElement kolory = new XElement("kolory");
            XElement tło = new XElement("tło", ustawienia.KolorTła);
            XElement czcionka = new XElement("czcionka", ustawienia.KolorCzcionki);
            XElement rozmiary = new XElement("rozmiary");
            XElement okno = new XElement("okno");
            XElement oknoX = new XElement("X", ustawienia.RozmiarOkna.Szerokość);
            XElement oknoY = new XElement("Y", ustawienia.RozmiarOkna.Wysokość);
            XElement bufor = new XElement("bufor");
            XElement buforX = new XElement("X", ustawienia.RozmiarBufora.Szerokość);
            XElement buforY = new XElement("Y", ustawienia.RozmiarBufora.Wysokość);

            // budowanie drzewa (tu od gałęzi)
            kolory.Add(tło);
            kolory.Add(czcionka);
            okno.Add(oknoX);
            okno.Add(oknoY);
            bufor.Add(buforX);
            bufor.Add(buforY);
            rozmiary.Add(okno);
            rozmiary.Add(bufor);
            korzeń.Add(tytuł);
            korzeń.Add(kolory);
            korzeń.Add(rozmiary);
            XDocument xml = new XDocument();
            xml.Declaration = deklaracja;
            xml.Add(komentarz);
            xml.Add(korzeń);

            // zapis do pliku
            xml.Save(ścieżkaPliku);
        }

        public static UstawieniaKonsoli Czytaj(string ścieżkaPliku)
        {
            XDocument xml = XDocument.Load(ścieżkaPliku);
            UstawieniaKonsoli ustawienia = new UstawieniaKonsoli();

            // odczytywanie tytułu okna
            ustawienia.Tytuł = xml.Root.Attribute("tytuł").Value;

            // odczytywanie kolorów
            XElement element = xml.Root.Element("kolory");
            ustawienia.KolorTła = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), element.Element("tło").Value);
            ustawienia.KolorCzcionki = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), element.Element("czcionka").Value);

            // odczytywanie rozmiaru okna i bufora
            element = xml.Root.Element("rozmiary").Element("okno");
            ustawienia.RozmiarOkna.Szerokość = int.Parse(element.Element("X").Value);
            ustawienia.RozmiarOkna.Wysokość = int.Parse(element.Element("Y").Value);
            element = xml.Root.Element("rozmiary").Element("bufor");
            ustawienia.RozmiarBufora.Szerokość = int.Parse(element.Element("X").Value);
            ustawienia.RozmiarBufora.Wysokość = int.Parse(element.Element("Y").Value);

            return ustawienia;
        }
    }
}
