using System;
using System.Collections.Generic;
namespace Program //link: https://github.com/AngeloGrabner/Schulaufgaben
{
    public struct HotelDaten
    {
        public int zimmernummer;
        public string nachname, vorname;
        public int übernachtungen;
        public float rechnung;
        public HotelDaten(int zimmernummer, string vorname, string nachname, int übernachtungen, float rechnung)
        {
            this.rechnung = rechnung;
            this.nachname = nachname;
            this.vorname = vorname;
            this.zimmernummer = zimmernummer;
            this.übernachtungen = übernachtungen;
        }
    }
    class Aufgaben
    {
        // data
        const string path = @"..\..\..\Data.txt";
        static List<HotelDaten> daten = new();
        static Dictionary<int, HotelDaten> byNumber = new();
        static Dictionary<string, HotelDaten> byName = new(); // redundance
        public static void Main()
        {
            SetupData();
            while (true)
            {
                Console.WriteLine("geben sie eine zimmernummer oder einen nachnamen ein");
                int inputZimmernummer = 0;
                string inputStr = @" ";
                inputStr = Console.ReadLine();
                if (inputStr == "stop"|| inputStr == "end")
                {
                    break;
                }
                bool flag = int.TryParse(inputStr, out inputZimmernummer);
                if (flag)
                {
                    (bool b, HotelDaten? hotelDaten) = GetData(inputZimmernummer);
                    if (b)
                    {        
                        Console.WriteLine($"Zimmernummer: {hotelDaten.Value.zimmernummer}, Vorname: {hotelDaten.Value.vorname}, Nachname: {hotelDaten.Value.nachname}, Übernachtungen: {hotelDaten.Value.übernachtungen}, Rechnung; {hotelDaten.Value.rechnung}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    (bool b, HotelDaten? hotelDaten) = GetData(inputStr);
                    if (b)
                    {
                        Console.WriteLine($"Zimmernummer: {hotelDaten.Value.zimmernummer}, Vorname: {hotelDaten.Value.vorname}, Nachname: {hotelDaten.Value.nachname}, Übernachtungen: {hotelDaten.Value.übernachtungen}, Rechnung; {hotelDaten.Value.rechnung}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            } 
        }
        static void SetupData()
        {
            HotelDaten temp = new HotelDaten();
            int first = 0;
            string[] fromFile = File.ReadAllLines(path);
            for (int i = 0; i < fromFile.Length; i++)
            {
                first = 0;
                for (int j = 0; j < fromFile[i].Length; j++)
                {
                    if (fromFile[i][j] == ';')
                    {
                        temp.zimmernummer = Convert.ToInt32(fromFile[i].Substring(first, j-first));
                        first = j + 1;
                    }
                    else if (fromFile[i][j] == '_')
                    {
                        temp.vorname = fromFile[i].Substring(first, j-first);
                        first = j + 1;
                    }
                    else if (fromFile[i][j] == '!')
                    {
                        temp.nachname = fromFile[i].Substring(first, j-first);
                        first = j +1;
                    }
                    else if (fromFile[i][j] == '|')
                    {
                        temp.übernachtungen = Convert.ToInt32(fromFile[i].Substring(first, j-first));
                        first = j + 1;
                    }
                    else if (fromFile[i][j] == '\n')
                    {
                        temp.rechnung = (float)Convert.ToDouble(fromFile[i].Substring(first, j-first));
                        first = j + 1;
                    }
                }
                daten.Add(temp);
            }
            for (int i = 0; i < daten.Count; i++)
            {
                byName.Add(daten[i].nachname, daten[i]);
                byNumber.Add(daten[i].zimmernummer,daten[i]);
            }
        }
        public static Tuple<bool, HotelDaten?>GetData(string nachname)
        {
            try
            {
                HotelDaten temp = byName[nachname];
                return new(true,temp);
            }
            catch
            {
                return new(false,null);
            }

        }
        public static Tuple<bool, HotelDaten?>GetData(int zimmernummer)
        {
            try
            {
                HotelDaten temp = byNumber[zimmernummer];
                return new(true, temp);
            }
            catch
            {
                return new(false, null);
            }
        }
    }
}