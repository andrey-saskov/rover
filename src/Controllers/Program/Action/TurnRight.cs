using Rover.Entities.Enums;

namespace Rover.Controllers.Program.Action
{
    public class TurnRight : TurnAction
    {
        public override bool AppliesTo(char command)
        {
            return command == 'R';
        }

        protected override Direction CalculateDirection(Direction direction)
        {
            var turnRightIndex = Array.IndexOf(Directions, direction) + 1;
            return Directions[turnRightIndex < Directions.Length ? turnRightIndex : 0];
        }
    }
}