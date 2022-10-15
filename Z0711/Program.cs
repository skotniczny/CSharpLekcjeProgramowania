void BubbleSort(int[] arr)
{
    int end = arr.Length;
    do
    {
        for (int i = 0; i < end - 1; i++)
        {
            int a = arr[i];
            int b = arr[i + 1];
            if (a > b)
            {
                arr[i] = b;
                arr[i + 1] = a;
            }
        }
        end--;
        Console.WriteLine(String.Join(',', arr));
    }
    while (end > 1);
    
}

Random r = new Random();
int[] randoms = new int[8];

for (int i = 0; i < randoms.Length; i++)
{
    randoms[i] = r.Next(30);
}

Console.WriteLine(string.Join(',', randoms));
BubbleSort(randoms);
