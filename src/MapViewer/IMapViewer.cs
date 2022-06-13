using Rover.Entities;

namespace Rover.MapViewer
{
    public interface IMapViewer
    {
        void Clear();
        void DrawMap(Map map);
    }
}