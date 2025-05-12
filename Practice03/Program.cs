using System;
using System.IO;

namespace Practice03
{
    internal class Program
    {
        static int[,] Array2d = new int[,]
        {
            {18, 6, 22},
            {4,  42, 4},
            {12, 32, 2},
            {1,  33, 0}
        };
        static int[] ints = new int[]
        {
            4,3,1,6,8,9,3,1,2,7
        };
        static int[,] sort2dArray(int[,] inputArray)
        {
            //make 2d array to a 1d array
            int cols = inputArray.GetLength(1);
            int rows = inputArray.GetLength(0);
            int fullLenght = rows * cols;
            int[] arr = new int[fullLenght];

            int z = 0;
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    arr[z++] = inputArray[x, y];
                }
            }
            int j = 0;
            //send it to BubbleSortArray
            int[] sortedArray = bubbleSortArray(arr);
            //Input the sorted 1d array into a 2d array
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    inputArray[x, y] = arr[j++];
                }
            }
            //send back the 2d array
            return inputArray;
        }
        static int[] bubbleSortArray(int[] arr)
        {
            for (int i = arr.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        static void writeArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }
        static void write2dArray(int[,] arr)
        {
            int cols = arr.GetLength(1);
            int rows = arr.GetLength(0);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Console.Write(arr[y, x] + ", ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("not sorted Array:");
            write2dArray(Array2d);
            int[,] sorted2dArray = sort2dArray(Array2d);
            Console.WriteLine("sorted Array:");
            Console.WriteLine("================");
            write2dArray(sorted2dArray);
        }
    }
}