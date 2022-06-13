using Rover.Entities.Enums;

namespace Rover.Entities
{
    public interface IMapObject
    {
        Position Position { get; set; }
        MapObjectState State { get; set; }
    }
}