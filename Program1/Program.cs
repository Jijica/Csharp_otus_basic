using System.Reflection;

namespace Program1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var planetOne = new
            {
                Name = "Venus",
                Position = 2,
                EquatorLengthKilometers = 6_051.8 * 2 * Math.PI,
                PreviousPlanet = (string)null
                //PreviousPlanet = new
                //{
                //    Name = "Mercury",
                //    Position = 1,
                //    EquatorLengthKilometers = 2_439.7 * 2 * Math.PI
                //}
            };

            var planetTwo = new
            {
                Name = "Earth",
                Position = 3,
                EquatorLengthKilometers = 6_378.137 * 2 * Math.PI,
                PreviousPlanet = planetOne
            };

            var planetThree = new
            {
                Name = "Mars",
                Position = 4,
                EquatorLengthKilometers = 3_396.2 * 2 * Math.PI,
                PreviousPlanet = planetTwo
            };

            var planetFour = new
            {
                Name = "Venus",
                Position = 2,
                EquatorLengthKilometers = 6_051.8 * 2 * Math.PI,
                PreviousPlanet = planetThree
            };

            Console.WriteLine($"object {nameof(planetOne)} has properties: " +
                $"{nameof(planetOne.Name)} = {planetOne.Name}, " +
                $"{nameof(planetOne.Position)} = {planetOne.Position}, " +
                $"{nameof(planetOne.EquatorLengthKilometers)} = {planetOne.EquatorLengthKilometers}, " +
                //$"{nameof(planetOne.PreviousPlanet)} = {planetOne.PreviousPlanet}, " +
                $"and is Equal to Venus({nameof(planetOne)}) = {planetOne.Equals(planetOne)}");
            Console.WriteLine($"object {nameof(planetTwo)} has properties: " +
                $"{nameof(planetTwo.Name)} = {planetTwo.Name}, " +
                $"{nameof(planetTwo.Position)} = {planetTwo.Position}, " +
                $"{nameof(planetTwo.EquatorLengthKilometers)} = {planetTwo.EquatorLengthKilometers}, " +
                $"{nameof(planetTwo.PreviousPlanet)} = {nameof(planetOne)} reference, " +
                $"and is Equal to Venus({nameof(planetOne)}) = {planetOne.Equals(planetTwo)}");
            Console.WriteLine($"object {nameof(planetThree)} has properties: " +
                $"{nameof(planetThree.Name)} = {planetThree.Name}, " +
                $"{nameof(planetThree.Position)} = {planetThree.Position}, " +
                $"{nameof(planetThree.EquatorLengthKilometers)} = {planetThree.EquatorLengthKilometers}, " +
                $"{nameof(planetThree.PreviousPlanet)} = {nameof(planetTwo)} reference, " +
                $"and is Equal to Venus({nameof(planetOne)}) = {planetOne.Equals(planetThree)}");
            Console.WriteLine($"object {nameof(planetFour)} has properties: " +
                $"{nameof(planetFour.Name)} = {planetFour.Name}, " +
                $"{nameof(planetFour.Position)} = {planetFour.Position}, " +
                $"{nameof(planetFour.EquatorLengthKilometers)} = {planetFour.EquatorLengthKilometers}, " +
                $"{nameof(planetFour.PreviousPlanet)} = {nameof(planetThree)} reference, " +
                $"and is Equal to Venus({nameof(planetOne)}) = {planetOne.Equals(planetFour)}");
        }
    }
}