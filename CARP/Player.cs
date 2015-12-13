using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Player : IActor
    {
        Random rnd = new Random();
        public Player()
        {
            coord = rndCoord(Console.WindowWidth, Console.WindowHeight);
            Move(0, 0);
        }

        public Coordinate coord { get; set; }
        private char[] invalidTerrain = { '╔', '║', '╚', '═', '╗', '╝' };

        private Coordinate rndCoord(int xMax, int yMax)
        {
            Coordinate tempCoord = new Coordinate();
            do
            {
                tempCoord.X = rnd.Next(xMax);
                tempCoord.Y = rnd.Next(yMax);
            } while (invalidTerrain.Contains(World.checkTerrain(tempCoord.X, tempCoord.Y)) ? true : false);
            //This loop uses the same terrain check as movement, but since its a loop we want to rerun the loop
            //In the even that our terrain is invalid.

            return tempCoord;
        }


        //TODO: Simplify this
        public void Move(int x, int y)
        {
            Coordinate newCoord = new Coordinate()
            { X = coord.X + x, Y = coord.Y + y };

            if (newCoord.X+1 > Console.WindowWidth || newCoord.Y+1 > Console.WindowHeight)
            {
                World.redrawWorld(newCoord.X, newCoord.Y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write("@");
                return;
            }
            //else if (newCoord.X + 1 > Console.WindowWidth)
            //{
            //    World.redrawWorldX();
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.SetCursorPosition(coord.X, coord.Y);
            //    Console.Write("@");
            //    return;
            //}
            //else if (newCoord.Y + 1 > Console.WindowHeight)
            //{
            //    World.redrawWorldY();
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.SetCursorPosition(coord.X, coord.Y);
            //    Console.Write("@");
            //    return;
            //}


            if (canMoveOnTerrain(newCoord))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write(" ");
                coord.X += x;
                coord.Y += y;
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write("@");
                return;
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