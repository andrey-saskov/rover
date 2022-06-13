using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.Controllers.Program.Action
{
    public abstract class TurnAction : IAction
    {
        protected static readonly Direction[] Directions = new [] { Direction.North, Direction.East, Direction.South, Direction.West };

        protected abstract Direction CalculateDirection(Direction direction);

        public abstract bool AppliesTo(char command);

        public DirectedPosition Action(IDirectedMapObject mapObject)
        {
            return new DirectedPosition()
            {
                X = mapObject.Position.X,
                Y = mapObject.Position.Y,
                Direction = CalculateDirection(mapObject.Direction)
            };
        }
    }
}