namespace Program2
{
    internal class Planet
    {
        public Planet(string name, Planet previousPlanet = null!, int? position = null, double? equatorLengthKilometers = null)
        {
            Name = name;
            switch (name)
            {
                case "Venus":
                    Position = 2;
                    EquatorLengthKilometers = 6_051.8 * 2 * Math.PI;
                    break;
                case "Earth":
                    Position = 3;
                    EquatorLengthKilometers = 6_378.137 * 2 * Math.PI;
                    break;
                case "Mars":
                    Position = 4;
                    EquatorLengthKilometers = 3_396.2 * 2 * Math.PI;
                    break;
                default:
                    Position = position;
                    EquatorLengthKilometers = equatorLengthKilometers;
                    break;
            }
            PreviousPlanet = previousPlanet;
        }
        public string Name { get;}
        public int? Position { get;}
        public double? EquatorLengthKilometers { get;}
        public Planet PreviousPlanet { get;}
    }
}