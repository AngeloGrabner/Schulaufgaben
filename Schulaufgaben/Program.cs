using System;

namespace Program //link: https://github.com/AngeloGrabner/Schulaufgaben
{
    class Aufgaben
    {
    
        public static void Main()
        {
#pragma warning disable
            Console.WriteLine("geben sie einen text ein");
            string text = Console.ReadLine();
            Console.WriteLine("geben sie die anzahl der wiederholungen ein");
            int anzahl = int.Parse(Console.ReadLine());
            anzahl = ausgabeTextMalX(text, anzahl);
            Console.WriteLine("anzahl der zeichen: "+anzahl);
        }  
        
        public static int ausgabeTextMalX(string text, int wiederholungen)
        {
            for (int i = 0; i < wiederholungen; i++)
            {
                Console.WriteLine(text);
            }
            return text.Length*wiederholungen;
        }
    }
}