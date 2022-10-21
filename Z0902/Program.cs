using System.Text;

static string CesarEncode(string text, int mov)
{
    Dictionary<char, char> dict = new Dictionary<char, char>();

    for (char c = 'A'; c <= 'Z'; c++)
    {
        int pos = c + mov;
        dict[c] = (char)((pos <= 'Z') ? pos : (pos % 'Z') + '@');
    }
    for (char c = 'a'; c <= 'z'; c++)
    {
        int pos = c + mov;
        dict[c] = (char)((pos <= 'z') ? pos : (pos % 'z') + '`');
    }

    StringBuilder output = new StringBuilder();
    foreach (char c in text)
    {
        output.Append(dict.ContainsKey(c) ? dict[c] : c);
    }

    return output.ToString();
}

Console.WriteLine(CesarEncode("abcABC xyzXYZ", 1));
Console.WriteLine(CesarEncode("bababadalgharaghtakamminarronnkonnbronntonnerronntuonnthunntrovarrhounawnskawntoohoohoordenenthurnuk!", 26));
