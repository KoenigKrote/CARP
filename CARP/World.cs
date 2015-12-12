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
            this.height = height;
            this.width = width;
        }

        public void newWorld()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 0 && y == 0)
                        Console.Write("╔");
                    if ((x == 0 && y > 0 && y < height) || (x == width && y > 0 && y < height))
                        Console.Write("║");
                    if (x == 0 && y == height)
                        Console.Write("╚");
                    if ((x > 0 && y == 0) || (x > 0 && y == height))
                        Console.WriteLine("═");
                    if (x == width && y == 0)
                        Console.WriteLine("╗");
                    if (x == width && y == height)
                        Console.WriteLine("╝");
                }
        }
    }
}
