using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class World
    {
        public int windowWidth;
        public int windowHeight;
        public int worldHeight;
        public int worldWidth;
        public TileInfo[,] worldArray;
        public MapInfo mapInfo;

        public struct MapInfo
        {
            public int xQuad { get; set; }
            public int yQuad { get; set; }
            public int xWorld { get; set; } 
            public int yWorld { get; set; }
        }

        public struct TileInfo
        {
            public char c { get; set; }
            public string color { get; set; }
        }

        public void newWorld(int worldHeight, int worldWidth, int windowHeight, int windowWidth)
        {
            this.windowHeight = windowHeight - 1;
            this.windowWidth = windowWidth - 1;
            this.worldHeight = worldHeight;
            this.worldWidth = worldWidth;
            worldArray = new TileInfo[worldWidth, worldHeight];
            mapInfo = new MapInfo();
            getMapPosition(0, 0);
            addToWorld();
            Draw.redrawWorld(0, 0, this);
        }

        private void addToWorld()
        {
            for (int x = 0; x <= worldWidth - 1; x++)
                for (int y = 0; y <= worldHeight - 1; y++)
                {
                    if ((x == 0 && y > 0 && y < worldHeight - 1)
                        || (x == worldWidth - 1 && y > 0 && y < worldHeight - 1))
                        worldArray[x, y] = new TileInfo() { c = '║', color = "grey" };
                    if ((x > 0 && y == 0) || (x > 0 && y == worldHeight - 1))
                        worldArray[x, y] = new TileInfo() { c = '═', color = "grey" };
                    if (x == 0 && y == 0)
                        worldArray[x, y] = new TileInfo() { c = '╔', color = "grey" }; 
                    if (x == 0 && y == worldHeight - 1)
                        worldArray[x, y] = new TileInfo() { c = '╚', color = "grey" };
                    if (x == worldWidth - 1 && y == 0)
                        worldArray[x, y] = new TileInfo() { c = '╗', color = "grey" };
                    if (x == worldWidth - 1 && y == worldHeight - 1)
                        worldArray[x, y] = new TileInfo() { c = '╝', color = "grey" };
                }
        }

        public void getMapPosition(int x, int y)
        {
            mapInfo.xQuad = (int)Math.Floor((decimal)(x / windowWidth));
            mapInfo.yQuad = (int)Math.Floor((decimal)(y / windowHeight));
            mapInfo.xWorld = windowWidth * mapInfo.xQuad;
            mapInfo.yWorld = windowHeight * mapInfo.yQuad;
        }

        public char checkTerrain(int x, int y)
        {
            return worldArray[x, y].c;
        }
    }
}
