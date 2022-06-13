using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.Controllers
{
    public class MapController : IMapController
    {
        private readonly IEnumerable<ISynchronizer> Synchronizers;
        private Map Map { get; set; }

        public MapController(IEnumerable<ISynchronizer> synchronizers)
        {
            Synchronizers = synchronizers;
        }

        public Map Initialize(Position bottomLeft, Position topRight)
        {
            Map = new Map()
            {
                BottomLeft = bottomLeft,
                TopRigth = topRight,
                MapObjects = new List<IMapObject>()
            };
            return Map;
        }

        public void DeployObject(IMapObject mapObject)
        {
            Map.MapObjects.Add(mapObject);
        }

        public void Synchronize()
        {
            List<SynchronizationObject> synchronizationList = CreateSynchronizationList();

            var collisions = synchronizationList.Where(o1 => 
                synchronizationList.Any(o2 => 
                    o1 != o2 && 
                    (o1.NextPosition.X == o2.NextPosition.X && o1.NextPosition.Y == o2.NextPosition.Y
                    || o1.NextPosition.X == o2.MapObject.Position.X && o1.NextPosition.Y == o2.MapObject.Position.Y)
                ));

            foreach (var synchronizedObject in synchronizationList.Where(x => !collisions.Contains(x)))
            {
                var nextState = synchronizedObject.NextPosition.X >= Map.BottomLeft.X && synchronizedObject.NextPosition.X <= Map.TopRigth.X
                            && synchronizedObject.NextPosition.Y >= Map.BottomLeft.Y && synchronizedObject.NextPosition.Y <= Map.TopRigth.Y
                            ? MapObjectState.Online : MapObjectState.Lost;
                synchronizedObject.Synchronizer.Synchronize(synchronizedObject.MapObject, synchronizedObject.NextPosition, nextState);
            }
        }

        private List<SynchronizationObject> CreateSynchronizationList()
        {
            var synchronizationList = new List<SynchronizationObject>();
            foreach (var mapObject in Map.MapObjects)
            {
                var synchronizer = Synchronizers.FirstOrDefault(x => x.AppliesTo(mapObject));
                if (synchronizer != null)
                {
                    synchronizationList.Add(new SynchronizationObject()
                    {
                        MapObject = mapObject,
                        NextPosition = synchronizer.GetNextPosition(mapObject),
                        Synchronizer = synchronizer
                    });
                }
            }

            return synchronizationList;
        }
    }
}