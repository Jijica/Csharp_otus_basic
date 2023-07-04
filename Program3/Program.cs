namespace Program3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();

            Func<string, string> PlanetValidator = planet =>
            {
                if (catalog.MethodCallingCounter == 3)
                {
                    return "You are asking too frequently";
                }
                else if (catalog.IsPlanetFound == false)
                {
                    return "No such planet in a catalog";
                }
                else
                {
                    return null!;
                }
            };

            Func<string, string> ForbiddenPlanet = planet =>
            {
                if (catalog.MethodCallingCounter == 3)
                {
                    return "You are asking too frequently";
                }
                else if (planet == "Limonia")
                {
                    return "This is a forbidden planet!";
                }
                else
                {
                    return null!;
                }
            };

            PrintPlanetInfo(catalog.GetPlanet("Earth",PlanetValidator), "Earth");
            PrintPlanetInfo(catalog.GetPlanet("Limonia", PlanetValidator), "Limonia");
            PrintPlanetInfo(catalog.GetPlanet("Limonia", PlanetValidator), "Limonia");
            PrintPlanetInfo(catalog.GetPlanet("Limonia", ForbiddenPlanet), "Limonia");
            PrintPlanetInfo(catalog.GetPlanet("Mars",PlanetValidator), "Mars");
            PrintPlanetInfo(catalog.GetPlanet("Venus",PlanetValidator), "Venus");
            PrintPlanetInfo(catalog.GetPlanet("Mars",PlanetValidator), "Mars");
            PrintPlanetInfo(catalog.GetPlanet("Mercury", ForbiddenPlanet), "Mercury");
            PrintPlanetInfo(catalog.GetPlanet("Mercury", PlanetValidator), "Mercury");
        }
        static void PrintPlanetInfo((int?, double?, string) info, string planetName)
        {
            if (info.Item3 == null & (info.Item1 != null || info.Item2 != null))
            {
                Console.WriteLine($"Planet {planetName} is on position {info.Item1} from the Sun and has an equator length of {info.Item2} kilometers");
            }
            else
            {
                Console.WriteLine(info.Item3);
            }
        }
    }
}