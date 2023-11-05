using Program2;

namespace Program2
{
    internal class PlanetCatalog
    {
        private List<Planet> _catalog = new List<Planet>();
        private int _methodCallingCounter;

        public PlanetCatalog(params Planet[] planets)
        {
            if (planets == null)
            {
                _catalog.Add(new Planet("Venus", null!));
                _catalog.Add(new Planet("Earth", _catalog[0]));
                _catalog.Add(new Planet("Mars", _catalog[1]));
            }
            else
            {
                foreach (var planet in planets)
                { _catalog.Add(planet); }
            }
        }

        public (int? Position, double? EquatorLengthKilometers, string report) GetPlanet(string planetName)
        {
            var planetObject = _catalog.Find(planet => planet.Name == planetName);
            _methodCallingCounter++;
            if (_methodCallingCounter == 3)
            {
                _methodCallingCounter = 0;
                return (null, null, "You are asking too frequently");
            }
            else if (planetObject == null) {
                return (null, null, "No such planet in a catalog");
            }
            else
            {
                return (planetObject.Position, planetObject.EquatorLengthKilometers, null!);
            }
        }
    }
}