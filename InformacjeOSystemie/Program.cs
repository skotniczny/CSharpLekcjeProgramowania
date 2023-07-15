namespace InformacjeOSystemie
{
    internal class Program
    {
        static string system = $"Wersja systemu: {Environment.OSVersion} " +
            (Environment.Is64BitOperatingSystem ? ", 64 bitowy" : "") +
            $"\nWersja Microsoft .NET Framework: {Environment.Version}" +
            $"\nNazwa komputera: {Environment.MachineName}" +
            $"\nKatalog systemowy: {Environment.SystemDirectory}";

        static void Main(string[] args)
        {
            Console.WriteLine($"Informacje o systemie:\n{system}");
        }
    }
}