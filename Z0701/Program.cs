int[] potęgi2 = new int[10];
int podstawa = 2;
int indeks = podstawa - podstawa;
int potęga = podstawa / podstawa;
for (int i = indeks; i < potęgi2.Length; i++)
{
    potęgi2[i] = potęga *= podstawa;
}

Console.WriteLine(String.Join(',', potęgi2));