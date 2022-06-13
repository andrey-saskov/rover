using Rover.Entities;
using Rover.Entities.Enums;

namespace Rover.MapViewer
{
    public class ConsoleViewer : IMapViewer
    {
        private const int mapAxisXStep = 2;
        private const int mapLeft = 2;
        private const int mapTop = 2;
        private int mapBottom = mapTop;

        private int ToMapScreenX(int x) => mapLeft + x * mapAxisXStep;

        private int ToMapScreenY(int y) => mapBottom - y;

        public void Clear()
        {
            Console.Clear();
        }

        public void DrawMap(Map map)
        {
            mapBottom = map.TopRigth.Y + mapTop;

            DrawMapAxis(map);

            var roverIndex = 0;
            foreach(var rover in map.MapObjects.Select(x => x as MarsianRover).Where(x => x != null))
            {
                DrawRover(map, rover);
                WriteAt($"{rover.Position.X} {rover.Position.Y} {rover.Direction} {rover.State}      ", 0, ToMapScreenY(0) + 3 + roverIndex++);
            }
            System.Threading.Thread.Sleep(300);
        }

        private void DrawMapAxis(Map map)
        {
            for (int i = map.BottomLeft.X; i <= map.TopRigth.X; i++)
            {
                WriteAt($"{i}", ToMapScreenX(i), ToMapScreenY(-1));
            }
            for (int i = map.BottomLeft.Y; i <= map.TopRigth.Y; i++)
            {
                WriteAt($"{i}             ", ToMapScreenX(-1), ToMapScreenY(i));
            }
        }

        private void DrawRover(Map map, MarsianRover rover)
        {
            WriteAt(DirectedRoverSign(rover), ToMapScreenX(rover.Position.X), ToMapScreenY(rover.Position.Y));
        }

        private string DirectedRoverSign(MarsianRover rover)
        {
            switch (rover.Direction)
            {
                case Direction.East:
                    return ">";
                case Direction.West:
                    return "<";
                case Direction.North:
                    return "^";
                case Direction.South:
                    return "v";
            }
            return "*";
        }

        private void WriteAt(string s, int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
        }
    }
}