using Rover.Controllers.Program;
using Rover.Entities;
using Rover.Entities.Enums;
using Rover.Extensions;

namespace Rover.Controllers
{
    public class RoverController : IRoverController, ISynchronizer
    {
        private readonly IProgramBuilder ProgramBuilder;

        public RoverController(IProgramBuilder programBuilder)
        {
            ProgramBuilder = programBuilder;
        }

        public bool AppliesTo(IMapObject mapObject)
        {
            return mapObject is MarsianRover;
        }

        public MarsianRover Create(Position position, Direction direction, string program)
        {
            return new MarsianRover()
            {
                State = MapObjectState.Online,
                Position = position,
                Direction = direction,
                Program = ProgramBuilder.BuildProgram(program)
            };
        }

        public DirectedPosition GetNextPosition(IMapObject mapObject)
        {
            var rover = mapObject as MarsianRover;
            if (rover != null && rover.State == MapObjectState.Online && rover.Program?.InProgress() == true)
            {
                return rover.Program?.GetNextStep().Action(rover);
            }

            return rover?.ToDirectedPosition();
        }

        public void Synchronize(IMapObject mapObject, DirectedPosition directedPosition, MapObjectState state)
        {
            var rover = mapObject as MarsianRover;
            if (rover != null)
            {
                rover.Position.X = directedPosition.X;
                rover.Position.Y = directedPosition.Y;
                rover.Direction = directedPosition.Direction;
                rover.State = state;
            }
        }
    }
}