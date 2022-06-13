using Rover.Entities;
using Rover.Entities.Enums;
using Rover.Extensions;

namespace Test.Rover
{
    public class DirectedMapObjectExtensionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToDirectedPosition_should_convert_directedmapobject_to_directedposition()
        {
            //setup
            var directedMapObject = new MarsianRover()
            {
                Position = new Position()
                {
                    X = 1,
                    Y = 2
                },
                Direction = Direction.East
            };

            //action
            var converted = directedMapObject.ToDirectedPosition();

            //check
            Assert.AreEqual(1, converted.X);
            Assert.AreEqual(2, converted.Y);
            Assert.AreEqual(Direction.East, converted.Direction);
        }

        
        [Test]
        public void ToDirectedPosition_should_throw_exception_when_directedmapobject_not_initialized()
        {
            //setup
            var directedMapObject = new MarsianRover();

            //action
            Assert.Throws<NullReferenceException>(() => directedMapObject.ToDirectedPosition());
        }
    }
}