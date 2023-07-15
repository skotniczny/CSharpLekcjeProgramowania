namespace InformacjeOSystemie
{
    internal class Program
    {
        static string system = $"Wersja systemu: {Environment.OSVersion} " +
            (Environment.Is64BitOperatingSystem ? ", 64 bitowy" : "") +
            $"\nWersja Microsoft .NET Framework: {Environment.Version}" +
            $"\nNazwa komputera: {Environment.MachineName}" +
            $"\nKatalog systemowy: {Environment.SystemDirectory}";

        static string użytkownik = $"Nazwa użytkownika: {Environment.UserName}" +
            "\nKatalogi specjalne użytkownika:" +
            $"\nkatalog 'Moje dokumenty' = {Environment.GetFolderPath(Environment.SpecialFolder.Personal)}" +
            $"\nkatalog 'Pulpit' = {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" +
            $"\nkatalog 'Moje obrazy' = {Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}" +
            $"\nkatalog menu Start = {Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)}" +
            $"\nkatalog 'Programy' = {Environment.GetFolderPath(Environment.SpecialFolder.Programs)}" +
            $"\nkatalog 'Autostart' = {Environment.GetFolderPath(Environment.SpecialFolder.Startup)}" +
            $"\nkatalog domowy użytkownika = {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";

        static string zmienne
        {
            get
            {
                string s = "";
                System.Collections.ICollection zmienneŚrodowiskowe = Environment.GetEnvironmentVariables();
                foreach (System.Collections.DictionaryEntry zmienna in zmienneŚrodowiskowe)
                {
                    s += $"{zmienna.Key} = {zmienna.Value}\n";
                }
                return s;
            }
        }

        static string dyski
        {
            get
            {
                string s = "";
                System.IO.DriveInfo[] di = System.IO.DriveInfo.GetDrives();
                foreach (System.IO.DriveInfo dysk in di)
                {
                    if (dysk.IsReady)
                    {
                        float p = 1f * dysk.TotalFreeSpace / dysk.TotalSize;
                        s += dysk.Name + " " + dysk.VolumeLabel + " " + dysk.TotalFreeSpace + "/" + dysk.TotalSize + $" ({p:p0})\n";
                    }
                }
                return s;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Informacje o systemie:\n{system}");
            Console.WriteLine($"\nInformacje o użytkowniku:\n{użytkownik}");
            Console.WriteLine($"\nZmienne środowiskowe:\n{zmienne}");
            Console.WriteLine($"\nDyski:\n{dyski}");
        }
    }
}