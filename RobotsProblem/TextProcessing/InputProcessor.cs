using System;
using System.Collections.Generic;
using System.Drawing;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblem.TextProcessing
{
    public class InputProcessor
    {
        private readonly Dictionary<char, RobotOrientation> _orientations = new Dictionary<char, RobotOrientation>();
        public InputProcessor()
        {
            _orientations['N'] = RobotOrientation.North;
            _orientations['W'] = RobotOrientation.West;
            _orientations['S'] = RobotOrientation.South;
            _orientations['E'] = RobotOrientation.East;
        }
        Size ReadWorldSize(string worldSizeLine)
        {
            var worldSizeArray = worldSizeLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var width = int.Parse(worldSizeArray[0]) + 1;
            var height = int.Parse(worldSizeArray[1]) + 1;

            if (width <= 1 || height <= 1)
                throw new Exception("Upper-right coordinates of the world are to small");
            if (width > 50 || height > 50)
                throw new Exception("World size is too big");

            return new Size(width, height);
        }

        IEnumerable<IRobot> ReadRobotSettings(Queue<string> robotSettingLines)
        {
            var result = new List<IRobot>();
            while (robotSettingLines.Count > 0)
            {
                var positionLine = robotSettingLines.Dequeue().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var x = int.Parse(positionLine[0]);
                var y = int.Parse(positionLine[1]);
                var orientation = positionLine[2][0];
                if (!_orientations.ContainsKey(orientation))
                    throw new Exception("Wrong robot orientation settings format");

                var robot = new Robot(new Point(x, y), _orientations[orientation]);
                var orders = robotSettingLines.Dequeue().Trim();
                if (orders.Length > 50)
                    throw new Exception("Wrong robot orders line length");
                robot.SetOrders(orders);
                result.Add(robot);
            }
            return result;
        }

        public bool TryReadInput(string input, out IWorld world, out IEnumerable<IRobot> robots)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("Input settings cannot be empty", nameof(input));

                var inputLines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var inputQueue = new Queue<string>(inputLines);

                var worldSize = ReadWorldSize(inputQueue.Dequeue());
                robots = ReadRobotSettings(inputQueue);

                world = new MartianWorld(worldSize.Width, worldSize.Height);
                return true;
            }
            catch (Exception e)
            {
                world = null;
                robots = null;
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}