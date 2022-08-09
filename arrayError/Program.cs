using System;

namespace arrayError
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lav et program, der indeholder nogle faste fejlmeddelelser
            //Lav en do-while løkke, som spørg brugeren om et fejlnummer og udskriv herefter den tilhørende fejlmeddelelse
            
            int[] errorNum = new int[3] {0, 1, 2};

            string[] errorMsg = new string[3] {
                    "Error 1",
                    "Error 2",
                    "Error 3",
                    
            };

            do
            {
                System.Console.WriteLine("Indast en tal: ");

                int input = Int32.Parse(Console.ReadLine()) - 1;

                if(input > errorNum.Length || input < 0){
                    System.Console.WriteLine("Dit tal er for stort! Prov igen: ");
                    continue;
                }

                Console.WriteLine($"{errorMsg[input]}");
            }
            while(true);
        }
    }
}
