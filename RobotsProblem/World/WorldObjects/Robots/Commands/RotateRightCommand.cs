using System;
using System.Collections.Generic;

namespace RobotsProblem.World.WorldObjects.Robots.Commands
{
    public class RotateRightCommand :IRobotCommand
    {
        private readonly Dictionary<RobotOrientation, RobotOrientation> _rotationRule;
        public RotateRightCommand()
        {
            _rotationRule = new Dictionary<RobotOrientation, RobotOrientation>
            {
                {RobotOrientation.West, RobotOrientation.North},
                {RobotOrientation.North, RobotOrientation.East},
                {RobotOrientation.East, RobotOrientation.South},
                {RobotOrientation.South, RobotOrientation.West},
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