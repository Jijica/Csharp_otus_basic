namespace Dictionary__hashset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var otusDictionary = new OtusDictionary();
            otusDictionary.GenerateRandomDictionary(100000, 99999);
            otusDictionary.Print();
            otusDictionary[1] = "test";
            otusDictionary.Add(44, null);
            Console.WriteLine(otusDictionary[2]);
            otusDictionary[3] = null;
            Console.WriteLine(otusDictionary.Size);
            Console.WriteLine(otusDictionary.Count);
        }
    }
}