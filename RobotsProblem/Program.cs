using System;
using System.Collections.Generic;
using System.Text;
using RobotsProblem.TextProcessing;
using RobotsProblem.View;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var worldParameters = new StringBuilder(@"
                                                5 3 
                                                1 1 E 
                                                RFRFRFRF 
                                                3 2 N 
                                                FRRFLLFFRRFLL 
                                                0 3 W 
                                                LLFFFLFLFL");

            var inputCommandProcessor = new InputProcessor();
            inputCommandProcessor.ReadInput(worldParameters.ToString(), out IWorld world, out IEnumerable<IRobot> robots);

            var robotAutomaton = new RobotAutomaton(world, new ConsoleWorldRenderer());
            robotAutomaton.StartImitation(robots);

            var output = new OutputProcessor();
            Console.WriteLine(output.GetReports(robots));
            Console.ReadKey();
        }
    }
}
