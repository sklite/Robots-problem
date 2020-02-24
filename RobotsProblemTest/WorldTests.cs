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
    public class WorldTests
    {
        private IWorld _world;
        private IRobot _robot;
        [SetUp]
        public void Setup()
        {
            _world = new MartianWorld(5, 10);
            _robot = new Robot(new Point(1,2), RobotOrientation.North);
        }

        [Test]
        public void TestWorldScent()
        {
            _world.SetScent(new Point(2,2));
            
            Assert.NotNull(_world);
            Assert.AreEqual(_world.Height, 10);
            Assert.AreEqual(_world.Width, 5);
            Assert.True(_world.IsScented(new Point(2,2)));

        }
        [Test]
        public void TestWorldRobotSet()
        {
            _world.SetRobot(_robot);

            Assert.AreEqual(_world[_robot.Coordinates.Y, _robot.Coordinates.X], _robot);
        }

        [Test]
        public void TestWorldRobotRemove()
        {
            _world.SetRobot(_robot);

            _world.RemoveRobot(_robot);

            Assert.IsNull(_world[_robot.Coordinates.Y, _robot.Coordinates.X]);
        }
    }
}