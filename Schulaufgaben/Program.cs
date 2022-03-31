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
        const string path = @"Data.txt";
        static List<HotelDaten> daten = new();
        static Dictionary<int, HotelDaten> byNumber = new();
        static Dictionary<string, HotelDaten> byName = new();
        public static void Main()
        {
            //gui stuff
        }
        static void SetupData()
        {
            string[] fromFile = File.ReadAllLines(path);
            for (int i = 0, j = 0; i < fromFile.Length; i++)
            {
                while (from[i][j] !=)
                {
                    // get into the hoteldaten struct
                }
            }
        }
        public static Tuple<bool, HotelDaten>GetData(string nachname)
        {

            return null;
        }
        public static Tuple<bool, HotelDaten>GetData(int zimmernummer)
        {

            return null;
        }
    }
}