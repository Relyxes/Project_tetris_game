using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Tetris_Game_v1
{
    public class Block
    {
        public List<Position> block;
        public List<Position> blocks = new List<Position>();

        public Dictionary<string, bool> blocksType = new Dictionary<string, bool>
        {
            {"cube", false},
            {"plate", false},
            {"Z", false},
            {"L", false}
        };

        private int step = 1;
        public Action _action;
        private ConsoleColor Color;
        private bool _rotate;
        private string _isWall;
        private bool isBlock;
        private bool isLine = false;
        private bool isAction = true;
        Random _random = new Random();

        private int Col;
        private int Row;
        private int numLines = 26;
        private char Point = '*';
        private int _pushCount;
        private int countRotate = 0;
        int sumLine = 0;

        public Block(int x, int y, char point, ConsoleColor color)
        {
            Col = x;
            Row = y;
            Color = color;
            Point = point;
        }

        public void CreateBlock()
        {
            block = new List<Position>();
            int value = _random.Next(0, 4);
            isBlock = false;
            _rotate = false;
            countRotate = 0;
            //int value = 1;

            Position position;

            switch (value)
            {
                case 0:
                    blocksType["cube"] = true;
                    blocksType["plate"] = false;
                    blocksType["Z"] = false;
                    blocksType["L"] = false;
                    for (int col = Col; col < Col + 2; col++)
                    {
                        for (int row = Row; row < Row + 2; row++)
                        {
                            position = new Position(col, row, Point, Color);
                            block.Add(position);
                            position.Draw(Color);
                        }
                    }

                    break;
                case 1:
                    blocksType["plate"] = true;
                    blocksType["cube"] = false;
                    blocksType["Z"] = false;
                    blocksType["L"] = false;
                    for (int col = Col; col < Col + 4; col++)
                    {
                        for (int row = Row; row < Row + 1; row++)
                        {
                            position = new Position(col, row, Point, Color);
                            block.Add(position);
                            position.Draw(Color);
                        }
                    }

                    break;
                case 2:
                    blocksType["plate"] = false;
                    blocksType["cube"] = false;
                    blocksType["Z"] = true;
                    blocksType["L"] = false;
                    for (int col = Col; col < Col + 2; col++)
                    {
                        for (int row = Row; row < Row + 2; row++)
                        {
                            if (row > 1)
                            {
                                position = new Position(col + 1, row, Point, Color);
                            }
                            else
                            {
                                position = new Position(col, row, Point, Color);
                            }

                            block.Add(position);
                            position.Draw(Color);
                        }
                    }

                    break;
                case 3:
                    blocksType["plate"] = false;
                    blocksType["cube"] = false;
                    blocksType["Z"] = false;
                    blocksType["L"] = true;
                    for (int col = Col; col < Col + 3; col++)
                    {
                        for (int row = Row; row < Row + 2; row++)
                        {
                            position = new Position(col, row, Point, Color);

                            if (row == 2 && col == 10 || row == 1)
                            {
                                block.Add(position);
                                position.Draw(Color);
                            }
                        }
                    }

                    break;
            }
        }

        public Position GetLastBlockPosition() => block.Last();
        public Position GetFirstBlockPosition() => block.First();


        public void Rotate()
        {
            switch (_action)
            {
                case Action.RIGTH:
                    for (int col = 3; col >= 0; col--)
                    {
                        block[col].Clear();
                        block[col].X += 1;
                        block[col].Draw(Color);
                    }

                    break;
                case Action.LEFT:
                    for (int col = 0; col < 4; col++)
                    {
                        block[col].Clear();
                        block[col].X -= 1;
                        block[col].Draw(Color);
                    }

                    break;
                case Action.ROTATE:
                    _rotate = !_rotate;

                    for (int i = 0; i < 4; i++)
                    {
                        if (blocksType["plate"] && _rotate)
                        {
                            block[i].Clear();
                            block[i].X = block[0].X;
                            block[i].Y -= i;
                            block[i].Draw(Color);
                        }
                        else if (!blocksType["cube"] && !blocksType["Z"] && !blocksType["L"])
                        {
                            block[i].Clear();
                            block[i].Y = block[0].Y;
                            block[i].X += i;
                            block[i].Draw(Color);
                        }

                        if (blocksType["Z"] && _rotate && countRotate == 0)
                        {
                            countRotate++;
                            block[2].Clear();
                            block[2].X -= 1;
                            block[2].Y += 1;
                            block[2].Draw(Color);
                            block[3].Clear();
                            block[3].X -= 1;
                            block[3].Y += 1;
                            block[3].Draw(Color);
                            _rotate = false;
                        }
                        else if (blocksType["Z"] && _rotate && countRotate == 1)
                        {
                            countRotate++;
                            block[0].Clear();
                            block[0].X += 2;
                            block[0].Draw(Color);
                            block[3].Clear();
                            block[3].Y -= 2;
                            block[3].Draw(Color);
                            _rotate = false;
                        }

                        else if (blocksType["Z"] && _rotate && countRotate == 2)
                        {
                            countRotate++;
                            block[2].Clear();
                            block[2].X += 1;
                            block[2].Y += 1;
                            block[2].Draw(Color);
                            block[3].Clear();
                            block[3].X += 1;
                            block[3].Y += 1;
                            block[3].Draw(Color);
                            _rotate = false;
                        }
                        else if (blocksType["Z"] && _rotate && countRotate == 3)
                        {
                            countRotate = 0;
                            block[1].Clear();
                            block[1].X += 2;
                            block[1].Draw(Color);
                            block[2].Clear();
                            block[2].X += 2;
                            block[2].Y -= 2;
                            block[2].Draw(Color);
                            block[3].X += 2;
                            block[2].Draw(Color);
                            _rotate = false;
                        }

                        if (blocksType["L"] && _rotate && countRotate == 0)
                        {
                            countRotate++;
                            block[0].Clear();
                            block[0].X += 2;
                            block[0].Y -= 1;
                            block[0].Draw(Color);
                            block[1].Clear();
                            block[1].Y += 1;
                            block[1].Draw(Color);
                            _rotate = false;
                        }
                        else if (blocksType["L"] && _rotate && countRotate == 1)
                        {
                            countRotate++;
                            block[1].Clear();
                            block[1].X += 2;
                            block[1].Y -= 1;
                            block[1].Draw(Color);
                            block[3].Clear();
                            block[3].X += 2;
                            block[3].Y -= 1;
                            block[3].Draw(Color);
                            _rotate = false;
                        }
                        else if (blocksType["L"] && _rotate && countRotate == 2)
                        {
                            countRotate++;
                            block[1].Clear();
                            block[1].Y -= 1;
                            block[1].Draw(Color);
                            block[3].Clear();
                            block[3].X -= 2;
                            block[3].Y += 1;
                            block[3].Draw(Color);
                            _rotate = false;
                        }
                        else if (blocksType["L"] && _rotate && countRotate == 3)
                        {
                            countRotate = 0;
                            block[2].Clear();
                            block[2].X += 2;
                            block[2].Y -= 1;
                            block[2].Draw(Color);
                            block[3].Clear();
                            block[3].X += 2;
                            block[3].Y -= 1;
                            block[3].Draw(Color);
                            _rotate = false;
                        }
                    }

                    break;
            }
        }

        public void MoveDown()
        {
            for (int row = 0; row < 4; row++)
            {
                if (blocksType["cube"])
                {
                    if (row == 0 || row == 2)
                    {
                        block[row].Clear();
                    }

                    block[row].Y += 1;
                    block[row].Draw(Color);
                }
                else if (blocksType["plate"])
                {
                    block[row].Clear();
                    block[row].Y += 1;
                    block[row].Draw(Color);
                }
                else if (blocksType["Z"])
                {
                    if ((row == 0 || row == 2 || row == 3) && !_rotate && (countRotate == 0 || countRotate == 2))
                    {
                        block[row].Clear();
                    }
                    else if ((row == 0 || row == 1) && !_rotate && countRotate == 1)
                    {
                        block[row].Clear();
                    }
                    else if ((row == 0 || row == 1) && !_rotate && countRotate == 3)
                    {
                        block[row].Clear();
                    }
                    else if ((row == 0 || row == 1 || row == 2) && !_rotate && countRotate == 0)
                    {
                        block[row].Clear();
                    }

                    block[row].Y += 1;
                    block[row].Draw(Color);
                }

                else if (blocksType["L"])
                {
                    if ((row == 0 || row == 1 || row == 2) && !_rotate && countRotate == 0)
                    {
                        block[row].Clear();
                    }
                    else if ((row == 0 || row == 1) && !_rotate && countRotate == 1)
                    {
                        block[row].Clear();
                    }

                    if ((row == 0 || row == 1 || row == 3) && !_rotate && countRotate == 2)
                    {
                        block[row].Clear();
                    }
                    else if ((row == 0 || row == 1) && !_rotate && countRotate == 3)
                    {
                        block[row].Clear();
                    }

                    block[row].Y += 1;
                    block[row].Draw(Color);
                }
            }
        }


        public string IsWall(Position position)
        {
            Position floorPosition = new Position(17, 15);
            Position leftWallPosition = new Position(3, 15);
            Position rightWallPosition = new Position(17, 15);

            if (position.Y == floorPosition.Y && !isBlock ||
                block.First().Y == floorPosition.Y ||
                block[1].Y == floorPosition.Y || block[2].Y == floorPosition.Y)
            {
                foreach (var newPosition in block)
                {
                    blocks.Add(newPosition);
                }

                _rotate = false;
                return "floor";
            }

            if (block[0].X < leftWallPosition.X ||
                block[1].X < leftWallPosition.X ||
                block[2].X < leftWallPosition.X ||
                block[3].X < leftWallPosition.X)
            {
                _isWall = "left";
            }
            else if (block[0].X > rightWallPosition.X ||
                     block[1].X > rightWallPosition.X ||
                     block[2].X > rightWallPosition.X ||
                     block[3].X > rightWallPosition.X)
            {
                _isWall = "right";
            }
            else
            {
                _isWall = "clear";
            }

            return _isWall;
        }

        public bool IsBlock(List<Position> newBlock)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                for (int j = 0; j < newBlock.Count; j++)
                {
                    if (blocks[i].X == newBlock[j].X &&
                        blocks[i].Y == newBlock[j].Y + 1)
                    {
                        isBlock = true;
                    }
                }
            }

            if (isBlock)
            {
                foreach (var newPosition in block)
                {
                    blocks.Add(newPosition);
                }
            }

            return isBlock;
        }

        public bool ClearBlocks()
        {
            numLines = 26;
            while (numLines >= 10)
            {
                foreach (Position blockPosition in blocks)
                {
                    for (int j = 11; j < 30; j++)
                    {
                        if (blockPosition.Y == numLines && blockPosition.X == j)
                        {
                            sumLine++;
                        }
                    }
                }

                if (sumLine != 19)
                {
                    sumLine = 0;
                    isLine = false;
                }
                else
                {
                    // Console.WriteLine("FullLine");
                    int count = 0;
                    isLine = true;
                    sumLine = 0;

                    while (count < blocks.Count)
                    {
                        if (blocks[count].Y == numLines)
                        {
                            blocks[count].Clear();
                            blocks.Remove(blocks[count]);
                        }
                        else
                        {
                            count++;
                        }
                    }

                    foreach (Position block in blocks)
                    {
                        if (block.Y < numLines)
                        {
                            block.Clear();
                            block.Y += 1;
                            block.Draw(Color);
                        }
                    }
                }
                numLines--;
            }

            return isLine;
        }

        public bool StopReturn()
        {
            Position position = GetLastBlockPosition();

            if (position.Y < 15)
            {
                return false;
            }


            return true;
        }

        public bool StopGame()
        {
            try
            {
                Position position = GetFirstBlockPosition();
                if (position.Y == 12 && (blocks.Last().Y == 12 || blocks.First().Y == 12))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }

        public void BlockControl(ConsoleKey actionKey)
        {
            //Console.SetCursorPosition(21, 2);
            // Console.SetCursorPosition(21, 3);
            // Console.WriteLine(_rotate);
            // Console.SetCursorPosition(21, 4);
            // Console.WriteLine(_action);


            if (actionKey == ConsoleKey.LeftArrow && _isWall != "left") _action = Action.LEFT;
            else if (actionKey == ConsoleKey.RightArrow && _isWall != "right") _action = Action.RIGTH;
            else if (actionKey == ConsoleKey.UpArrow && StopReturn()) _action = Action.ROTATE;
            else _action = Action.DOWN;
        }

        public void ReDraw()
        {
            Position.ClearAll();

            foreach (var block in blocks)
            {
                block.Draw(Color);
            }
        }
    }
}