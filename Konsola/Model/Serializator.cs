﻿using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Konsola.Model
{
    public static class Serializacja
    {
        public static void ZapiszXml(this UstawieniaKonsoli ustawienia, string ścieżkaPliku)
        {
            StreamWriter strumień = new StreamWriter(ścieżkaPliku);
            try
            {
                XmlSerializer serializator = new XmlSerializer(typeof(UstawieniaKonsoli));
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add("", "");
                serializator.Serialize(strumień, ustawienia, xmlns);
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine($"Błąd {exc.Message}");
            }
            finally
            {
                strumień.Close();
            }
        }

        public static UstawieniaKonsoli CzytajXml(string ścieżkaPliku)
        {
            StreamReader reader = new StreamReader(ścieżkaPliku);
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(UstawieniaKonsoli));
                UstawieniaKonsoli ustawienia = (UstawieniaKonsoli)ser.Deserialize(reader);
                return ustawienia;
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine($"Błąd: {exc.Message}");
                return PomocnikUstawieńKonsoli.UstawieniaDomyślne;
            }
            finally
            {
                reader.Close();
            }
        }

        public static void ZapiszJson(this UstawieniaKonsoli ustawiania, string ścieżkaPliku)
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonText = JsonSerializer.Serialize(ustawiania, jsonOptions);
            File.WriteAllText(ścieżkaPliku, jsonText);
        }

        public static UstawieniaKonsoli CzytajJson(string ścieżkaPliku)
        {
            string jsonText = File.ReadAllText(ścieżkaPliku);
            UstawieniaKonsoli ustawienia = JsonSerializer.Deserialize<UstawieniaKonsoli>(jsonText);
            return ustawienia;
        }
    }
}
