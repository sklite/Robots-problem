using System;
using RobotsProblem.World;

namespace RobotsProblem.View
{
    public class ConsoleWorldRenderer : IWorldRenderer
    {

        public void Render(IWorld world)
        {
            for (int i = world.Height - 1; i >= 0; i--)
            {
                for (int j = 0; j < world.Width; j++)
                {
                    string point = "-";
                    if (world[i, j] != null)
                        point = world[i, j].DisplayName;
                    Console.Write(point);
                }
                Console.WriteLine();
            }
        }
    }
}