using System;

namespace Matrix
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth =  Console.LargestWindowWidth;
            Console.CursorVisible = false;

            Console.SetCursorPosition(30, 40);
            //Console.Write("Dit wordt ergens op het scherm geschreven...");

            while (true)
            {
                

                // bepaal een random positie op het scherm
                //int x = rand.Next(Console.WindowWidth);
                //int y = rand.Next(Console.WindowHeight);

                // Schrijf een karakter (*) op de random positie
                //Console.SetCursorPosition(x, y);
                //Console.Write(AsciiCharacter);

                // Maak een array aan en vul deze met random hoogten
                int[] y = new int[Console.WindowWidth];
                for (int x = 0; x < Console.WindowWidth; ++x)
                    y[x] = rand.Next(Console.WindowHeight);

                while (true)
                    UpdateAllColumns(Console.WindowWidth, Console.WindowHeight, y);

            }
        }

        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            // update elke kolom
            for (int x = 0; x < width; ++x)
            {
                // Bepaal de kleur van de (onderste) karakters
                if (x % 10 == 1)
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                // Schrijf een willekeurig karakter op de random positie
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);

                // De rest van de regel (bovenste gedeelte) is donkergroen
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                if (temp < 0)
                    temp = temp + height;
                Console.SetCursorPosition(x, temp);
                Console.Write(AsciiCharacter);

                // wis het teken 20 posities 'terug'
                int wis_positie = y[x] - 20;
                if (wis_positie < 0)
                    wis_positie = wis_positie + height;
                Console.SetCursorPosition(x, wis_positie);
                Console.Write(' ');

                // Verhoog de hoogte (zodat de volgende leesteken lager komt)
                y[x]++;
                if (y[x] >= height)
                    y[x] = 0;
            }
        }



        static char AsciiCharacter
        {
            get {
                int t = rand.Next(10);
                if (t <= 2)
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    return (char)('A' + rand.Next(27));
                else
                    return (char)(rand.Next(32, 255));
            }
        }
    }
}
