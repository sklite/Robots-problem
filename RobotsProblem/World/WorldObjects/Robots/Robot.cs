using System.Collections.Generic;
using System.Drawing;

namespace RobotsProblem.World.WorldObjects.Robots
{
    public class Robot : IRobot
    {
        private readonly Queue<char> _instructions = new Queue<char>();
        private readonly Dictionary<RobotOrientation, string> _robotNames = new Dictionary<RobotOrientation, string>();

        public Robot(Point position, RobotOrientation robotOrientation)
        {
            Alive = true;
            Coordinates = position;
            Orientation = robotOrientation;
            _robotNames[RobotOrientation.East] = "E";
            _robotNames[RobotOrientation.North] = "N";
            _robotNames[RobotOrientation.South] = "S";
            _robotNames[RobotOrientation.West] = "W";
        }

        public char GetNextOrder()
        {
            return _instructions.Dequeue();
        }

        public void SetOrders(string commands)
        {
            if (string.IsNullOrEmpty(commands))
                return;
            foreach (var robotCommand in commands)
            {
                _instructions.Enqueue(robotCommand);
            }
        }

        public override string ToString()
        {
            return $"{Coordinates.X} {Coordinates.Y} {DisplayName}{(Alive ? "" : " LOST")}";
        }

        public RobotOrientation Orientation { get; set; }
        public Point Coordinates { get; set; }
        public string DisplayName => _robotNames[Orientation];
        public bool Alive { get; set; }
        public bool HasOrders => _instructions.Count > 0;
    }
}