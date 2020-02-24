using System;
using System.Collections.Generic;

namespace RobotsProblem.World.WorldObjects.Robots.Commands
{
    public class RotateLeftCommand : IRobotCommand
    {
        private readonly Dictionary<RobotOrientation, RobotOrientation> _rotationRule;
        public RotateLeftCommand()
        {
            _rotationRule = new Dictionary<RobotOrientation, RobotOrientation>
            {
                {RobotOrientation.West, RobotOrientation.South},
                {RobotOrientation.South, RobotOrientation.East},
                {RobotOrientation.East, RobotOrientation.North},
                {RobotOrientation.North, RobotOrientation.West},
            };
        }

        public void ExecuteCommandFor(IRobot robot)
        {
            if (!_rotationRule.ContainsKey(robot.Orientation))
                throw new Exception($"Unknown robot orientation {robot.Orientation}");
            robot.Orientation = _rotationRule[robot.Orientation];
        }
    }
}