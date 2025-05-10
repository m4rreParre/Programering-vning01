using System;
using System.Linq;

namespace Practice02
{
    class Program
    {
        static public int[,] SumList = new int[,]
        {
            {5, 5, 5, 4}, //adds up to 19
            {8, 6, 2, 4}, //adds up to 20
            {5, 1, 2, 5}, //adds up to 13
            {4, 5, 4, 6}, //adds up to 19
            {4, 4, 4, 4}, //adds up to 16
        };

/*Slumpmässigt generera en 2dim-array med viss x-längd, y-längd, och max-tal*/
        static Random rng = new Random();
        static int[,] generateRngArray(int xLenght, int yLenght, int n)
        {
            int[,] rngArray = new int[xLenght, yLenght];
            for (int y = 0; y < rngArray.GetLength(0); y++)
            {
                for (int x = 0; x < rngArray.GetLength(1); x++)
                {
                    rngArray[y, x] = rng.Next(n);
                }
            }
            return rngArray;
        }
        /*Skriv ut en viss 2dim-array*/
        static void writeArray(int[,] inputArray)
        {
            for (int y = 0; y < inputArray.GetLength(0); y++)
            {
                for (int x = 0; x < inputArray.GetLength(1); x++)
                {
                    Console.Write($"{inputArray[y, x]},");
                }
                Console.WriteLine();
            }
        }


        static int AddRad(int[,] list, int n)
        {
            n--;
            bool lengthIsAccepted = n >= 0 && n < list.GetLength(0);
            int sum = 0;
            if (lengthIsAccepted)
            {
                for (int i = 0; i < list.GetLength(1); i++)
                {
                    sum += list[n, i];
                }
                return sum;
            }
            else
            {
                return -1;
            }
        }

        /*
        Skapa en tvådimensionell algoritm som räknar upp alla tal på n rader.
        Exempel:
        1
        2 3
        4 5 6
        7 8 9 10


        Parametrar: n (int)
        Returtyp: void
        */
        static void triangleCounter(int n)
        {
            int currentNumber = 1;
            int rowLenght = 1;
            while (currentNumber <= n)
            {
                for (int i = 0; i < rowLenght && currentNumber <= n; i++)
                {
                    Console.Write(currentNumber + " ");
                    currentNumber++;
                }
                rowLenght++;
                Console.WriteLine();
            }
        }

        /*
        Skapa en algoritm som kollar ifall talet n finns i en tvådimensionell array. Då ska den 
        returnera index för talet, annars -1, -1.

        Parametrar: inputArray (int[,]), n (int)
        Returtyp: x (int), y (int)*/

        static Cordinate CordinateFind(int[,] inputArray, int n)
        {
            for (int x = 0; x < inputArray.GetLength(0); x++)
            {
                for (int y = 0; y < inputArray.GetLength(1); y++)
                {
                    if (n == inputArray[x, y])
                    {
                        Cordinate coord;
                        coord.x = x;
                        coord.y = y;
                        return coord;
                    }
                }
            }

            {
                Cordinate coord;
                coord.x = -1;
                coord.y = -1;
                return coord;
            }
        }
        static int[,] twoDimArray = new int[,]
        {
            {1, 2, 3,},
            {4, 5, 6,},
            {5, 55, 1001}

        };
        static void Main(string[] args)
        {
            // int output = AddRad(SumList, -3);
            // Console.WriteLine(output);
            while (true)
            {
                Console.WriteLine("Skriv in vad för typ av array du vill ha !");
                Console.WriteLine("O.B.S tar bara in siffor!");
                Console.WriteLine("syntax: <x-längd> <y-längd> <max-tal i arrayen>");
                Console.Write("> ");
                string[] token = Console.ReadLine().ToLower().Trim().Split(' ');
                if(token.Length != 3 || token.Length > 3)
                {
                    Console.WriteLine("fel syntax skriv in 3 tal");
                    continue;
                }
                int[,] GeneratedArray = generateRngArray(int.Parse(token[1]), int.Parse(token[0]), int.Parse(token[2]));
                writeArray(GeneratedArray);

            }




        }
    }
}