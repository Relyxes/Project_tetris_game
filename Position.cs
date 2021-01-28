using System;

namespace Project_Tetris_Game_v1
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Point { get; set; }

        readonly ConsoleColor[] _colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
        private ConsoleColor Color { get; }

        public Position(int x, int y, char point, ConsoleColor color)
        {
            X = x+10;
            Y = y+11;
            Point = point;
            Color = color;
        }
        public Position(int x, int y)
        {
            X = x+10;
            Y = y+11;
        }
        public void Draw(ConsoleColor pointColor)
        {
            foreach (var color in _colors)
            {
                if (color.Equals(pointColor))
                {
                    Console.ForegroundColor = color;
                }
            }

            Console.SetCursorPosition(X, Y);
            Console.Write(Point);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public static void ClearAll()
        {
            for (int i = 12; i < 26; i++)
            {
                for (int j = 11; j < 29; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(' ');
                }
            }

        }
    }
}