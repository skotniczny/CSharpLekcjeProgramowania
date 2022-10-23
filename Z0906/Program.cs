List<string> listaŁańcuchów = new List<string>();
bool exit = false;
void Dodaj(string zachęta)
{
    Console.Write(zachęta);
    string łańcuch = Console.ReadLine();
    if (string.IsNullOrEmpty(łańcuch))
    {
        Console.WriteLine("Wpisz łańcuch poprawny łańcuch!");
    };
    listaŁańcuchów.Add(łańcuch);
}

void Usuń(string zachęta)
{
    bool sukces;
    int indeks;
    do
    {
        Console.Write(zachęta);
        sukces = int.TryParse(Console.ReadLine(), out indeks);
    }
    while (!sukces);
    if (indeks > 0 && indeks <= listaŁańcuchów.Count())
        listaŁańcuchów.RemoveAt(--indeks);
    else
        Console.WriteLine("Podany indeks jest poza zakresem.");
}

void Wyświetl()
{
    int i = 1;
    if (listaŁańcuchów.Count == 0) Console.WriteLine("Lista łańcuchów jest pusta");
    foreach (string element in listaŁańcuchów)
    {
        Console.WriteLine($"{(i++).ToString("##")}. {element}");
    }
}

void Sortuj() {
    List<string> _lista = listaŁańcuchów.ToList();
    _lista.Sort();
    int index = 1;
    foreach (string element in _lista) Console.WriteLine($"{index++} {element}");
}

do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Dodaj łańcuch do listy");
    Console.WriteLine("2. Usuń łańcuch z listy");
    Console.WriteLine("3. Sortuj alfabetycznie");
    Console.WriteLine("4. Wyświetl listę");
    Console.WriteLine("5. Zakończ");
    string command = Console.ReadLine();
    switch (command)
    {
        case "1":
            Dodaj("Wpisz łańcuch: ");
            break;
        case "2":
            Usuń("Podaj pozycję łańcucha do usunięcia: ");
            break;
        case "3":
            Sortuj();
            break;
        case "4":
            Wyświetl();
            break;
        case "5":
            exit = true;
            break;
        default:
            break;
    }
} while (!exit);

Console.WriteLine("Zakończono program");
