string s = "Hello";
s += " World!";
Console.WriteLine("Łańcuch: " + s);
Console.WriteLine("Długość: " + s.Length);
Console.WriteLine("Drukowanymi: " + s.ToUpper());
string r = s.ToUpper().Replace('L', '1').Replace('O', '0').Replace('E', '3');
Console.WriteLine("Zmodyfikowany łańcuch: " + r);
char[] litery = s.ToCharArray();
