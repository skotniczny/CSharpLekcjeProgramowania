namespace Docx
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Wordprocessing;

    public class FormatowaniaDocx
    {
        private const int rozmiarCzcionkiNormalny = 21;
        private const int rozmiarCzcionkiTytułu = 48;
        private const string kształtCzcionki = "Arial";

        // własności muszą zwracać za każdym razem nowe obiekty,
        // bo nie można uzywać obiektów, które już są częścią drzewa
        public static Color KolorWyróżniony => new Color() { Val = "203A8F" };
        public static Color KolorNormalny => new Color() { Val = "black" };
        public static RunFonts CzcionkaNormalna => new RunFonts() { Ascii = kształtCzcionki, HighAnsi = kształtCzcionki };
        public static RunProperties StylUstępuNormalny => new RunProperties
        {
            RunFonts = CzcionkaNormalna,
            FontSize = new FontSize() { Val = new StringValue(rozmiarCzcionkiNormalny.ToString()) },
            Color = KolorNormalny
        };
        public static RunProperties StylUstępuTytułu => new RunProperties
        {
            Bold = new Bold() { Val = OnOffValue.FromBoolean(true) },
            FontSize = new FontSize() { Val = new StringValue(rozmiarCzcionkiTytułu.ToString()) },
            RunFonts = CzcionkaNormalna,
            Color = KolorWyróżniony
        };
        public static ParagraphProperties UstawieniaAkapituZwiększonaInterlinia
        {
            get
            {
                ParagraphProperties paragraphProperties = new ParagraphProperties();
                // interlina 1.5 dla czcionki 12
                paragraphProperties.Append(new SpacingBetweenLines() { Line = "360" });
                return paragraphProperties;
            }
        }
    }
}