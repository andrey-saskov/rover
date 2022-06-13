using Rover.Controllers.Program.Action;

namespace Rover.Controllers.Program
{
    public class ProgramBuilder : IProgramBuilder
    {
        private readonly IEnumerable<IAction> Actions;

        public ProgramBuilder(IEnumerable<IAction> actions)
        {
            Actions = actions;
        }

        public IProgram BuildProgram(string programText)
        {
            var program = new List<IAction>();
            foreach(var actionLetter in programText.ToCharArray())
            {
                var action = Actions.FirstOrDefault(x => x.AppliesTo(actionLetter));
                program.Add(action); 
            }

            return new RoverProgram(program);
        }
    }
}