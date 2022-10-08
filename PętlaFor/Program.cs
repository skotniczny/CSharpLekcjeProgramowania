for(int i = 0; i < 100; i++)
    Console.Write(i.ToString() + " ");

Console.WriteLine("\n***");

for (int i = 0; i < 100; i += 3)
    Console.Write(i.ToString() + " ");

Console.WriteLine("\n***");

int j = 0;
while (j < 100)
{
    Console.Write(j.ToString() + " ");
    j += 3;
};

Console.WriteLine("\n***");

for (int i1 = 0; i1 < 10; i1++)
{
    for (int i2 = 0; i2 < 10; i2++)
    {
        Console.Write((i1 * 10 + i2).ToString() + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("***");

for (int i = 0; i < 100; i++)
{
    Console.Write(i.ToString() + " ");
    if ((i + 1) % 10 == 0) Console.WriteLine();
}

Console.WriteLine("***");

for (int i = 99; i >= 0; i--)
{
    Console.Write(i.ToString() + " ");
    if (i % 10 == 0) Console.WriteLine();
}
