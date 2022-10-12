int Nwd(int a, int b)
{
    int c;
    while (b != 0)
    {
        c = a % b;
        a = b;
        b = c;
    }
    return a;
}

int Nww(int a, int b)
{
    return a * b / Nwd(a, b);
}

int a = 45;
int b = 195;

Console.WriteLine($"a={a} b={b}");
Console.WriteLine($"NWD: {Nwd(a, b)}");
Console.WriteLine($"NWW: {Nww(a, b)}");
