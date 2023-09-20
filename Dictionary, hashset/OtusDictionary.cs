namespace Dictionary__hashset
{
    internal class OtusDictionary
    {
        private OtusDictionaryKVP[] _elements = new OtusDictionaryKVP[32];
        public string Size { get => $"Size of kvp storing array - {_elements.Length}"; }
        public string Count { get => $"{_elements.Where(e => e != null).ToArray().Length} kvp elements in storing array"; }

        public string this[int key]
        {
            get
            {
                var position = NotGetHashCode(key);
                if (_elements[position] == null)
                {
                    Console.WriteLine("Specified key not found");
                    return "null";
                }
                return _elements[position].Value;
            }
            set
            {
                var position = NotGetHashCode(key);
                if (_elements[position] == null)
                {
                    Console.WriteLine("Specified key not found");
                }
                else
                {
                    _elements[position].Value = value;
                }
            }
        }
        public void Add(int key, string value)
        {
            var position = NotGetHashCode(key);
            if (value == null)
            {
                Console.WriteLine("Value should not be null");
            }
            else
            {
                if (_elements[position] == null)
                {
                    _elements[position] = new OtusDictionaryKVP { Key = key, Value = value };
                }
                else
                {
                    if (_elements[position].Key == key)
                    {
                        Console.WriteLine("Specified key already exists");
                    }
                    else
                    {
                        Resize();
                    }
                }
            }
        }

        public string Get(int key)
        {
            var position = NotGetHashCode(key);
            if (_elements[position] == null)
            {
                return "No element with specified key";
            }
            return _elements[position].Value;
        }

        public void Print()
        {
            foreach (var element in _elements.Where(e => e != null))
            {
                Console.WriteLine($"Key {element.Key} - Value {element.Value}");
            }
        }

        public void GenerateRandomDictionary(int elementCount, int keyRange)
        {
            var rnd = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                Add(rnd.Next(keyRange), rnd.Next().ToString());
            }
        }

        private void Resize()
        {
            var tempArray = _elements.Where(element => element != null).ToArray();
            Array.Clear(_elements);
            if (_elements.Length * 2 < int.MaxValue)
            {
                Array.Resize(ref _elements, _elements.Length * 2);
                foreach (var element in tempArray)
                {
                    Add(element.Key, element.Value);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private int NotGetHashCode(int key) => key % _elements.Length;

        public class OtusDictionaryKVP
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
