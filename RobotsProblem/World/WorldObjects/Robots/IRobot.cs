namespace RobotsProblem.World.WorldObjects.Robots
{
    public interface IRobot : IWorldObject
    {
        char GetNextOrder();
        void SetOrders(string commands);
        RobotOrientation Orientation { get; set; }
        bool Alive { get; set; }
        bool HasOrders { get; }
    }
}