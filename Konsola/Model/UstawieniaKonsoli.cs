using System;

namespace Konsola.Model
{
    public struct Rozmiar
    {
        public int Szerokość { get; set; }
        public int Wysokość { get; set; }

        public override string ToString()
        {
            return $" {Szerokość} x {Wysokość}";
        }
    }
    public class UstawieniaKonsoli : ICloneable
    {
        public ConsoleColor KolorTła { get; set; }
        public ConsoleColor KolorCzcionki { get; set; }
        public Rozmiar RozmiarOkna { get; set; }
        public Rozmiar RozmiarBufora { get; set; }
        public string Tytuł { get; set; }

        public override string ToString()
        {
            return $"Kolor tła: {KolorTła.ToString()}" +
                $"\nKolor czcionki: {KolorCzcionki.ToString()}" +
                $"\nRozmiar okna: {RozmiarOkna.ToString()}" +
                $"\nRozmiar bufora: {RozmiarBufora.ToString()}" +
                $"\nTytuł: {Tytuł}";
        }

        public object Clone()
        {
            return new UstawieniaKonsoli()
            {
                KolorTła = this.KolorTła,
                KolorCzcionki = this.KolorCzcionki,
                RozmiarOkna = this.RozmiarOkna,
                RozmiarBufora = this.RozmiarBufora,
                Tytuł = this.Tytuł
            };
        }
    }
}
