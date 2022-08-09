using System;

namespace opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lav et program, der giver 10 forsøg til at slå en sekser. Når en sekser, skal programmet standse.
            //De enkelte slag skal udskrives undervejs

            Random rnd = new Random();

            int roll = -1;
            bool six = false;

            System.Console.WriteLine("Du har 10 forsøg for at slå en 6'er. Tryk enter for at slå.");


            for(int i = 0; i < 11; i++)
            {
                System.Console.WriteLine($"Du har {10 - i} forsøg tilbage.");

                Console.ReadKey();

                roll = rnd.Next(1,6);

                System.Console.WriteLine($"Du har slået en {roll}.");

                if(roll == 6) break; six = true;
            }

            if(six) System.Console.WriteLine("Du har slaet en 6'er.");
            else System.Console.WriteLine("Uhelig! Du kunne ikke slå en 6'er i 10 forsøg.");


        }
    }
}
