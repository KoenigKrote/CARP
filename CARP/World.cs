using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public static class World
    {
        private static int width;
        private static int height;
        private static char[,] worldArray;

        static World()
        {
            height = Console.WindowHeight - 1;
            width = Console.WindowWidth - 2;
            worldArray = new char[width+2, height+1];
        }

        public static void newWorld()
        {
            for (int x = 0; x <= width; x++)
                for (int y = 0; y <= height; y++)
                {
                    if (x == 0 && y == 0)
                        addToWorld('╔', x, y);
                    if (x == 0 && y > 0 && y < height)
                        addToWorld('║', x, y);
                    if (x == width && y > 0 && y < height)
                        addToWorld('║', x, y); //Not sure why this needs to be bumped over one
                    if (x == 0 && y == height)
                        addToWorld('╚', x, y);
                    if ((x > 0 && y == 0) || (x > 0 && y == height))
                        addToWorld('═', x, y);
                    if (x == width && y == 0)
                        addToWorld('╗', x, y);
                    if (x == width && y == height)
                        addToWorld('╝', x, y);
                }
            //Reset cursor position to top
            Console.SetCursorPosition(0, 0);
        }

        private static void addToWorld(char c, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            worldArray[x, y] = c;
        }

        public static char checkTerrain(int x, int y)
        {
            return worldArray[x, y];
        }
    }
}
