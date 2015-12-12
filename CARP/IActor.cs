using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARP
{
    public interface IActor
    {
        Coordinate coord { get; set; }
        void Move(int x, int y);
        bool canMoveOnTerrain(Coordinate coord);
    }
}
