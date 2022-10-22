static T[] przepiszElementyDoTablicy<T>(IEnumerable<T> lista)
{
    List<T> l = new List<T>();
    foreach (T element in lista) l.Add(element);

    return l.ToArray();
}

Stack<string> s = new Stack<string>();
s.Push("a");
s.Push("b");
s.Push("c");

string[] tablica = przepiszElementyDoTablicy(s);
Console.WriteLine(string.Join(',', tablica));
