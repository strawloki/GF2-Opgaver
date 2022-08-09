using System;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lav et program, som indlæser 7 nedbørsmængder fra brugeren og beregner gennemsnitet til sidst
            //2.    Programmet skal ud over gennemsnittet, udskrive minimum og maksimum nedbørsværdi
            //3.    Der skal kunne angives decimaltal


            double[] array = new double[7];
            double parse;

            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Indast tal {i}:");

                parse = Double.Parse(Console.ReadLine());
                array[i] = parse;
            } 


            //avereage
            double total = 0;

            foreach(double num in array)
            {
                total += num;
            }

            double avereage = total / array.Length;

            //min & max value

            double maxValue = 0;
            for(int k = 0; k < array.Length; k++) 
            {
                if(array[k] > maxValue) maxValue = array[k];
            }

            double minValue = array[0];

            for(int p = 0; p < array.Length; p++)//3,6,2,8,1,0
            {
                if(array[p] < minValue) minValue = array[p];
            }

            System.Console.WriteLine($"Avereage: {avereage.ToString()}\nMax Value: {maxValue.ToString()}\nMin Value: {minValue.ToString()}");
        }
    }
}
