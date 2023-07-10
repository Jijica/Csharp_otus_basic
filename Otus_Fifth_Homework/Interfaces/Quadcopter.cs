namespace Interfaces
{
    internal class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _componets = new List<string> {"rotor1","rotor2","rotor3","rotor4"};
        string IChargeable.GetInfo() => "My charging time is 3 sec";
        string IRobot.GetInfo() 
        {
            var str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rnd = new Random();
            return $"My serial number is {str[rnd.Next(str.Length)]}{rnd.Next(1000,9999)}-" +
                   $"{str[rnd.Next(str.Length)]}{rnd.Next(1000, 9999)}-" +
                   $"{str[rnd.Next(str.Length)]}{rnd.Next(1000, 9999)}";
        }
        public List<string> GetComponents() => _componets;
        public void Charge() {
            Console.Write("Charging");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("Charged!");
        }

    }
}