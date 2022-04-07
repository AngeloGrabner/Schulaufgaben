using System;
using System.Collections.Generic;
namespace Program //link: https://github.com/AngeloGrabner/Schulaufgaben
{

    public struct HotelDaten
    {
        public string zimmernummer; // we'll use string instead of int 
        public string nachname, vorname;
        public int übernachtungen;
        public float rechnung;
        public HotelDaten(string zimmernummer, string vorname, string nachname, int übernachtungen, float rechnung)
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
        //yes that is a bit useless

        static Dictionary<string, HotelDaten> byNumber = new();
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
                    (bool b, List<HotelDaten>? hotelDaten) = GetData(inputZimmernummer);
                    if (b)
                    {     
                        for (int i = 0; i < hotelDaten.Count; i++)
                        Console.WriteLine($"Zimmernummer: {hotelDaten[i].zimmernummer}, Vorname: {hotelDaten[i].vorname}, Nachname: {hotelDaten[i].nachname}, Übernachtungen: {hotelDaten[i].übernachtungen}, Rechnung; {hotelDaten[i].rechnung}");
                    }
                    else
                    {
                        Console.WriteLine("error, die zimmernummer konnte nicht gefunden werden");
                    }
                }
                else
                {
                    (bool b, List<HotelDaten>? hotelDaten) = GetData(inputStr);
                    if (b)
                    {
                        for (int i = 0; i < hotelDaten.Count; i++)
                        Console.WriteLine($"Zimmernummer: {hotelDaten[i].zimmernummer}, Vorname: {hotelDaten[i].vorname}, Nachname: {hotelDaten[i].nachname}, Übernachtungen: {hotelDaten[i].übernachtungen}, Rechnung; {hotelDaten[i].rechnung}");
                    }
                    else
                    {
                        Console.WriteLine("error, der name konnte nicht gefunden werden");
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
                        temp.zimmernummer = fromFile[i].Substring(first, j-first);
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
                        temp.rechnung = (float)Convert.ToDouble(fromFile[i].Substring(first, fromFile[i].Length - first));
                    }
                    
                   
 
                    
                }
                daten.Add(temp);
            }
            for (int i = 0; i < daten.Count; i++) // the following is patch work
            {
                try
                {
                    byName.Add(daten[i].nachname, daten[i]);
                }
                catch(ArgumentException)
                {
                    HandleDupes.add(daten[i].nachname, false);
                    byName.Add(daten[i].nachname +"_D"+HandleDupes.getDupesOf(daten[i].nachname, false),daten[i]);
                }
                try
                {
                    byNumber.Add(daten[i].zimmernummer, daten[i]);
                }
                catch (ArgumentException)
                {
                    HandleDupes.add(daten[i].zimmernummer, true);
                    byNumber.Add(daten[i].zimmernummer + "_D" + HandleDupes.getDupesOf(daten[i].zimmernummer, true),daten[i]);
                }
            }
        }
        public static Tuple<bool, List<HotelDaten>?>GetData(string nachname)
        {
            try
            {
                List<HotelDaten>? temp = new();
                temp.Add(byName[nachname]);
                int amountOfDupes = HandleDupes.getDupesOf(nachname, false);
                if (amountOfDupes != -1)
                {
                    for (int i = 1; i <= amountOfDupes; i++)
                    {
                        temp.Add(byName[nachname+"_D"+i]);
                    }
                }
                return new(true,temp);
            }
            catch
            {
                return new(false,null);
            }

        }
        public static Tuple<bool, List<HotelDaten>?>GetData(int zimmernummer)
        {
            try
            {
                HandleDupes.getDupesOf(zimmernummer.ToString(), true);
                List<HotelDaten>? temp = new();
                temp.Add(byNumber[zimmernummer.ToString()]);
                int amountOfDupes = HandleDupes.getDupesOf(zimmernummer.ToString(), true);
                if (amountOfDupes != -1)
                {
                    for (int i = 1; i <= amountOfDupes; i++)
                    {
                        temp.Add(byNumber[zimmernummer + "_D" + i]);
                    }
                }
                return new(true, temp);
            }
            catch
            {
                return new(false, null);
            }
        }
    }
}