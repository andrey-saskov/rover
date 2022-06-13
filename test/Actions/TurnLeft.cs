using Rover.Controllers.Program.Action;
using Rover.Entities;
using Rover.Entities.Enums;

namespace Test.Rover.Actions
{
    public class TurnLeftTest
    {
        [Test]
        public void AppliesTo_should_return_true_for_L()
        {
            //setup
            var turnLeft = new TurnLeft();

            //check
            Assert.True(turnLeft.AppliesTo('L'));
        }

        [Test]
        public void AppliesTo_should_return_false_for_not_L()
        {
            //setup
            var turnLeft = new TurnLeft();

            //check
            foreach(var @char in "ABCDEFGHIJKMNOPQRSTUVWXYZ")
            {
                Assert.False(turnLeft.AppliesTo(@char));
            }
        }

        [Test]
        public void Action_should_return_next_position_for_east_direction()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 2,
                    Y = 3
                },
                Direction = Direction.East
            };
            var turnLeft = new TurnLeft();

            //action
            var nextPosition = turnLeft.Action(rover);

            //check
            Assert.AreEqual(Direction.North, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void Action_should_return_next_position_for_west_direction()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 2,
                    Y = 3
                },
                Direction = Direction.West
            };
            var turnLeft = new TurnLeft();

            //action
            var nextPosition = turnLeft.Action(rover);

            //check
            Assert.AreEqual(Direction.South, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void Action_should_return_next_position_for_north_direction()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 2,
                    Y = 3
                },
                Direction = Direction.North
            };
            var turnLeft = new TurnLeft();

            //action
            var nextPosition = turnLeft.Action(rover);

            //check
            Assert.AreEqual(Direction.West, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void Action_should_return_next_position_for_south_direction()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 2,
                    Y = 3
                },
                Direction = Direction.South
            };
            var turnLeft = new TurnLeft();

            //action
            var nextPosition = turnLeft.Action(rover);

            //check
            Assert.AreEqual(Direction.East, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void Action_should_throw_exception_for_null_parameter()
        {
            //setup
            var turnLeft = new TurnLeft();

            //check
            Assert.Throws<NullReferenceException>(() => turnLeft.Action(null));
        }
    }
}