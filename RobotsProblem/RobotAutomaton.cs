using System;
using System.Collections.Generic;
using System.Text;
using RobotsProblem.View;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;
using RobotsProblem.World.WorldObjects.Robots.Commands;

namespace RobotsProblem
{
    public class RobotAutomaton
    {
        private readonly IWorld _world;
        private readonly IWorldRenderer _renderer;
        private readonly CommandExecutor _commandExecutor;

        public RobotAutomaton(IWorld world, IWorldRenderer renderer)
        {
            _world = world;
            _renderer = renderer;
            _commandExecutor = new CommandExecutor(_world);
        }

        public void StartImitation(IEnumerable<IRobot> robots)
        {
            foreach (var robot in robots)
            {
                Console.WriteLine($"Welcome new robot \"{robot}\" in this cruel world!");
                _world.SetRobot(robot);
                _renderer.Render(_world);

                while (robot.Alive && robot.HasOrders)
                {
                    _commandExecutor.ExecuteNextCommand(robot);
                    _renderer.Render(_world);
                }
                _world.RemoveRobot(robot);
                Console.WriteLine("=====================");
            }
        }
    }
}