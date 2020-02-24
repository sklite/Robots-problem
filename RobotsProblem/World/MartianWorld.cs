using System.Collections.Generic;
using System.Drawing;
using RobotsProblem.World.WorldObjects;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblem.World
{
    public class MartianWorld : IWorld
    {
        private readonly IWorldObject[,] _grid;
        private readonly ICollection<Point> _scents;
        public MartianWorld(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new IWorldObject[Height, Width];
            _scents = new List<Point>();
        }

        public void RemoveRobot(IRobot robot)
        {
            if (IsInsideBounds(robot.Coordinates))
                _grid[robot.Coordinates.Y, robot.Coordinates.X] = null;
        }

        public void SetRobot(IRobot robot)
        {
            if (IsInsideBounds(robot.Coordinates))
                _grid[robot.Coordinates.Y, robot.Coordinates.X] = robot;
        }

        public bool IsInsideBounds(Point point)
        {
            if (point.X < 0 || point.X >= Width)
                return false;
            if (point.Y < 0 || point.Y >= Height)
                return false;
            return true;
        }

        public bool IsScented(Point coordinates)
        {
            return _scents.Contains(coordinates);
        }
        public void SetScent(Point coordinates)
        {
            if (!IsScented(coordinates))
                _scents.Add(coordinates);
        }
        public int Width { get; }
        public int Height { get; }
        public IWorldObject this[int i, int j] => _grid[i, j];
    }
}