using System;
using RobotsProblem.World;

namespace RobotsProblem.View
{
    public class ConsoleWorldRenderer : IWorldRenderer
    {
        private readonly string _emptyCell = "-";
        public void Render(IWorld world)
        {
            for (int i = world.Height - 1; i >= 0; i--)
            {
                for (int j = 0; j < world.Width; j++)
                {
                    if (world[i, j] != null)
                        Console.Write(world[i, j].DisplayName);
                    else
                        Console.Write(_emptyCell);
                }
                Console.WriteLine();
            }
        }
    }
}