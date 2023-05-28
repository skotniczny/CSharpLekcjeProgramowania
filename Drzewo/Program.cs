using System.Xml.Linq;

namespace Drzewo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("ustawienia.xml");
            Węzeł drzewo = xml.TwórzDrzewo();
            drzewo.Wyświetl();
        }
    }
}