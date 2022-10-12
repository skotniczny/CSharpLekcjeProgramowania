static decimal Podatek(decimal kwota)
{
    decimal podatek = 0;
    if (kwota > 30000)
    {
        podatek += (kwota - 30000) * 0.2m;
        kwota = 30000;
    }
    if (kwota >= 10000)
    {
        podatek += (kwota - 9999) * 0.15m;
        kwota = 9999;
    }
    podatek += kwota * 0.1m;
    return podatek;
}

Console.WriteLine(Podatek(9999));
Console.WriteLine(Podatek(10000));
Console.WriteLine(Podatek(30000));
Console.WriteLine(Podatek(40000));
