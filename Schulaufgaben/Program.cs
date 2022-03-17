﻿using System;

namespace Porgram
{
    class Aufgaben
    {
        public static int[] zahlen = { 19, 17, 13, 30, 40, 50, 60, 70, 80, 90 };
        public static void aufgabe11_1_1() // 1
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.Write(zahlen[i]+ "\t");
            }
        }
        public static int[] aufgabe11_1_2(int[] input) // 2
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i]*input[i];
            }
            return input;
        }
        public static int[] aufgabe11_1_3(int[] input) // ´3
        {
            int temp = input[0];
            for (int i = 1;i < input.Length; i++)
            {
                input[i - 1] = input[i];
            }
            input[input.Length-1] = temp;
            return input;
        }
        public static int[] aufgabe11_1_4(int[] input) // 4
        {
            Console.Write("geben sie einene index ein: ");
            int pos = Convert.ToInt32(Console.ReadLine());

            int temp = input[pos];
            for (int i = 1; i < input.Length; i++)
            {
                input[i - 1] = input[i];
            }
            input[input.Length - 1] = 1;
            return input;
        }
        public static void Main()
        {
            aufgabe11_1_1();
            Console.ReadLine();
        }   
    }
}