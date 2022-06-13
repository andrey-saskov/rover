using Rover.Entities;

namespace Rover.Controllers
{
    public interface IMapController
    {
        Map Initialize(Position leftBottom, Position rigthTop);
        void DeployObject(IMapObject mapObject);
        void Synchronize();
    }
}