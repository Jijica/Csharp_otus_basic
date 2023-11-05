using System.Collections.Immutable;

namespace JackHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = ImmutableList<string>.Empty;
            var part1 = new Part1();
            var part2 = new Part2();
            var part3 = new Part3();
            var part4 = new Part4();    
            var part5 = new Part5();
            var part6 = new Part6();
            var part7 = new Part7();
            var part8 = new Part8();
            var part9 = new Part9();

            part1.Addpart(collection);
            part2.Addpart(part1.Poem);
            part3.Addpart(part2.Poem);
            part4.Addpart(part3.Poem);
            part5.Addpart(part4.Poem);
            part6.Addpart(part5.Poem);
            part7.Addpart(part6.Poem);
            part8.Addpart(part7.Poem);
            part9.Addpart(part8.Poem);

            part9.Poem.ForEach(Console.WriteLine);
        }
    }

    class Part1
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "Вот дом,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part2
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "А это пшеница,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part3
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "А это веселая птица-синица,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part4
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "Вот кот,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part5
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "Вот пес без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part6
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "А это корова безрогая,\r\nЛягнувшая старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part7
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "А это старушка, седая и строгая,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part8
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "А это ленивый и толстый пастух,\r\nКоторый бранится с коровницей строгою,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }

    class Part9
    {
        public ImmutableList<string> Poem { get; set; }
        public string Part => "Вот два петуха,\r\nКоторые будят того пастуха,\r\nКоторый бранится с коровницей строгою,\r\nКоторая доит корову безрогую,\r\nЛягнувшую старого пса без хвоста,\r\nКоторый за шиворот треплет кота,\r\nКоторый пугает и ловит синицу,\r\nКоторая часто ворует пшеницу,\r\nКоторая в темном чулане хранится\r\nВ доме,\r\nКоторый построил Джек.";

        public void Addpart(ImmutableList<string> collectionToComplete)
        {
            Poem = collectionToComplete.Add(Part);
        }
    }
}