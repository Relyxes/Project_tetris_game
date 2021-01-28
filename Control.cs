using System;
using System.Threading;

namespace Project_Tetris_Game_v1
{
    public class Control
    {
        public ConsoleKeyInfo _key;
        private Action _action;


        public Action GetControlKey()
        {


                _key = Console.ReadKey(true);

                if (_key.Key == ConsoleKey.RightArrow)
                {
                    _action = Action.RIGTH;
                    Console.WriteLine(_key.Key.ToString());
                }
                else if (_key.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine(_key.Key.ToString());
                    _action = Action.LEFT;
                }
                else if (_key.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine(_key.Key.ToString());
                    _action = Action.ROTATE;
                }

                return _action;
        }
    }
}