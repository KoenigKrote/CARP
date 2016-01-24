using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Program
    {
        IActor _actor;
        World currentWorld;

        static void Main(string[] args)
        {

            Program p = new Program();
            p.Initialize();
            while (true)
            {
                p.inputSwitch(Console.ReadKey(true));
            }
        }



        private void Initialize()
        {
            
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetWindowSize(120, 40);
            Console.SetBufferSize(120, 40);
            Console.Clear();

            currentWorld = new World();
            currentWorld.newWorld(Console.BufferHeight*2, Console.BufferWidth*2,
                Console.WindowHeight, Console.WindowWidth);

            _actor = new Player(currentWorld, Console.WindowHeight, Console.WindowWidth, "white", '@');
        }

        private void inputSwitch(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.NumPad1:
                    _actor.Move(-1, 1);
                    break;
                case ConsoleKey.NumPad2:
                    _actor.Move(0, 1);
                    break;
                case ConsoleKey.NumPad3:
                    _actor.Move(1, 1);
                    break;
                case ConsoleKey.NumPad4:
                    _actor.Move(-1, 0);
                    break;
                case ConsoleKey.NumPad5:
                    _actor.Move(0, 0);
                    break;
                case ConsoleKey.NumPad6:
                    _actor.Move(1, 0);
                    break;
                case ConsoleKey.NumPad7:
                    _actor.Move(-1, -1);
                    break;
                case ConsoleKey.NumPad8:
                    _actor.Move(0, -1);
                    break;
                case ConsoleKey.NumPad9:
                    _actor.Move(1, -1);
                    break;
                case ConsoleKey.NumPad0:
                    Draw.redrawWorld(1, 0, currentWorld);
                    break;
            }
        }
    }
}
