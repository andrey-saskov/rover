using Rover.Controllers.Program.Action;

namespace Rover.Controllers.Program
{
    public interface IProgram
    {
        bool InProgress();
        IAction GetNextStep();
    }
}