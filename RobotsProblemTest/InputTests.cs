using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RobotsProblem.TextProcessing;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblemTest
{
    [TestFixture]
    public class InputTests
    {


        [Test]
        public void TestWorldCreation()
        {
            var inputStr = @"5 3
                        1 1 E
                        RFRFRFRF
                        3 2 N
                        FRRFLLFFRRFLL
                        0 3 W
                        LLFFFLFLFL";
            var inputProcessor = new InputProcessor();
            IWorld world;
            IEnumerable<IRobot> robots;


            inputProcessor.ReadInput(inputStr, out world, out robots);
            

            Assert.NotNull(world);
            Assert.NotNull(robots);
            Assert.AreEqual(world.Height, 4);
            Assert.AreEqual(world.Width, 6);

        }
    }
}