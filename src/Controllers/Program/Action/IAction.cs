using Rover.Entities;

namespace Rover.Controllers.Program.Action
{
    public interface IAction
    {
        bool AppliesTo(char command);
        DirectedPosition Action(IDirectedMapObject mapObject);
    }
}