using Rover.Controllers.Program.Action;

namespace Rover.Controllers.Program
{
    public class RoverProgram : IProgram
    {
        private readonly IList<IAction> Program;
        private int CurrentStep;

        public RoverProgram(IList<IAction> program)
        {
            Program = program;
            CurrentStep = 0;
        }

        public bool InProgress() => Program?.Count > CurrentStep;

        public IAction GetNextStep()
        {
            return InProgress() ? Program[CurrentStep++] : null;
        }
    }
}