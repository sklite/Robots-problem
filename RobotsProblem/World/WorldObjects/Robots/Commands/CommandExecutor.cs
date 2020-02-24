using System;
using System.Collections.Generic;

namespace RobotsProblem.World.WorldObjects.Robots.Commands
{
    public class CommandExecutor
    {
        private readonly Dictionary<char, IRobotCommand> _instructions = new Dictionary<char, IRobotCommand>();

        public CommandExecutor(IWorld world)
        {
            _instructions['F'] = new ForwardCommand(world);
            _instructions['L'] = new RotateLeftCommand();
            _instructions['R'] = new RotateRightCommand();
        }

        public void ExecuteNextCommand(IRobot robot)
        {
            var robotCommand = robot.GetNextOrder();
            if (!_instructions.ContainsKey(robotCommand))
                throw new ArgumentException($"Unknown command '{robotCommand}'");
            Console.WriteLine($"Execution command \"{robotCommand}\":");
            _instructions[robotCommand].ExecuteCommandFor(robot);
        }
    }
}