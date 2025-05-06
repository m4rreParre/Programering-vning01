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
            if(lengthIsAccepted)
            {
                for(int i = 0; i < list.GetLength(1); i++)
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

        static void Main(string[] args)
        {
            int output = AddRad(SumList, 1);
            Console.WriteLine(output);
        }
    }
}