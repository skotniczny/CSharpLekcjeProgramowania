using System;

namespace Konsola.Kontroler
{
    using static Wejście;
    using Model;
    using Widok;

    public class Menu
    {
        private static void wyświetlMenu()
        {
            string s = "\nMenu:";
            s += "\n1. Przywróć ustawienia domyślne";
            s += "\n2. Zmień kolor tła";
            s += "\n3. Zmień kolor czcionki";
            s += "\n4. Zmień rozmiar okna";
            s += "\n5. Zmień rozmiar bufora";
            s += "\n6. Zmień tytuł okna";
            s += "\n0. Zakończ program";
            Console.WriteLine(s);
        }

        private UstawieniaKonsoli ustawienia;
        private UstawieniaKonsoli poprzednieUstawienia = PomocnikUstawieńKonsoli.UstawieniaBieżące;

        private void spróbujZastosowaćUstawienia()
        {
            if (StosowanieUstawieńKonsoli.ZastosujUstawienia(ustawienia))
            {
                poprzednieUstawienia = (UstawieniaKonsoli)ustawienia.Clone();
            }
            else
            {
                Console.Error.WriteLine("Przywracam poprzednie ustawienia");
                StosowanieUstawieńKonsoli.ZastosujUstawienia(poprzednieUstawienia);
            }
        }

        public Menu(UstawieniaKonsoli ustawienia)
        {
            this.ustawienia = ustawienia;
            spróbujZastosowaćUstawienia();
        }

        public void Uruchom()
        {
            int wybór = 0;
            do
            {
                Console.WriteLine(ustawienia.ToString());
                wyświetlMenu();
                wybór = PobierzOdUżytkownikaLiczbęCałkowitą("Wybierz pozycję z menu wpisując liczbę i naciskająć klawisz Enter: ", 6);

                switch (wybór)
                {
                    case 1:
                        Console.WriteLine("Przywracam ustawienia domyślne");
                        ustawienia.KolorTła = PomocnikUstawieńKonsoli.UstawieniaDomyślne.KolorTła;
                        ustawienia.KolorCzcionki = PomocnikUstawieńKonsoli.UstawieniaDomyślne.KolorCzcionki;
                        ustawienia.RozmiarOkna = PomocnikUstawieńKonsoli.UstawieniaDomyślne.RozmiarOkna;
                        ustawienia.RozmiarBufora = PomocnikUstawieńKonsoli.UstawieniaDomyślne.RozmiarBufora;
                        ustawienia.Tytuł = PomocnikUstawieńKonsoli.UstawieniaDomyślne.Tytuł;
                        break;
                    case 2:
                        ConsoleColor kolorTła = PobierzOdUżytkownikaKolor("Podaj kolor tła (po angielsku): ");
                        ustawienia.KolorTła = kolorTła;
                        break;
                    case 3:
                        ConsoleColor kolorCzcionki = PobierzOdUżytkownikaKolor("Podaj kolor czcionki (po angielsku): ");
                        ustawienia.KolorCzcionki = kolorCzcionki;
                        break;
                    case 4:
                        {
                            int x = PobierzOdUżytkownikaLiczbęCałkowitą("Podaj szerokość okna: ", Console.LargestWindowWidth);
                            int y = PobierzOdUżytkownikaLiczbęCałkowitą("Podaj wysokość okna: ", Console.LargestWindowHeight);
                            Rozmiar rozmiar = new Rozmiar()
                            {
                                Szerokość = x,
                                Wysokość = y
                            };
                            ustawienia.RozmiarOkna = rozmiar;
                        }
                        break;
                    case 5:
                        {
                            int x = PobierzOdUżytkownikaLiczbęCałkowitą("Podaj szerokość bufora: ", short.MaxValue);
                            int y = PobierzOdUżytkownikaLiczbęCałkowitą("Podaj wysokość bufora: ", short.MaxValue);
                            Rozmiar rozmiar = new Rozmiar()
                            {
                                Szerokość = x,
                                Wysokość = y
                            };
                            ustawienia.RozmiarBufora = rozmiar;
                        }
                        break;
                    case 6:
                        Console.Write("Podaj tytuł okna: ");
                        string tytuł = Console.ReadLine();
                        ustawienia.Tytuł = tytuł;
                        break;
                }
                spróbujZastosowaćUstawienia();
            }
            while (wybór != 0);
        }
    }
}
