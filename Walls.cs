using System;
using System.Collections.Generic;

namespace Project_Tetris_Game_v1
{
    public class Walls
    {
        private char point;
        private ConsoleColor color = ConsoleColor.White;
        private List<Position> walls = new List<Position>();
        public Walls(int x, int y, char point)
        {
            this.point = point;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0,y);
            DrawVertical(x,y+1);
        }

        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Position position = new Position(i, y, point,color);
                position.Draw(color);
                walls.Add(position);
            }
        }

        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Position position = new Position(x, i, point,color);
                position.Draw(color);
                walls.Add(position);
            }
        }

        public bool IsWall(Position position)
        {
            foreach (Position wall in walls)
            {
                if (position == wall)
                {
                    return true;
                }
            }

            return false;
        }
    }
}