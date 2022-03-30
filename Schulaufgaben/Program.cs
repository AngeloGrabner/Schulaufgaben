using System;

namespace Program //link: https://github.com/AngeloGrabner/Schulaufgaben
{
    class Aufgaben
    {
    
        public static void Main()
        {
            int anzahl = 0;
            anzahl = ausgabeTextMalX("das ist sehr schwer", 10);
            Console.WriteLine("anzahl der wiederholungen: "+anzahl);
        }  
        
        public static int ausgabeTextMalX(string text, int wiederholungen)
        {
            for (int i = 0; i < wiederholungen; i++)
            {
                Console.WriteLine(text);
            }
            return text.Length;
        }
    }
}