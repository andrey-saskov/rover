using Rover.Entities.Enums;

namespace Rover.Entities
{
    public interface IDirectedMapObject : IMapObject
    {
        Direction Direction { get; set; }
    }
}