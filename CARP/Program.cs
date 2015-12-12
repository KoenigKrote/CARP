using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Program
    {
        private int wWidth;
        private int wHeight;
        //Coordinates in console are ridiculous.  X is distance from left, Y is distance from top.
        //To go down one, add 1 to Y.  To go left one, subtract 1 from X.  Disregard planar geometry, acquire insanity.
        Coordinates playerCoord; 
        

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
            wWidth = Console.WindowWidth;
            wHeight = Console.WindowHeight;
            Console.Clear();
            playerCoord = new Coordinates()
            {
                X = (wWidth / 2),
                Y = (wHeight / 2)
            };
            World w = new World(wWidth, wHeight);
            w.newWorld();
            drawPlayer();
        }

        private void drawPlayer(int x = 0, int y = 0)
        {
            int newX = playerCoord.X + x;
            int newY = playerCoord.Y + y;
            if (newX < wWidth && newY < wHeight && newX >= 0 && newY >= 0) 
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(playerCoord.X, playerCoord.Y);
                Console.Write(" ");
                playerCoord.X += x;
                playerCoord.Y += y;
                Console.SetCursorPosition(playerCoord.X, playerCoord.Y);
                Console.Write("@");
            }
        }

        private void inputSwitch(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.NumPad1:
                    drawPlayer(-1, 1);
                    break;
                case ConsoleKey.NumPad2:
                    drawPlayer(0, 1);
                    break;
                case ConsoleKey.NumPad3:
                    drawPlayer(1, 1);
                    break;
                case ConsoleKey.NumPad4:
                    drawPlayer(-1, 0);
                    break;
                case ConsoleKey.NumPad5:
                    drawPlayer(0, 0);
                    break;
                case ConsoleKey.NumPad6:
                    drawPlayer(1, 0);
                    break;
                case ConsoleKey.NumPad7:
                    drawPlayer(-1, -1);
                    break;
                case ConsoleKey.NumPad8:
                    drawPlayer(0, -1);
                    break;
                case ConsoleKey.NumPad9:
                    drawPlayer(1, -1);
                    break;
            }
        }
    }
}
