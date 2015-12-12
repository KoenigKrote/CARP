using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class World
    {
        private int width;
        private int height;
        public World(int width, int height)
        {
            this.height = height-1;
            this.width = width-2;
        }

        public void newWorld()
        {
            for (int x = 0; x <= width; x++)
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 0 && y == 0)
                        Console.Write("╔");
                    if (x == 0 && y > 0 && y < height)
                        Console.Write("║");
                    if (x == width && y > 0 && y < height)
                    {
                        //TODO: Fix this
                        Console.SetCursorPosition(x + 1, y);
                        Console.Write("║");
                        Console.SetCursorPosition(x, y);
                    }
                        if (x == 0 && y == height)
                        Console.Write("╚");
                    if ((x > 0 && y == 0) || (x > 0 && y == height))
                        Console.Write("═");
                    if (x == width && y == 0)
                        Console.Write("╗");
                    if (x == width && y == height)
                        Console.Write("╝");
                }
            //Reset cursor position to top
            Console.SetCursorPosition(0, 0);
        }
    }
}
