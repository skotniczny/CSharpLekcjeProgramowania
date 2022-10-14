Random r = new Random();
int n = r.Next(8); // losowanie liczby od 0 do 7
string[] dniTygodnia =
    {
        "",
        "niedziela",
        "poniedziałek",
        "wtorek",
        "środa",
        "czwartek",
        "piątek",
        "sobota",
    };
string opis = dniTygodnia[n];

Console.WriteLine("Dzień tygodnia: " + n + ", " + opis);
