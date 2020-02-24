using System.Drawing;

namespace RobotsProblem.World.WorldObjects
{
    public interface IWorldObject
    {
        Point Coordinates { get; set; }
        string DisplayName { get; }
    }
}