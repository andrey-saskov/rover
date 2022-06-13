using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.Controllers
{
    public interface IRoverController
    {
        MarsianRover Create(Position position, Direction direction, string program);
    }
}