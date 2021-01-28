using System;

namespace Project_Tetris_Game_v1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Title title = new Title();
            title.ShowTitle();
            Console.WriteLine();
            Console.CursorVisible = false;


            while (Game._isStart)
            {
                Game game = new Game();
                game.Start();
            }

            Console.Read();
        }
    }
}