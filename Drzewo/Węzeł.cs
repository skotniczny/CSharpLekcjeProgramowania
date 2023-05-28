using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drzewo
{
    public class Węzeł
    {
        public string Nazwa = null;
        public string Wartość = null;
        public List<Węzeł> Węzły = new List<Węzeł>();

        public override string ToString()
        {
            return $"{Nazwa} {((Wartość != null) ? ($": {Wartość}") : "")}";
        }
    }
    public static class DrzewoXml
    {
        private static void dodajWęzeł(XElement elementXml, Węzeł węzeł)
        {
            IEnumerable<XElement> elementy = elementXml.Elements();
            foreach (XElement element in elementy)
            {
                string nazwaWęzła = element.Name.LocalName;
                string wartośćWęzła = null;
                if (!element.HasElements && !string.IsNullOrEmpty(element.Value))
                {
                    wartośćWęzła += element.Value;
                }
                Węzeł nowyWęzeł = new Węzeł()
                {
                    Nazwa = nazwaWęzła,
                    Wartość = wartośćWęzła,
                };
                węzeł.Węzły.Add(nowyWęzeł);
                dodajWęzeł(element, nowyWęzeł);
            }
        }

        public static Węzeł TwórzDrzewo(this XDocument xml)
        {
            Węzeł drzewo = new Węzeł()
            {
                Nazwa = xml.Root.Name.LocalName,
            };
            dodajWęzeł(xml.Root, drzewo);
            return drzewo;
        }
    }
}
