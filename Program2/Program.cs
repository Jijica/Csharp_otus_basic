namespace Program2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();
            PrintPlanetInfo(catalog.GetPlanet("Earth"), "Earth");
            PrintPlanetInfo(catalog.GetPlanet("Limonia"), "Limonia");
            PrintPlanetInfo(catalog.GetPlanet("Mars"), "Mars");
            PrintPlanetInfo(catalog.GetPlanet("Venus"), "Venus");
            PrintPlanetInfo(catalog.GetPlanet("Mars"), "Mars");

        }
        static void PrintPlanetInfo((int?,double?,string) info, string planetName)
        {
            if (info.Item3 == null) {
                Console.WriteLine($"Planet {planetName} is on position {info.Item1} from the Sun and has an equator length of {info.Item2} kilometers");
            }
            else
            {
                Console.WriteLine(info.Item3);
            }
        }
    }
}