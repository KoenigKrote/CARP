using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public static class Draw
    {


        public static void redrawWorld(int newX, int newY, World currentWorld)
        {
            currentWorld.getMapPosition(newX, newY);
            clearWorld();
            World.TileInfo Tile;
            for (int x = 0; x <= currentWorld.windowWidth; x++)
                for (int y = 0; y < currentWorld.windowHeight; y++)
                    if (x <= currentWorld.windowWidth && y <= currentWorld.windowHeight)
                    {
                        Tile = currentWorld.worldArray[currentWorld.mapInfo.xWorld + x,
                            currentWorld.mapInfo.yWorld + y];

                        if (Tile.c != char.MinValue)
                        {
                            drawAtPoint(Tile.c, Tile.color, x, y);
                        }
                    }
        }


        //Factored out actual buffer writing to make graphical engine changes easier
        public static void drawAtPoint(char c, string color, int x, int y)
        {
            colorSwitch(color);
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public static void clearAtPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ");
        }

        private static void clearWorld()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        private static void colorSwitch(string color)
        {
            switch (color.ToLower())
            {
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "grey":
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

            }
        }
    }
}
