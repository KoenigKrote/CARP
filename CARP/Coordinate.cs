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

        public int xQuadrant
        {
            get
            {
                return (int)Math.Floor((decimal)(xWorld / Console.WindowWidth));
            }
        }

        public int yQuadrant
        {
            get
            {
                return (int)Math.Floor((decimal)(yWorld / Console.WindowHeight));
            }
        }
    }
}
