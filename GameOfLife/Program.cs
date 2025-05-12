using System;
using System.Drawing;

namespace GameOfLife
{
    internal class Program
    {
        static int res = 800;
        static int width = res / 35;
        static int height = res / 35;

        static int[,] make2DArray(int cols, int rows)
        {
            int[,] arr = new int[cols, rows];
            return arr;
        }
        static void initializeArray(int[,] arr)
        {
            Random rng = new Random();
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    arr[x, y] = rng.Next(2);
                }
            }
        }
        static void draw(int[,] arr)
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (arr[x, y] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(arr[x, y] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(arr[x, y] + " ");
                        Console.ResetColor();
                    }


                }
                Console.WriteLine();
            }
        }
        static int countNeighbors(int[,] grid, int x, int y)
        {
            int sum = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    //wrap around with modulo formula - eftersom
                    // if x = 0 och i = -1 och height är 10 så blir det 10 -1 = 9
                    // 9 modulo height som är 10 = 9 så wrappar till slutet annars tar width och % widh ut varandra
                    int col = (x + i + width) % width;
                    int row = (y + j + height) % height;
                    sum += grid[col, row];
                }
            }
            sum -= grid[x, y];
            return sum;
        }
        static void Main(string[] args)
        {
            int[,] grid = make2DArray(width, height);

            initializeArray(grid);
            //Process next based on grid
            bool isRunning = true;
            while (isRunning)
            {
                draw(grid);
                int[,] next = make2DArray(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int sum = 0;
                        int neighbors = countNeighbors(grid, i, j);
                        int state = grid[i, j];
                        if (state == 0 && neighbors == 3)
                        {
                            next[i, j] = 1;
                        }
                        else if (state == 1 && (neighbors < 2 || neighbors > 3))
                        {
                            next[i, j] = 0;
                        }
                        else
                        {
                            next[i, j] = grid[i, j];
                        }
                    }
                }
                System.Threading.Thread.Sleep(80);
                Console.Clear();
                grid = next;
            }

        }
    }
}