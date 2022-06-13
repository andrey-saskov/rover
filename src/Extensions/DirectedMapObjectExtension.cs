using Rover.Entities;

namespace Rover.Extensions
{
    public static class DirectedMapObjectExtension
    {
        public static DirectedPosition ToDirectedPosition(this IDirectedMapObject mapObject)
        {
            return new DirectedPosition
            {
                X = mapObject.Position.X,
                Y = mapObject.Position.Y,
                Direction = mapObject.Direction
            };
        }
    }
}