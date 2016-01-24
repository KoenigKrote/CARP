using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Program
    {
        private static int wWidth;
        private static int wHeight;
        //Coordinates in console are ridiculous.  X is distance from left, Y is distance from top.
        //To go down one, add 1 to Y.  To go left one, subtract 1 from X.  Disregard planar geometry, acquire insanity.
        IActor _actor;


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
            wWidth = Console.WindowWidth;
            wHeight = Console.WindowHeight;
            Console.Clear();
            World.newWorld();
            _actor = new Player();
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
                    World.redrawWorld(1, 0);
                    break;
            }
        }
    }
}
