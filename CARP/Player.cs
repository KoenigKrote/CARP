using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Player : IActor
    {
        public Player(Coordinate coord)
        {
            this.coord = coord;
        }

        public Coordinate coord { get; set; }
        private char[] invalidTerrain = { '╔', '║', '╚', '═', '╗', '╝' };

        //TODO: Simplify this
        public void Move(int x, int y)
        {
            Coordinate newCoord = new Coordinate()
                { X = coord.X + x, Y = coord.Y + y};
            if (newCoord.X < Console.WindowWidth && newCoord.Y < Console.WindowHeight
                    && newCoord.X >= 0 && newCoord.Y >= 0
                    && canMoveOnTerrain(newCoord))
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write(" ");
                coord.X += x;
                coord.Y += y;
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write("@");
            }
        }

        public bool canMoveOnTerrain(Coordinate coord)
        {
            return invalidTerrain.Contains(World.checkTerrain(coord.X, coord.Y)) ? false : true; 
            //Maybe backwards thinking, but since it's easier to blacklist terrain than whitelist:
            //false returns if true, true returns if false.
        }
    }
}