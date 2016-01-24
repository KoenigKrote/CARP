using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public static class Movement
    {
        public static void Move(int x, int y, Coordinate newCoord, Player actor)
        {
            if (x == 0 && y == 0)
            {
                drawActor(x, y, actor.currentCoord, actor);
                return;
            }

            if (newCoord.xQuadrant != actor.mapInfo.xQuad)
            {
                Draw.redrawWorld(newCoord.xWorld, newCoord.yWorld, actor.currentWorld);
                newCoord.xWindow = Math.Abs(actor.currentWorld.windowWidth - newCoord.xWindow);
                if (newCoord.xWindow == 1)
                    newCoord.xWindow = 0;
                drawActor(x, y, newCoord, actor);
                return;
            }
            else if (newCoord.yQuadrant != actor.currentWorld.mapInfo.yQuad)
            {
                Draw.redrawWorld(newCoord.xWorld, newCoord.yWorld, actor.currentWorld);
                newCoord.yWindow = Math.Abs(actor.currentWorld.windowHeight - newCoord.yWindow);
                if (newCoord.yWindow == 1)
                    newCoord.yWindow = 0;
                drawActor(x, y, newCoord, actor);
                return;
            }
            else
            {
                drawActor(x, y, newCoord, actor);
            }
        }

        public static void drawActor(int x, int y, Coordinate coord, Player actor)
        {
            Draw.clearAtPoint(actor.currentCoord.xWindow, actor.currentCoord.yWindow);
            Draw.drawAtPoint(actor.icon, actor.color, coord.xWindow, coord.yWindow);
            actor.currentCoord.xWorld += x;
            actor.currentCoord.yWorld += y;
            actor.currentCoord.xWindow = coord.xWindow;
            actor.currentCoord.yWindow = coord.yWindow;
        }
    }
}
