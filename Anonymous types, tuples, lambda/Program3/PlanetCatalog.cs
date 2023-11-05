namespace Program3
{
    internal class PlanetCatalog
    {
        private List<Planet> _catalog = new List<Planet>();
        private int _methodCallingCounter;
        public int MethodCallingCounter { get { return _methodCallingCounter; } }
        public bool IsPlanetFound { get; private set; }

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

        public (int? Position, double? EquatorLengthKilometers, string report) GetPlanet(string planetName, Func<string, string> PlanetValidator)
        {
            var planetObject = _catalog.Find(planet => planet.Name == planetName);
            IsPlanetFound = planetObject == null ? false : true;
            _methodCallingCounter = _methodCallingCounter < 3 ? _methodCallingCounter + 1 : _methodCallingCounter = 0;
            string report = PlanetValidator(planetName);
            if (IsPlanetFound == true && report == null)
            {
                return (planetObject.Position, planetObject.EquatorLengthKilometers, PlanetValidator(planetName));
            }
            else
            {
                return (null, null, PlanetValidator(planetName));
            }
        }
    }
}
