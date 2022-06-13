using Rover.Controllers.Program;
using Rover.Entities.Enums;

namespace Rover.Entities
{
    public class MarsianRover : IDirectedMapObject
    {
        public MapObjectState State { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public IProgram Program { get; set; }
    }
}