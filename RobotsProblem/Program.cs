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
        private static int Main(string[] args)
        {
            var inputParam = DummyValue();
            if (args.Length != 0)
                inputParam = args[0];

            var inputCommandProcessor = new InputProcessor();
            if (!inputCommandProcessor.TryReadInput(inputParam, out IWorld world, out IEnumerable<IRobot> robots))
                return 1;

            var robotAutomaton = new RobotAutomaton(world, new ConsoleWorldRenderer());
            robotAutomaton.StartImitation(robots);

            var output = new OutputProcessor();
            Console.WriteLine(output.GetReports(robots));
            Console.ReadKey();

            return 0;
        }

        static string DummyValue()
        {
            return @"5 3 
                        1 1 E 
                        RFRFRFRF 
                        3 2 N 
                        FRRFLLFFRRFLL 
                        0 3 W 
                        LLFFFLFLFL";
        }
    }
}
