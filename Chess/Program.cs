using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            GoAhead();
        }

        private static void GoAhead()
        {
            string[] size = Console.ReadLine().Split(' ');
            int[,] field = new int[int.Parse(size[0]), int.Parse(size[1])];

            int whiteChs = int.Parse(Console.ReadLine());
            for (int i = 0; i < whiteChs; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                field[int.Parse(temp[0])-1, int.Parse(temp[1])-1] = 1;
            }
            
            int blackChs = int.Parse(Console.ReadLine());
            for (int i = 0; i < blackChs; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                field[int.Parse(temp[0])-1, int.Parse(temp[1])-1] = 2;
            }

            bool whiteMove = Console.ReadLine() == "white";
            bool canFight;

            if (whiteMove)
            {
                canFight = CheckMove(1, field);

            }
            else
            {
                canFight = CheckMove(2, field);
            }
            Console.WriteLine(canFight ? "Yes" : "No");
        }
        //i was here
        private static bool CheckMove(int x, int[,] field)
        {
                List<int[]> myIndexes = new List<int[]>();
                List<int[]> enemyIndexes = new List<int[]>();
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i, j] == x)
                        {
                            myIndexes.Add(new []{i, j});
                        }else if (field[i, j] == (x == 1 ? 2 : 1))
                        {
                            enemyIndexes.Add(new []{i, j});
                        }
                    }
                }

                foreach (var item in myIndexes)
                {
                    List<int[]> possible = new List<int[]>();
                    int[] RD = {-1, -1};
                    int[] RU = {-1, -1};
                    int[] LD = {-1, -1};
                    int[] LU = {-1, -1};
                    if (item[0] + 2 < field.GetLength(0) && item[1] + 2 < field.GetLength(1))
                    {
                       RD = new [] {item[0] + 1, item[1] + 1};
                       int[] lol = {item[0] + 2, item[1] + 2};
                       int counter = 0;
                       counter += myIndexes.Where(x => x.SequenceEqual(lol)).Count();
                       counter += enemyIndexes.Where(x => x.SequenceEqual(lol)).Count();
                       
                       if (counter == 0)
                           possible.Add(RD);
                    }

                    if (item[0] - 2 >= 0 && item[1] + 2 < field.GetLength(1))
                    {
                        LD = new [] {item[0] - 1, item[1] + 1};
                        int[] lol = {item[0] - 2, item[1] + 2};
                        int counter = 0;
                        counter += myIndexes.Where(x => x.SequenceEqual(lol)).Count();
                        counter += enemyIndexes.Where(x => x.SequenceEqual(lol)).Count();
                       
                        if (counter == 0)
                            possible.Add(LD);
                    }

                    if (item[0] - 2 >= 0 && item[1] - 2 >= 0)
                    {
                        LU = new [] {item[0] - 1, item[1] - 1};
                        int[] lol = {item[0] - 2, item[1] - 2};
                        int counter = 0;
                        counter += myIndexes.Where(x => x.SequenceEqual(lol)).Count();
                        counter += enemyIndexes.Where(x => x.SequenceEqual(lol)).Count();
                       
                        if (counter == 0)
                            possible.Add(LU);
                    }

                    if (item[0] + 2 < field.GetLength(0) && item[1] - 2 >= 0)
                    {
                        RU = new [] {item[0] + 1, item[1] - 1};
                        int[] lol = {item[0] + 2, item[1] - 2};
                        int counter = 0;
                        counter += myIndexes.Where(x => x.SequenceEqual(lol)).Count();
                        counter += enemyIndexes.Where(x => x.SequenceEqual(lol)).Count();
                       
                        if (counter == 0)
                            possible.Add(RU);
                    }

                    for (int i = 0; i < enemyIndexes.Count; i++)
                    {
                        // if(possible[j][0] == -1 && possible[j][1] == -1)
                        // {continue;}
                        for (int j = 0; j < possible.Count; j++)
                        {
                            if (possible[j][0] == enemyIndexes[i][0] && possible[j][1] == enemyIndexes[i][1])
                            {
                                return true;
                            }
                        }
                        
                    }
                    
                }

                return false;
        }
    }
}