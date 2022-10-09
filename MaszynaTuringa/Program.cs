namespace MaszynaTuringa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kodProgramu = File.ReadAllLines("program.txt");
            string łańcuchOpisującyStanMaszyny = File.ReadAllText("taśma.txt");
            Console.WriteLine($"Początkowy stan maszyny: {łańcuchOpisującyStanMaszyny}");
            Console.WriteLine($"Program:");
            foreach (string linia in kodProgramu) Console.WriteLine(linia);
        }
    }
}