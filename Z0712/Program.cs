using System.Text;

string[] słowa = { "czereśnia", "jabłko", "borówka", "wiśnia", "jagoda", "gruszka", "śliwka", "malina" };

//a) najdłuższą i najkrótszą długość słowa,

void ShortestAndLongestWord(string[] strings, out int shortest, out int longest)
{
    shortest = int.MaxValue;
    longest = 0;

    foreach (string s in strings)
    {
        if (s.Length > longest) longest = s.Length;
        if (s.Length < shortest) shortest = s.Length;
    }
}

ShortestAndLongestWord(słowa, out int shortest, out int longest);
Console.WriteLine($"Najkrótsze słowo: {shortest}, Najdłuższe słowo: {longest}");

//b) średnią długość słów,

double AverageWordLength(string[] strings)
{
    double sum = 0;
    foreach (string s in strings)
    {
        sum += s.Length;
    }
    return sum / (double)strings.Length;
}

Console.WriteLine(AverageWordLength(słowa));

//c) całkowitą liczbę liter we wszystkich słowach,

int SumWordsLetters(string[] strings)
{
    int sum = 0;
    foreach (string s in strings)
    {
        sum += s.Length;
    }
    return sum;
}

Console.WriteLine(SumWordsLetters(słowa));

//d) tablicę słów posortowanych alfabetycznie,

string[] SortWordsAlphabetically(string[] strings)
{
    string[] _strings = (string[])strings.Clone();
    Array.Sort(_strings);
    return _strings;
}

Console.WriteLine(string.Join(',', SortWordsAlphabetically(słowa)));

//e) tablicę słów posortowanych według liczby liter,

string[] SortWordsByLength(string[] strings)
{
    string[] _strings = (string[])strings.Clone();
    Array.Sort(_strings, (string s1, string s2) => s1.Length.CompareTo(s2.Length));
    return _strings;
}

Console.WriteLine(string.Join(',', SortWordsByLength(słowa)));

//f) wszystkie słowa o długości większej niż podana w argumencie liczba liter,

string[] FilterByLength(string[] strings, int minLength)
{
    StringBuilder filtered = new StringBuilder();

    foreach (string s in strings)
    {
        if (s.Length > minLength)
        {
            filtered.Append(s + " ");
        }
    }
    if (filtered.Length > 0)
    {
        return filtered.ToString().Remove(filtered.Length - 1).Split(' ');

    }
    return new string[0];
}

string[] test = FilterByLength(słowa, 7);

Console.WriteLine(string.Join(',', FilterByLength(słowa, 7)));


//g) wszystkie słowa kończące się na podaną w argumencie literę,

string[] FilterByLastLetter(string[] strings, char lastChar)
{
    StringBuilder filtered = new StringBuilder();

    foreach (string s in strings)
    {
        if (s[s.Length - 1] == lastChar)
        {
            filtered.Append(s + " ");
        }
    }
    if (filtered.Length > 0)
    {
        return filtered.ToString().Remove(filtered.Length - 1).Split(' ');
    }
    return new string[0];
}

Console.WriteLine(string.Join(',', FilterByLastLetter(słowa, 'o')));

//h) tablicę liczb typu int z długościami poszczególnych słów,

int[] WordLengths(string[] strings)
{
    int[] lengths = new int[strings.Length];

    int index = 0;
    foreach (string s in strings)
    {
        lengths[index++] = s.Length;
    }

    return lengths;
}

Console.WriteLine(string.Join(',', WordLengths(słowa)));

//i) tablicę słów z literami zmienionymi na duże.

string[] CapitalizeWords(string[] strings)
{
    string[] _strings = (string[])słowa.Clone();

    int index = 0;
    foreach (string s in strings)
    {
        _strings[index++] = s.ToUpper();
    }

    return _strings;
}

Console.WriteLine(string.Join(',', CapitalizeWords(słowa)));
