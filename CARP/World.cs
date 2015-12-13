using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public static class World
    {
        private static int windowWidth;
        private static int windowHeight;
        private static int worldHeight;
        private static int worldWidth;
        private static char[,] worldArray;

        static World()
        {
            windowHeight = Console.WindowHeight - 1;
            windowWidth = Console.WindowWidth - 1;
            worldHeight = windowHeight * 2;
            worldWidth = windowWidth * 2;
            worldArray = new char[worldWidth+1, worldHeight+1];
        }

        public static void newWorld()
        {
            for (int x = 0; x <= worldWidth; x++)
                for (int y = 0; y <= worldHeight; y++)
                {
                    if ((x == 0 && y > 0 && y < worldHeight) 
                        || (x == worldWidth && y > 0 && y < worldHeight))
                        addToWorld('║', x, y);
                    if ((x > 0 && y == 0) || (x > 0 && y == worldHeight))
                        addToWorld('═', x, y);
                    if (x == 0 && y == 0)
                        addToWorld('╔', x, y);
                    if (x == 0 && y == worldHeight)
                        addToWorld('╚', x, y);
                    if (x == worldWidth && y == 0)
                        addToWorld('╗', x, y);
                    if (x == worldWidth && y == worldHeight)
                        addToWorld('╝', x, y);
                }
            //Reset cursor position to top
            Console.SetCursorPosition(0, 0);
        }

        private static void addToWorld(char c, int x, int y)
        {
            if (x <= windowWidth && y <= windowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
            worldArray[x, y] = c;
        }

        public static void redrawWorld(int newX, int newY)
        {
            Console.MoveBufferArea(0, 0, worldWidth, worldHeight, newX, newY);
        }
        public static void redrawWorldX()
        {
            char c;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x <= windowWidth; x++)
                for (int y = 0; y <= windowHeight; y++)
                    if (x < windowWidth && y < windowHeight)
                    {
                        Console.SetCursorPosition(x, y);
                        c = worldArray[x+1, y];
                        Console.Write(c);
                    }
        }
        public static void redrawWorldY()
        {
            
        }
        public static char checkTerrain(int x, int y)
        {
            return worldArray[x, y];
        }
    }
}
