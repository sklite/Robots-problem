using System;
using System.Collections.Generic;
using System.Drawing;

namespace RobotsProblem.World.WorldObjects.Robots.Commands
{
    public class ForwardCommand : IRobotCommand
    {
        private readonly IWorld _world;
        private readonly Dictionary<RobotOrientation, Size> _movingVectors = new Dictionary<RobotOrientation, Size>();

        public ForwardCommand(IWorld world)
        {
            _world = world;
            _movingVectors[RobotOrientation.North] = new Size(0, 1);
            _movingVectors[RobotOrientation.East] = new Size(1, 0);
            _movingVectors[RobotOrientation.South] = new Size(0, -1);
            _movingVectors[RobotOrientation.West] = new Size(-1, 0);
        }
        public void ExecuteCommandFor(IRobot robot)
        {
            var oldPosition = robot.Coordinates;
            var newPosition = oldPosition + _movingVectors[robot.Orientation];
            
            if (!_world.IsInsideBounds(newPosition))
            {
                if (_world.IsScented(oldPosition))
                    return;
                _world.RemoveRobot(robot);
                robot.Alive = false;
                Console.WriteLine("Robot lost!");
                _world.SetScent(oldPosition);
            }
            else
            {
                _world.RemoveRobot(robot);
                robot.Coordinates = newPosition;
                _world.SetRobot(robot);
            }
        }
    }
}