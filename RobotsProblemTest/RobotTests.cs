using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using RobotsProblem.TextProcessing;
using RobotsProblem.World;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblemTest
{
    [TestFixture]
    public class RobotTests
    {
        private IRobot _robot;
        [SetUp]
        public void Setup()
        {
            _robot = new Robot(new Point(1,2), RobotOrientation.North);
        }

        [Test]
        public void TestOrderSet()
        {
            _robot.SetOrders("FRL");
            
            Assert.AreEqual(_robot.GetNextOrder(), 'F');
            Assert.AreEqual(_robot.GetNextOrder(), 'R');
            Assert.AreEqual(_robot.GetNextOrder(), 'L');
        }
        [Test]
        public void TestRobotDisplayName()
        {
            Assert.AreEqual(_robot.DisplayName, "N");
        }
    }
}