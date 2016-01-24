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
        public Coordinate coord { get; set; }
        private char[] invalidTerrain = { '╔', '║', '╚', '═', '╗', '╝' };


        public Player()
        {
            coord = rndCoord(Console.WindowWidth, Console.WindowHeight);
            Move(0, 0);
        }

        private Coordinate rndCoord(int xMax, int yMax)
        {
            Coordinate tempCoord = new Coordinate();
            do
            {
                tempCoord.xWorld = rnd.Next(xMax);
                tempCoord.yWorld = rnd.Next(yMax);
                tempCoord.xWindow = tempCoord.xWorld;
                tempCoord.yWindow = tempCoord.yWorld;
            } while (invalidTerrain.Contains(World.checkTerrain(tempCoord.xWorld, tempCoord.yWorld)) ? true : false);
            //This loop uses the same terrain check as movement, but since its a loop we want to rerun the loop
            //In the event that our terrain is invalid.

            return tempCoord;
        }


        //TODO: Simplify this
        public void Move(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                Console.SetCursorPosition(coord.xWindow, coord.yWindow);
                Console.Write("@");
                return;
            }

            Coordinate newCoord = new Coordinate() {
                xWorld = coord.xWorld + x,
                yWorld = coord.yWorld + y,
                xWindow = coord.xWindow + x,
                yWindow = coord.yWindow + y
            };


            if (newCoord.xQuadrant != World.mapInfo.xQuad)
            {
                World.redrawWorld(newCoord.xWorld, newCoord.yWorld);
                newCoord.xWindow = Console.WindowWidth - Math.Abs(newCoord.xWindow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(newCoord.xWindow, newCoord.yWindow);
                Console.Write("@");
                coord.xWorld += x;
                coord.yWorld += y;
                coord.xWindow = newCoord.xWindow;
                coord.yWindow = newCoord.yWindow;
                return;
            }
            else if (newCoord.yQuadrant != World.mapInfo.yQuad)
            {
                World.redrawWorld(newCoord.xWorld, newCoord.yWorld);
                newCoord.yWindow = Console.WindowHeight - Math.Abs(newCoord.yWindow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(newCoord.xWindow, newCoord.yWindow);
                Console.Write("@");
                coord.xWorld += x;
                coord.yWorld += y;
                coord.xWindow = newCoord.xWindow;
                coord.yWindow = newCoord.yWindow;
                return;
            }


            if (canMoveOnTerrain(newCoord))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coord.xWindow, coord.yWindow);
                Console.Write(" ");
                coord.xWorld += x;
                coord.yWorld += y;
                coord.xWindow += x;
                coord.yWindow += y;
                Console.SetCursorPosition(coord.xWindow, coord.yWindow);
                Console.Write("@");
                return;
            }
        }


        public bool canMoveOnTerrain(Coordinate coord)
        {
            return invalidTerrain.Contains(World.checkTerrain(coord.xWorld, coord.yWorld)) ? false : true;
            //Maybe backwards thinking, but since it's easier to blacklist terrain than whitelist:
            //false returns if true, true returns if false.
        }


    }
}