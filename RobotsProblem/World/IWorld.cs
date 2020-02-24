using System.Drawing;
using RobotsProblem.World.WorldObjects;
using RobotsProblem.World.WorldObjects.Robots;

namespace RobotsProblem.World
{
    public interface IWorld
    {
        void RemoveRobot(IRobot robot);
        void SetRobot(IRobot robot);
        bool IsInsideBounds(Point coordinates);
        bool IsScented(Point coordinates);
        void SetScent(Point coordinates);
        IWorldObject this[int i, int j] { get; }
        int Width { get; }
        int Height { get; }
    }
}