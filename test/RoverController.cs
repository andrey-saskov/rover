using Rover.Controllers;
using Rover.Controllers.Program;
using Rover.Entities;
using Rover.Entities.Enums;
using Moq;
using Rover.Controllers.Program.Action;

namespace Test.Rover
{
    public class RoverControllerTest
    {
        private Mock<IProgramBuilder> programBuilderMock = new Mock<IProgramBuilder>();
        private IProgram program = new RoverProgram(new List<IAction>());

        [SetUp]
        public void Setup()
        {
            programBuilderMock.Setup(m => m.BuildProgram(It.IsAny<string>()))
            .Returns(program);
        }

        [Test]
        public void Create_should_create_rover_instance()
        {
            //setup
            var roverController = new RoverController(programBuilderMock.Object);

            //action
            var position = new Position();
            var rover = roverController.Create(position, Direction.East, "");

            //check
            Assert.AreEqual(MapObjectState.Online, rover.State);
            Assert.AreEqual(position, rover.Position);
            Assert.AreEqual(Direction.East, rover.Direction);
            Assert.AreEqual(program, rover.Program);
        }

        [Test]
        public void Synchronize_should_update_rover_fields()
        {
            //setup
            var rover = new MarsianRover()
            {
                Direction = Direction.East,
                Position = new Position() { X = 1, Y = 2 },
                State = MapObjectState.Online
            };
            var roverController = new RoverController(programBuilderMock.Object);
            var updatedPostion = new DirectedPosition() { X = 2, Y = 3, Direction = Direction.West };
        
            //action
            var position = new Position();
            roverController.Synchronize(rover, updatedPostion, MapObjectState.Lost);

            //Check
            Assert.AreEqual(updatedPostion.Direction, rover.Direction);
            Assert.AreEqual(updatedPostion.X, rover.Position.X);
            Assert.AreEqual(updatedPostion.Y, rover.Position.Y);
            Assert.AreEqual(MapObjectState.Lost, rover.State);
        }

        [Test]
        public void GetNextPosition_should_return_null_for_wrong_object()
        {
            //setup
            var roverController = new RoverController(programBuilderMock.Object);
        
            //action
            var position = roverController.GetNextPosition(null);

            //Check
            Assert.IsNull(position);
        }

        [Test]
        public void GetNextPosition_should_return_same_position_if_program_empty()
        {
            //setup
             var rover = new MarsianRover()
            {
                Direction = Direction.East,
                Position = new Position() { X = 1, Y = 2 },
                State = MapObjectState.Online
            };
            var roverController = new RoverController(programBuilderMock.Object);
        
            //action
            var nextPosition = roverController.GetNextPosition(rover);

            //Check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void GetNextPosition_should_return_next_position_for_program_step()
        {
            //setup
             var rover = new MarsianRover()
            {
                Direction = Direction.East,
                Position = new Position() { X = 1, Y = 2 },
                State = MapObjectState.Online,
                Program =  new RoverProgram(new List<IAction>() { new MoveForward() })
            };
            var roverController = new RoverController(programBuilderMock.Object);
        
            //action
            var nextPosition = roverController.GetNextPosition(rover);

            //Check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X + 1, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void GetNextPosition_should_return_keep_position_if_program_ended()
        {
            //setup
             var rover = new MarsianRover()
            {
                Direction = Direction.East,
                Position = new Position() { X = 1, Y = 2 },
                State = MapObjectState.Online,
                Program =  new RoverProgram(new List<IAction>() { new MoveForward() })
            };
            var roverController = new RoverController(programBuilderMock.Object);
        
            //action
            var nextPosition1 = roverController.GetNextPosition(rover);
            var nextPosition2 = roverController.GetNextPosition(rover);

            //Check
            Assert.AreEqual(rover.Direction, nextPosition1.Direction);
            Assert.AreEqual(rover.Position.X + 1, nextPosition1.X);
            Assert.AreEqual(rover.Position.Y, nextPosition1.Y);
            
            Assert.AreEqual(rover.Direction, nextPosition2.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition2.X);
            Assert.AreEqual(rover.Position.Y, nextPosition2.Y);
        }

        [Test]
        public void GetNextPosition_should_return_keep_position_if_rover_lost()
        {
            //setup
             var rover = new MarsianRover()
            {
                Direction = Direction.East,
                Position = new Position() { X = 1, Y = 2 },
                State = MapObjectState.Lost,
                Program =  new RoverProgram(new List<IAction>() { new MoveForward() })
            };
            var roverController = new RoverController(programBuilderMock.Object);
        
            //action
            var nextPosition = roverController.GetNextPosition(rover);

            //Check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }
    }
}