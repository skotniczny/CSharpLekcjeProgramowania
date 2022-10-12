for (int i = 0; i < 4; i++)
{
    for (int j = 4; j - i >= 1; j--)
    {
        Console.Write('*');
    }
    Console.Write('\n');
}

Console.WriteLine();

for (int i = 0; i < 4; i++)
{
    for (int j = 5; j >= 1; j--)
    {
        Console.Write(j + i);
    }
    Console.Write('\n');
}

Console.WriteLine();

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write((i + j) % 2 == 0 ? '1' : '2');
    }
    Console.Write('\n');
}

Console.WriteLine();

for (int i = 1; i < 5; i++)
{
    for (int j = i; j < 3 + i; j++)
    {
        for (int k = 0; k < j; k++)
        {
            Console.Write(j);
        }
    }
    Console.Write('\n');
}