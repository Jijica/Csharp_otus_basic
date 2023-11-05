namespace Events__Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageDownloader = new ImageDownloader(
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/08/webb_captures_a_cosmic_whirlpool/25056954-1-eng-GB/Webb_captures_a_cosmic_Whirlpool.jpg",
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/09/webb_snaps_supersonic_outflow_of_young_star/25077917-1-eng-GB/Webb_snaps_supersonic_outflow_of_young_star.jpg",
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/09/webb_confirms_accuracy_of_universe_s_expansion_rate_measured_by_hubble_deepens_mystery_of_hubble_constant_tension/25083695-1-eng-GB/Webb_confirms_accuracy_of_Universe_s_expansion_rate_measured_by_Hubble_deepens_mystery_of_Hubble_Constant_Tension.png",
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/08/galactic_isolation/25068391-1-eng-GB/Galactic_isolation.jpg",
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/09/hubble_dispels_dust_to_see_a_glittering_globular_cluster/25077540-1-eng-GB/Hubble_dispels_dust_to_see_a_glittering_globular_cluster.jpg",
                "https://www.esa.int/var/esa/storage/images/esa_multimedia/images/2023/08/a_sparkling_galactic_neighbour/25050458-1-eng-GB/A_sparkling_galactic_neighbour.jpg",
                "https://stsci-opo.org/STScI-01H44AY5ZTCV1NPB227B2P650J.png",
                "https://www.nasa.gov/sites/default/files/thumbnails/image/30dor_0.jpg",
                "https://www.nasa.gov/sites/default/files/thumbnails/image/stsci-01gtyana7snwzaftfrdhqb8chd.png",
                "https://www.nasa.gov/sites/default/files/thumbnails/image/stsci-01h5mxgsckgd0sxc4v6mbmakdy.jpg"
                );
            imageDownloader.ImageStarted += message => Console.WriteLine(message);
            imageDownloader.ImageCompleted += message => Console.WriteLine(message);
            imageDownloader.DownloadAsync();
            OnButtonPressing(imageDownloader);
        }

        static void OnButtonPressing(ImageDownloader instance)
        {
            var key = new ConsoleKeyInfo();
            Console.WriteLine(@"Нажмите клавишу ""A"" для выхода или любую другую клавишу для проверки статуса скачивания");
            bool aIsPressed;
            do
            {
                key = Console.ReadKey(true);
                aIsPressed = key.Key == ConsoleKey.A;
                if (!aIsPressed)
                {
                    instance.DownloadStatus();
                }
            }
            while (!aIsPressed);
        }
    }
}