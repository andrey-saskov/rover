using Rover.Entities.Enums;

namespace Rover.Controllers.Program.Action
{
    public class TurnLeft : TurnAction
    {
        public override bool AppliesTo(char command)
        {
            return command == 'L';
        }

        protected override Direction CalculateDirection(Direction direction)
        {
            var turnLeftIndex = Array.IndexOf(Directions, direction) - 1;
            return Directions[turnLeftIndex >= 0 ? turnLeftIndex : Directions.Length - 1];
        }
    }
}