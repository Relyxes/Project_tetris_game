using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Project_Tetris_Game_v1
{
    public class Title
    {
        private char[,] _title;
        private int Height = 11;
        private int Length = 44;

        private int[][] char_T =
        {
            new[] {3, 4, 5, 6, 7},
            new[] {3, 4, 5, 6, 7}
        };

        private int[][] char_E =
        {
            new[] {10, 11, 12, 13, 14},
            new[] {3, 4, 5, 6, 7}
        };

        private int[][] char_T2 =
        {
            new[] {17, 18, 19, 20, 21},
            new[] {3, 4, 5, 6, 7}
        };

        private int[][] char_R =
        {
            new[] {24, 25, 26, 27, 28},
            new[] {3,4,5,6,7}
        };

        private int[][] char_I =
        {
            new[] {31, 32, 33},
            new[] {3,4,5,6,7}
        };

        private int[][] char_S =
        {
            new[] {36, 37, 38, 39, 40},
            new[] {3, 4, 5, 6, 7}
        };

        Dictionary<char, int[][]> title_Char = new Dictionary<char, int[][]>()
        {
            {
                'T', new[]
                {
                    new[] {3, 5},
                    new[] {5, 5}
                }
            }
        };

        public Title()
        {
        }

        public Title(int heigth, int length)
        {
            Height = heigth;
            Length = length;
        }

        private void CreateTitle(int height, int length)
        {
            _title = new char[height, length];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (char_T[0].Contains(i) && char_T[1][0].Equals(j) ||
                        char_T[0][2].Equals(i) && char_T[1].Contains(j) ||

                        char_E[0].Contains(i) && char_E[1][0].Equals(j) ||
                        char_E[0].Contains(i) && char_E[1][2].Equals(j) ||
                        char_E[0].Contains(i) && char_E[1][4].Equals(j) ||
                        char_E[0][0].Equals(i) && char_E[1].Contains(j) ||

                        char_T2[0].Contains(i) && char_T2[1][0].Equals(j) ||
                        char_T2[0][2].Equals(i) && char_T2[1].Contains(j) ||

                        char_R[0].Contains(i) && char_R[1][0].Equals(j) ||
                        char_R[0][0].Equals(i) && char_R[1].Contains(j) ||
                        char_R[0].Contains(i) && char_R[1][2].Equals(j) ||
                        char_R[0][4].Equals(i) && char_R[1][1].Equals(j) ||
                        char_R[0][3].Equals(i) && char_R[1][3].Equals(j) ||
                        char_R[0][4].Equals(i) && char_R[1][4].Equals(j) ||

                        char_I[0].Contains(i) && char_I[1][0].Equals(j) ||
                        char_I[0][1].Equals(i) && char_I[1].Contains(j) ||
                        char_I[0].Contains(i) && char_I[1][4].Equals(j) ||

                        char_S[0].Contains(i) && char_S[1][0].Equals(j) ||
                        char_S[0].Contains(i) && char_S[1][2].Equals(j) ||
                        char_S[0].Contains(i) && char_S[1][4].Equals(j) ||
                        char_S[0][0].Equals(i) && char_S[1][1].Equals(j) ||
                        char_S[0][4].Equals(i) && char_S[1][3].Equals(j) ||

                        i == 0 || i == Length-1 || j == 0 || j == Height-1)
                    {
                        _title[i, j] = '#';
                    }
                    else
                    {
                        _title[i, j] = ' ';
                    }
                }
            }
        }

        public void ShowTitle()
        {
            CreateTitle(Length, Height);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write(_title[j, i]);
                    Thread.Sleep(1);
                }

                Console.WriteLine();
            }
        }


    }
}