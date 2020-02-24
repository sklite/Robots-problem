using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using RobotsProblem.TextProcessing;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;
using RobotsProblem.World.WorldObjects.Robots.Commands;

namespace RobotsProblemTest
{
    [TestFixture]
    public class RobotCommandTest
    {
        private IRobot _robot;
        [SetUp]
        public void Setup()
        {
            _robot = new Robot(new Point(1,2), RobotOrientation.North);
        }

        [Test]
        public void TestCommandExecutor()
        {
            var world = new MartianWorld(2,2);
            var shouldDieRobot = new Robot(new Point(0,0), RobotOrientation.South);
            var shouldMoveRobot = new Robot(new Point(0,0), RobotOrientation.North);
            var commandExecutor = new CommandExecutor(world);


            shouldDieRobot.SetOrders("F");
            shouldMoveRobot.SetOrders("F");
            commandExecutor.ExecuteNextCommand(shouldDieRobot);
            commandExecutor.ExecuteNextCommand(shouldMoveRobot);
            
            
            Assert.False(shouldDieRobot.Alive);
            Assert.True(shouldMoveRobot.Alive);
            Assert.AreEqual(shouldMoveRobot.Coordinates, new Point(0,1));
        }
        [Test]
        public void TestRobotRotateCommand()
        {
            var rotateLeft = new RotateLeftCommand();
            var robot = new Robot(new Point(0,0), RobotOrientation.North);
            
            rotateLeft.ExecuteCommandFor(robot);

            Assert.AreEqual(robot.Orientation, RobotOrientation.West);
        }

        [Test]
        public void TestRobotMoveCommand()
        {
            var world = new MartianWorld(3,3);
            var rotateLeft = new ForwardCommand(world);
            var robot = new Robot(new Point(0, 0), RobotOrientation.North);

            rotateLeft.ExecuteCommandFor(robot);

            Assert.AreEqual(robot.Coordinates, new Point(0,1));
        }
    }
}