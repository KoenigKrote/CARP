using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public class Coordinate
    {
        public int xWorld { get; set; }
        public int yWorld { get; set; }
        public int xWindow { get; set; }
        public int yWindow { get; set; }
        public int windowHeight { get; set; }
        public int windowWidth { get; set; }

        public Coordinate(int windowHeight, int windowWidth)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
        }

        public int xQuadrant
        {
            get
            {
                return (int)Math.Floor((decimal)(xWorld / windowWidth));
            }
        }

        public int yQuadrant
        {
            get
            {
                return (int)Math.Floor((decimal)(yWorld / windowHeight));
            }
        }
    }
}
