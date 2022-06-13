using Rover.Controllers.Program.Action;
using Rover.Entities;
using Rover.Entities.Enums;

namespace Test.Rover.Actions
{
    public class MoveForwardTest
    {
        [Test]
        public void AppliesTo_should_return_true_for_F()
        {
            //setup
            var moveForward = new MoveForward();

            //check
            Assert.True(moveForward.AppliesTo('F'));
        }

        [Test]
        public void AppliesTo_should_return_false_for_not_F()
        {
            //setup
            var moveForward = new MoveForward();

            //check
            foreach(var @char in "ABCDEGHIJKLMNOPQRSTUVWXYZ")
            {
                Assert.False(moveForward.AppliesTo(@char));
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
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X + 1, nextPosition.X);
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
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X - 1, nextPosition.X);
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
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y + 1, nextPosition.Y);
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
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(rover.Position.Y - 1, nextPosition.Y);
        }

        [Test]
        public void Action_can_return_next_position_with_negative_coords_moving_to_west()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 0,
                    Y = 3
                },
                Direction = Direction.West
            };
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(-1, nextPosition.X);
            Assert.AreEqual(rover.Position.Y, nextPosition.Y);
        }

        [Test]
        public void Action_can_return_next_position_with_negative_coords_moving_to_south()
        {
            //setup
            var rover = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 2,
                    Y = 0
                },
                Direction = Direction.South
            };
            var moveForward = new MoveForward();

            //action
            var nextPosition = moveForward.Action(rover);

            //check
            Assert.AreEqual(rover.Direction, nextPosition.Direction);
            Assert.AreEqual(rover.Position.X, nextPosition.X);
            Assert.AreEqual(-1, nextPosition.Y);
        }

        [Test]
        public void Action_should_throw_exception_for_null_parameter()
        {
            //setup
            var moveForward = new MoveForward();

            //check
            Assert.Throws<NullReferenceException>(() => moveForward.Action(null));
        }
    }
}