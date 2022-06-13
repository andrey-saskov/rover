using Rover.Entities;

namespace Rover.Controllers
{
    public class SynchronizationObject
    {
        public IMapObject MapObject { get; set; }
        public DirectedPosition NextPosition { get; set; }
        public ISynchronizer Synchronizer { get; set; }
        public bool Synchronized { get; set; }
    }
}