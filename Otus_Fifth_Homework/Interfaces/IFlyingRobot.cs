namespace Interfaces
{
    internal interface IFlyingRobot : IRobot
    {
        public new string GetRobotType() => "I am a flying robot" ;
    }
}
