using System.Runtime.CompilerServices;

namespace Debugowanie
{
    internal class Program
    {
        static private int kwadrat(int argument)
        {
            int wartość;
            wartość = checked(argument * argument);
            if (wartość < 0)
            {
                throw new Exception("Funkcja kwadrat nie powinna dwracać wartości ujemnej!");
            }
            return wartość;
        }
        static void Main(string[] args)
        {
            try
            {
                int x = 1234;
                int y = kwadrat(x);
                y = kwadrat(y);
                string sy = y.ToString();
                Console.WriteLine(sy);
            }
            catch(Exception ex)
            {
                ConsoleColor bieżącyKolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Błąd: {ex.Message}");
                Console.ForegroundColor = bieżącyKolor;
            }
            
        }
    }
}