using System;

namespace Konsola.Model
{
    public struct Rozmiar
    {
        public int Szerokość;
        public int Wysokość;

        public override string ToString()
        {
            return $" {Szerokość} x {Wysokość}";
        }
    }
    public class UstawieniaKonsoli
    {
        public ConsoleColor KolorTła;
        public ConsoleColor KolorCzcionki;
        public Rozmiar RozmiarOkna;
        public Rozmiar RozmiarBufora;
        public string Tytuł;

        public override string ToString()
        {
            return $"Kolor tła: {KolorTła.ToString()}" +
                $"\nKolor czcionki: {KolorCzcionki.ToString()}" +
                $"\nRozmiar okna: {RozmiarOkna.ToString()}" +
                $"\nRozmiar bufora: {RozmiarBufora.ToString()}" +
                $"\nTytuł: {Tytuł}";
        }
    }
}
