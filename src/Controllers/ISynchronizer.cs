using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.Controllers
{
    public interface ISynchronizer
    {
        bool AppliesTo(IMapObject mapObject);
        DirectedPosition GetNextPosition(IMapObject mapObject);
        void Synchronize(IMapObject mapObject, DirectedPosition directedPosition, MapObjectState state);
    }
}