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
        public Coordinate currentCoord { get; set; }
        private char[] invalidTerrain = { '╔', '║', '╚', '═', '╗', '╝' };
        public World currentWorld;
        public World.MapInfo mapInfo;
        public string color;
        public char icon;

        public Player(World currentWorld, int windowHeight, int windowWidth, string color, char icon)
        {
            this.currentWorld = currentWorld;
            this.color = color;
            this.icon = icon;
            mapInfo = currentWorld.mapInfo;
            currentCoord = rndCoord(windowWidth, windowHeight);
            Move(0, 0);
        }

        private Coordinate rndCoord(int xMax, int yMax)
        {
            Coordinate tempCoord = new Coordinate();
            //Repeat the loop until a coordinate with valid terrain is found
            do
            {
                tempCoord.xWorld = rnd.Next(xMax);
                tempCoord.yWorld = rnd.Next(yMax);
                tempCoord.xWindow = tempCoord.xWorld;
                tempCoord.yWindow = tempCoord.yWorld;
            } while (invalidTerrain.Contains(currentWorld.checkTerrain(tempCoord.xWorld, tempCoord.yWorld)) ? true : false);
            return tempCoord;
        }

        public void Move(int x, int y)
        {
            Coordinate newCoord = new Coordinate()
            {
                xWorld = currentCoord.xWorld + x,
                yWorld = currentCoord.yWorld + y,
                xWindow = currentCoord.xWindow + x,
                yWindow = currentCoord.yWindow + y
            };
            if (canMoveOnTerrain(newCoord))
            {
                Movement.Move(x, y, newCoord, this);
            }

        }


        public bool canMoveOnTerrain(Coordinate newCoord)
        {
            return invalidTerrain.Contains(currentWorld.checkTerrain(newCoord.xWorld, newCoord.yWorld)) ? false : true;
        }


    }
}