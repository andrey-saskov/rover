using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.Controllers.Program.Action
{
    public class MoveForward : IAction
    {
        private static readonly Dictionary<Direction, Position> MovesByDirection = new Dictionary<Direction, Position>()
        {
            { Direction.North, new Position() { X = 0, Y = 1 } },
            { Direction.East, new Position() { X = 1, Y = 0 } },
            { Direction.South, new Position() { X = 0, Y = -1 } },
            { Direction.West, new Position() { X = -1, Y = 0 } }
        };

        public bool AppliesTo(char command)
        {
            return command == 'F';
        }

        public DirectedPosition Action(IDirectedMapObject mapObject)
        {
            return new DirectedPosition()
            {
                X = mapObject.Position.X + MovesByDirection[mapObject.Direction].X,
                Y = mapObject.Position.Y + MovesByDirection[mapObject.Direction].Y,
                Direction = mapObject.Direction
            };
        }
    }
}