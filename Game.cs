using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project_Tetris_Game_v1
{
    public class Game
    {
        public Game()
        {
        }

        private static Task _taskControl;
        public static bool _isStart = true;
        private static Block _block = new Block(8, 1, '*', ConsoleColor.Red);
        private List<Position> newBlock;
        private Walls _walls = new Walls(20, 16, '|');

        private static int _speed = 400;
        private static int count = 0;
        private static bool isRotation = false;
        private static bool isBonus = false;
        private int _score = 0;

        private static ConsoleKeyInfo _key;

        private static void NextAction()
        {

            while (_isStart)
            {

                if (Console.KeyAvailable)
                {
                    Thread.Sleep(10);
                    _key = new ConsoleKeyInfo();
                    _key = Console.ReadKey(true);
                    _block.BlockControl(_key.Key);
                    if (_block.IsWall(_block.GetFirstBlockPosition()) != "left" ||
                        _block.IsWall(_block.GetLastBlockPosition()) != "right")
                    {
                        isRotation = true;
                        _block.Rotate();
                    }
                }

                isRotation = false;
                _key = new ConsoleKeyInfo();
            }

        }

        public void Start()
        {
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("New game is started!");
            Console.SetCursorPosition(32,22);
            Console.WriteLine("Score: 0");
            Console.SetCursorPosition(32,23);
            Console.WriteLine("Speed: 0");

            _taskControl = new Task(NextAction);
            _taskControl.Start();

            _block.CreateBlock();

            while (_isStart)
            {
                Thread.Sleep(_speed);
               // Console.Clear();

                if (!_block.IsBlock(_block.block) &&
                    _block.IsWall(_block.GetLastBlockPosition()) != "floor" && !isRotation )
                {
                    _block.ClearBlocks();
                    _block.MoveDown();

                }
                else if (isRotation)
                {
                    Thread.Sleep(10);
                }
                else
                {
                    Console.SetCursorPosition(32,22);
                    Console.WriteLine("Score: " + ScorePoints(isBonus));
                    Console.SetCursorPosition(32,23);
                    Console.WriteLine("Speed: " + SpeedLevel(_speed));
                    _block.ReDraw();
                    _block.CreateBlock();
                }

                if (_block.StopGame())
                {
                    Console.SetCursorPosition(32,20);
                    Console.WriteLine("Game Over");
                    _isStart = false;
                }
                else if (_score >= 200)
                {
                    Console.SetCursorPosition(10,9);
                    Console.WriteLine("Congratulations!! Your win! ");
                    _isStart = false;
                    break;
                }


            }
        }

        public int SpeedLevel(int speed)
        {
            _speed -= 5;
            int level = (400 - speed)/5;
            return level;
        }

        public int ScorePoints(bool lines)
        {
            _score += 5;
            int bonus;
            bonus = isBonus ? 10 : 0;
            int points = _score + bonus;
            isBonus = false;
            return _score = points;
        }
    }
}