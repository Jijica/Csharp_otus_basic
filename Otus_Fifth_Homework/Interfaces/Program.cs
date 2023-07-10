using System.Diagnostics.Metrics;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRobot robot = new Quadcopter();
            Console.WriteLine(robot.GetRobotType());

            IFlyingRobot copter = new Quadcopter();
            Console.WriteLine("Specifically," + copter.GetRobotType());
            Console.WriteLine($"My components are: {string.Join(", ", copter.GetComponents())}");
            Console.WriteLine(copter.GetInfo());

            IChargeable chargeable = new Quadcopter();
            Console.WriteLine(chargeable.GetInfo());
            Console.ReadKey(true);
            chargeable.Charge();
            


        }
    }
}