namespace Turing
{
    struct Dwójka : IComparable<Dwójka>
    {
        public char StanGłowicy;
        public char WartośćLubPolecenieNaTaśmie;

        public int CompareTo(Dwójka other)
        {
            int wartosc = StanGłowicy.CompareTo(other.StanGłowicy);
            if (wartosc != 0) return wartosc;
            else return WartośćLubPolecenieNaTaśmie.CompareTo(other.WartośćLubPolecenieNaTaśmie);
        }
    }
    struct Czwórka
    {
        public Dwójka BieżącyStan, NowyStan;

        private static bool czyŁańcuchCzwórkiPoprawny(string linia)
        {
            Func<char, bool> isLowerLetter = (char c) => c >= 'a' && c <= 'z';
            Func<char, bool> isUpperLetter = (char c) => c >= 'A' && c <= 'Z';
            return isLowerLetter(linia[0]) && isUpperLetter(linia[1]) &&
                   isUpperLetter(linia[2]) && isLowerLetter(linia[3]);
        }

        public static Czwórka Parsuj(string linia)
        {
            if (string.IsNullOrEmpty(linia)) throw new Exception("Pusta linia kodu");
            if (!czyŁańcuchCzwórkiPoprawny(linia)) throw new Exception($"Niepoprawna linia kodu {linia}");
            Czwórka czwórka = new Czwórka()
            {
                BieżącyStan = new Dwójka()
                {
                    StanGłowicy = linia[0],
                    WartośćLubPolecenieNaTaśmie = linia[1]
                },
                NowyStan = new Dwójka()
                {
                    StanGłowicy = linia[3],
                    WartośćLubPolecenieNaTaśmie = linia[2]
                }
            };
            return czwórka;
        }
    }

    class ProgramMaszynyTuringa
    {
        private SortedList<Dwójka, Dwójka> czwórki;

        static SortedList<Dwójka, Dwójka> parsuj(string[] kodProgramu)
        {
            SortedList<Dwójka, Dwójka> czwórki = new SortedList<Dwójka, Dwójka>();
            foreach (string linia in kodProgramu)
            {
                try
                {
                    Czwórka czwórka = Czwórka.Parsuj(linia);
                    if (czwórki.ContainsKey(czwórka.BieżącyStan))
                    {
                        throw new Exception("Program głowicy nie może zawierać dwóch poleceń o takim stanie głowicy i wartości na taśmie");
                    }
                    czwórki.Add(czwórka.BieżącyStan, czwórka.NowyStan);
                }
                catch (Exception exc)
                {
                    Console.Error.WriteLine(exc.Message);
                }
            }
            return czwórki;
        }

        public ProgramMaszynyTuringa(string[] kodProgramu)
        {
            czwórki = parsuj(kodProgramu);
        }

        public Dwójka? ZnajdźPolecenie(Dwójka bieżącyStan)
        {
            if (czwórki.ContainsKey(bieżącyStan)) return czwórki[bieżącyStan];
            else return null;
        }
    }

    class StanMaszynyTuringa
    {
        public char[] Taśma;
        public char StanGłowicy;
        public int PołożenieGłowicy;

        public Dwójka BieżącyStan
        {
            get => new Dwójka()
            {
                StanGłowicy = this.StanGłowicy,
                WartośćLubPolecenieNaTaśmie = Taśma[this.PołożenieGłowicy]
            };
        }

        public StanMaszynyTuringa(char[] taśma, char stanGłowicy, int położenieGłowicy)
        {
            Taśma = taśma;
            StanGłowicy = stanGłowicy;
            PołożenieGłowicy = położenieGłowicy;
        }

        public string ŁańcuchOpisującyStanMaszyny
        {
            get
            {
                string s = new string(Taśma);
                s = s.Insert(PołożenieGłowicy, StanGłowicy.ToString());
                return s;
            }
            set
            {
                StanMaszynyTuringa stan = StanMaszynyTuringa.analizuj(value);
                Taśma = stan.Taśma;
                StanGłowicy = stan.StanGłowicy;
                PołożenieGłowicy = stan.PołożenieGłowicy;
            }
        }

        private static StanMaszynyTuringa analizuj(string łańcuchOpisującyStanMaszyny)
        {
            char stanGłowicy = ' ';
            int położenieGłowicy = -1;
            for (int i = 0; i < łańcuchOpisującyStanMaszyny.Length; ++i)
            {
                char c = łańcuchOpisującyStanMaszyny[i];
                if (c == 'L' || c == 'R')
                {
                    throw new Exception("Taśma nie może zawierać wartości L lub R");
                }
                if (char.IsLower(c))
                {
                    if (położenieGłowicy != -1)
                    {
                        throw new Exception("Znaleziono więcej niż jeden znak oznaczający głowicę");
                    }
                    stanGłowicy = c;
                    położenieGłowicy = i;
                    łańcuchOpisującyStanMaszyny = łańcuchOpisującyStanMaszyny.Remove(położenieGłowicy, 1);
                }
                else
                {
                    if (c < 'A' || c > 'Z')
                    {
                        throw new Exception($"Niepoprawna wartość na taśmie ({c} na pozycji {i}");
                    }
                }
            }
            if (położenieGłowicy < 0)
            {
                throw new Exception("Nie znaleziono znaku oznaczającego głowicę");
            }
            return new StanMaszynyTuringa(łańcuchOpisującyStanMaszyny.ToCharArray(), stanGłowicy, położenieGłowicy);
        }

        public StanMaszynyTuringa Twórz(string łańcuchOpisującyStanMaszyny)
        {
            return analizuj(łańcuchOpisującyStanMaszyny);
        }

        public StanMaszynyTuringa(string łańcuchOpisującyStanMaszyny)
        {
            ŁańcuchOpisującyStanMaszyny = łańcuchOpisującyStanMaszyny;
        }

        public override string ToString()
        {
            return ŁańcuchOpisującyStanMaszyny;
        }
    }

    public class MaszynaTuringa
    {
        private StanMaszynyTuringa stan; //aktualny stan
        private ProgramMaszynyTuringa program; //program maszyny Turinga

        public MaszynaTuringa(string łańcuchOpisującyStanMaszyny, string[] kodProgramu)
        {
            stan = new StanMaszynyTuringa(łańcuchOpisującyStanMaszyny);
            program = new ProgramMaszynyTuringa(kodProgramu);
        }

        public string[] WykonajProgram()
        {
            List<string> historia = new List<string>();
            historia.Add(stan.ŁańcuchOpisującyStanMaszyny);
            Dwójka? polecenie;
            while ((polecenie = program.ZnajdźPolecenie(stan.BieżącyStan)) != null)
            {
                string łańcuchOpisującyPoprzedniStan = stan.ŁańcuchOpisującyStanMaszyny;
                stan.StanGłowicy = polecenie.Value.StanGłowicy;
                switch (polecenie.Value.WartośćLubPolecenieNaTaśmie)
                {
                    case 'L':
                        stan.PołożenieGłowicy--;
                        break;
                    case 'R':
                        stan.PołożenieGłowicy++;
                        break;
                    default:
                        stan.Taśma[stan.PołożenieGłowicy] = polecenie.Value.WartośćLubPolecenieNaTaśmie;
                        break;
                }
                historia.Add(stan.ŁańcuchOpisującyStanMaszyny);
                onStanZmieniony(łańcuchOpisującyPoprzedniStan, stan.ŁańcuchOpisującyStanMaszyny);
            }
            return historia.ToArray();
        }

        #region Zdarzenie
        public class StanZmienionyEventArgs : EventArgs
        {
            public string ŁańcuchOpisującyPoprzedniStan, ŁańcuchOpisującyNowyStan;
        }

        public event EventHandler<StanZmienionyEventArgs> StanZmieniony;

        private void onStanZmieniony(string łańcuchOpisującyPoprzedniStan, string łańcuchOpisującyNowyStan)
        {
            if (StanZmieniony != null)
            {
                StanZmieniony(this, new StanZmienionyEventArgs()
                {
                    ŁańcuchOpisującyPoprzedniStan = łańcuchOpisującyPoprzedniStan,
                    ŁańcuchOpisującyNowyStan = łańcuchOpisującyNowyStan
                });
            }
        }
        #endregion
    }

    class Turing
    {
    }
}
