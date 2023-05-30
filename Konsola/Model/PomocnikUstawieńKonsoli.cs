using System;

namespace Konsola.Model
{
    public static class PomocnikUstawieńKonsoli //helper
    {
        public static UstawieniaKonsoli UstawieniaBieżące
        {
            get
            {
                return new UstawieniaKonsoli()
                {
                    KolorTła = Console.BackgroundColor,
                    KolorCzcionki = Console.ForegroundColor,
                    RozmiarOkna = new Rozmiar()
                    {
                        Szerokość = Console.WindowWidth,
                        Wysokość = Console.WindowHeight
                    },
                    RozmiarBufora = new Rozmiar()
                    {
                        Szerokość = Console.BufferWidth,
                        Wysokość = Console.BufferHeight
                    },
                    Tytuł = Console.Title
                };
            }
        }

        private static UstawieniaKonsoli ustawieniaDomyślne = new UstawieniaKonsoli()
        {
            KolorTła = ConsoleColor.Black,
            KolorCzcionki = ConsoleColor.Gray,
            RozmiarOkna = new Rozmiar { Szerokość = 120, Wysokość = 30 },
            RozmiarBufora = new Rozmiar { Szerokość = 120, Wysokość = 9001 },
            Tytuł = System.Reflection.Assembly.GetEntryAssembly().Location
        };

        public static UstawieniaKonsoli UstawieniaDomyślne
        {
            get => ustawieniaDomyślne;
        }
    }
}
