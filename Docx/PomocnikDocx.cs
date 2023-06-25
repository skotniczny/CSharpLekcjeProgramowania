using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using Statystyka;
using System.Globalization;
using System.Reflection;

namespace Docx
{
    using static FormatowaniaDocx;
    public static class PomocnikDocx
    {
        private static Paragraph twórzAkapit(string[] linie, int rozmiarCzcionki, Color kolorCzcionki)
        {
            Paragraph akapit = new Paragraph();
            akapit.Append(UstawieniaAkapituZwiększonaInterlinia);
            Run ustęp = akapit.AppendChild(new Run());
            RunProperties stylAkapitu = StylUstępuNormalny;
            stylAkapitu.FontSize.Val = new StringValue(rozmiarCzcionki.ToString());
            stylAkapitu.Color = kolorCzcionki;
            ustęp.Append(stylAkapitu);
            foreach (string line in linie)
            {
                ustęp.AppendChild(new Text(line));
                ustęp.AppendChild(new Break());
            }
            return akapit;
        }

        private static Paragraph twórzAkapitTytułu(string tytuł)
        {
            Paragraph akapitTytułu = new Paragraph();
            Run ustępTytułu = akapitTytułu.AppendChild(new Run());
            ustępTytułu.Append(StylUstępuTytułu);
            ustępTytułu.Append(new Text(tytuł));
            return akapitTytułu;
        }

        private static void wyślijDokumentDoStrumienia(
            ParametryStatystyczneZHistogramem parametryStatystyczne,
            Stream stream, IFormatProvider formatProvider)
        {
            //tworzenie dokumentu Worda
            using (WordprocessingDocument dokumentWorda = WordprocessingDocument.Create(
                stream, WordprocessingDocumentType.Document, true))
            {
                MainDocumentPart głównaCzęścDokumentu = dokumentWorda.AddMainDocumentPart();
                głównaCzęścDokumentu.Document = new Document();

                Body ciałoDokumentu = new Body();
                głównaCzęścDokumentu.Document.AppendChild(ciałoDokumentu);

                // nagłówek
                string[] linieNagłówka = new string[]
                {
                    "e-mail: sklep@helion.pl",
                    "www.helion.pl",
                    "tel: +48 32 230 98 63, wewn: 121, 160, 188",
                    "fax: +48 32 333 92 56"
                };
                Paragraph akapitNagłówka = twórzAkapit(linieNagłówka, 18, KolorWyróżniony);
                ciałoDokumentu.AppendChild(akapitNagłówka);

                // tytuł
                ciałoDokumentu.AppendChild(twórzAkapitTytułu("Parametry statystyczne"));

                // akapit z tekstem
                string[] linie = parametryStatystyczne.ToString().Split('\n');
                Paragraph akapit = twórzAkapit(linie, 25, KolorNormalny);
                ciałoDokumentu.AppendChild(akapit);

                dokumentWorda.Close(); // zamknięcie dokumentu
            }
            stream.Flush();
        }

        public static void EksporujDoPlikuDocx(
            this ParametryStatystyczneZHistogramem parametryStatystyczne,
            string ścieżkaPliku, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null) formatProvider = new CultureInfo("pl-PL");
            if (File.Exists(ścieżkaPliku)) File.Delete(ścieżkaPliku);
            using (FileStream strumieńPliku = new FileStream(ścieżkaPliku, FileMode.CreateNew))
            {
                wyślijDokumentDoStrumienia(parametryStatystyczne, strumieńPliku, formatProvider);
                strumieńPliku.Close();
            }
        }
    }
}