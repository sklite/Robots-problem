using System.Collections.Generic;
using System.Text;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblem.TextProcessing
{
    public class OutputProcessor
    {
        public string GetReports(IEnumerable<IRobot> robots)
        {

            var result = new StringBuilder();
            result.AppendLine("Output:");
            foreach (var robot in robots)
            {
                result.AppendLine(robot.ToString());
            }

            return result.ToString();
        }
    }
}