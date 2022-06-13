using System.Collections.Generic;

namespace Rover.Entities
{
    public class Map
    {
        public Position BottomLeft { get; set; }
        public Position TopRigth { get; set; }
        public IList<IMapObject> MapObjects { get; set; }
    }
}