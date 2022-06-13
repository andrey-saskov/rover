namespace Rover.Entities
{
    public interface IMoveable
    {
        DirectedPosition GetNextPosition(IDirectedMapObject mapObject);
    }
}