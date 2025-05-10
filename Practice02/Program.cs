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
                Console.WriteLine("what are you searching for ?");
                Console.Write("> ");
                int userInput = int.Parse(Console.ReadLine());
                Cordinate returnedCordinate = CordinateFind(twoDimArray, userInput);
                Console.WriteLine(returnedCordinate.y + ", " + returnedCordinate.x );
            }

            
        }
    }
}