using Rover.Controllers.Program;
using Rover.Controllers.Program.Action;

namespace Test.Rover
{
    public class RoverProgramTest
    {
        [Test]
        public void InPprogress_should_return_true_if_program_have_more_steps()
        {
            //setup
            var roverProgram = new RoverProgram(new List<IAction>() { new TurnLeft() });

            //check
            Assert.True(roverProgram.InProgress());
        }

        [Test]
        public void InPprogress_should_return_false_if_program_have_no_more_steps()
        {
            //setup
            var roverProgram = new RoverProgram(new List<IAction>() { new TurnLeft() });

            //action
            roverProgram.GetNextStep();

            //check
            Assert.False(roverProgram.InProgress());
        }

        [Test]
        public void InPprogress_should_return_false_if_program_not_initialized()
        {
            //setup
            var roverProgram = new RoverProgram(null);

            //check
            Assert.False(roverProgram.InProgress());
        }

        [Test]
        public void InPprogress_should_return_false_if_program_empty()
        {
            //setup
            var roverProgram = new RoverProgram(new List<IAction>());

            //check
            Assert.False(roverProgram.InProgress());
        }

        // public IAction Next()
        // {
        //     return InProgress() ? Program[CurrentStep++] : null;
        // }
        [Test]
        public void GetNextStep_should_return_current_step_and_increase_counter()
        {
            //setup
            var action1 = new TurnLeft();
            var action2 = new TurnLeft();
            var roverProgram = new RoverProgram(new List<IAction>() { action1, action2 });

            //action
            var programStep1 = roverProgram.GetNextStep();
            Assert.True(roverProgram.InProgress());

            var programStep2 = roverProgram.GetNextStep();
            Assert.False(roverProgram.InProgress());

            //check
            Assert.AreSame(action1, programStep1);
            Assert.AreSame(action2, programStep2);
        }

        [Test]
        public void GetNextStep_should_return_null_if_program_not_initialized()
        {
            //setup
            var roverProgram = new RoverProgram(null);

            //action
            var programStep = roverProgram.GetNextStep();

            //check
            Assert.IsNull(programStep);
        }

        [Test]
        public void GetNextStep_should_return_null_if_program_empty()
        {
            //setup
            var roverProgram = new RoverProgram(new List<IAction>());

            //action
            var programStep = roverProgram.GetNextStep();

            //check
            Assert.IsNull(programStep);
        }

        [Test]
        public void GetNextStep_should_return_null_if_program_ended()
        {
            //setup
            var roverProgram = new RoverProgram(new List<IAction>() { new TurnLeft(), new TurnLeft() });

            //action
            var programStep1 = roverProgram.GetNextStep();
            var programStep2 = roverProgram.GetNextStep();
            var endedProgramStep = roverProgram.GetNextStep();

            //check
            Assert.IsNotNull(programStep1);
            Assert.IsNotNull(programStep2);
            Assert.IsNull(endedProgramStep);
        }
    }
}