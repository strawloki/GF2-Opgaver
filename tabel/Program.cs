using System;

namespace tabel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lav et program, der udskriver hele den lille tabel, pænt formateret på skærmen.
            //fra 1 x 1 til 10 x 10
            //1  2  3  4  5  6  7  8  9  10
            //2  4  6  8  10 12 14 16 18 20
            //3  6  9  12 15 18 21 24 27 30


            int rows, columns;

            Random rand = new Random();
            Console.Write("Indtast raekker: ");

            rows = Int32.Parse(Console.ReadLine());

            Console.Write("\nIndtast kolonner: ");

            columns = Int32.Parse(Console.ReadLine());

            int[,] array = new int[rows,columns]; 

            

            for(int i = 0; i <= rows - 1; i++) //3 x 5
            {
                for(int k = 0; k <= columns - 1; k++)
                {
                    
                    array[i,k] = rand.Next(1,100);

                }
            }

            


            for(int o = 0; o <= rows - 1; o++)
            {

                for(int k = 0; k < columns; k++)
                {
                    
                    if(k == columns - 1){

                        Console.Write($"{array[o,k]}\t");
                        Console.Write("\n");
                        
                        //Console.Write("\n");
                        
                    } 
                    else Console.Write($"{array[o,k]}\t");
                    

                    
                } 

                 //write first row
            }


        }
    }
}
