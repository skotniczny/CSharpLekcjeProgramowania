using System.Text;
using System.Text.RegularExpressions;

namespace Z1004
{
    internal class Program
    {
        static void Main()
        {
            SortedList<string, ConsoleColor> słownik = new SortedList<string, ConsoleColor>()
            {
                { "if", ConsoleColor.DarkMagenta },
                { "else", ConsoleColor.DarkMagenta },
                { "for", ConsoleColor.DarkMagenta },
                { "foreach", ConsoleColor.DarkMagenta },
                { "do", ConsoleColor.DarkMagenta },
                { "while", ConsoleColor.DarkMagenta },
                { "switch", ConsoleColor.DarkMagenta },
                { "case", ConsoleColor.Blue },
                { "List", ConsoleColor.Green },
                { "Random", ConsoleColor.Green },
                { "Queue", ConsoleColor.Green },
                { "Stack", ConsoleColor.Green },
                { "throw", ConsoleColor.DarkMagenta },
                { "get", ConsoleColor.Blue },
                { "set", ConsoleColor.Blue },
                { "value", ConsoleColor.Blue },
                { "new", ConsoleColor.Blue },
                { "int", ConsoleColor.Blue },
                { "string", ConsoleColor.Blue },
                { "double", ConsoleColor.Blue },
                { "return", ConsoleColor.DarkMagenta },
                { "out", ConsoleColor.Blue },
            };

            string ścieżkaPliku = @"..\..\..\..\ZabawaKostkami\Program.cs";
            string tekst = File.ReadAllText(ścieżkaPliku);

            foreach (string słowo in tekst.Split(' '))
            {
                if (słownik.ContainsKey(słowo))
                {
                    Console.ForegroundColor = słownik[słowo];
                    Console.Write($"{słowo} ");
                    Console.ResetColor();
                }
                else { 
                    Console.Write($"{słowo} ");
                }
            }
        }
    }
}