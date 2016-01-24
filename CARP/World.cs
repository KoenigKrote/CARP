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
        public static MapInfo mapInfo = new MapInfo();

        public struct MapInfo
        {
            public int xQuad { get; set; }
            public int yQuad { get; set; }
            public int xWorld { get; set; } 
            public int yWorld { get; set; }
        }

        static World()
        {
            windowHeight = Console.WindowHeight - 1;
            windowWidth = Console.WindowWidth - 1;
            worldHeight = Console.BufferHeight * 2;
            worldWidth = Console.BufferWidth * 2;
            worldArray = new char[worldWidth+1, worldHeight+1];
            getMapPosition(0, 0);
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
            getMapPosition(newX, newY);
            char c;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x <= windowWidth; x++)
                for (int y = 0; y <= windowHeight; y++)
                    if (x <= windowWidth && y <= windowHeight)
                    {
                        c = worldArray[mapInfo.xWorld + x, mapInfo.yWorld + y];
                        if (c != char.MinValue)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(c);
                        }
                    }
        }

        //private static Tuple<int,int> moveWorldWindow(int newY, int newX)
        //{
        //    int xQuad = (int)Math.Floor((decimal)(newX / windowWidth));
        //    int yQuad = (int)Math.Floor((decimal)(newY / windowHeight));
        //    int worldX = windowWidth * xQuad;
        //    int worldY = windowHeight * yQuad;
        //    //TODO: Clean this
        //    Console.SetWindowPosition(
        //        windowWidth * xQuad,
        //        windowHeight * yQuad);
        //    return Tuple.Create(worldX, worldY);
        //}

        public static void getMapPosition(int x, int y)
        {
            mapInfo.xQuad = (int)Math.Floor((decimal)(x / Console.WindowWidth));
            mapInfo.yQuad = (int)Math.Floor((decimal)(y / Console.WindowHeight));
            mapInfo.xWorld = Console.WindowWidth * mapInfo.xQuad;
            mapInfo.yWorld = Console.WindowHeight * mapInfo.yQuad;
        }

        public static char checkTerrain(int x, int y)
        {
            return worldArray[x, y];
        }
    }
}
