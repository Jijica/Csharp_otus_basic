using System.Net;

namespace Events__Async
{
    internal class ImageDownloader
    {
        public event Action<string>? ImageStarted;
        public event Action<string>? ImageCompleted;
        public ImageDownloader(params string[] urls)
        {
            foreach (string url in urls)
            {
                var downloadUnit = new DownloadUnit { Url = url };
                _unitsList.Add(downloadUnit);
            }
        }
        private List<DownloadUnit> _unitsList = new();

        public async Task DownloadAsync()
        {
            foreach (var unit in _unitsList)
            {
                unit.Task = DownloadUnitHandle(unit);
            }
            foreach (var unit in _unitsList)
            {
                unit.Task.Start();
            }
        }

        public async void DownloadStatus()
        {
            foreach (var unit in _unitsList)
            {
                if (unit.Task.IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                await Console.Out.WriteLineAsync($"{unit.FileName} is downloaded - {unit.Task.IsCompleted}");
                Console.ResetColor();
            }
            await Console.Out.WriteLineAsync();
        }

        private async Task DownloadUnitHandle(DownloadUnit unit)
        {
            unit.FileName = "Otus_Test_" + unit.Url.Substring(unit.Url.LastIndexOf('/') + 1);
            var myWebClient = new WebClient();
            ImageStarted?.Invoke("Скачивание файла началось");
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", unit.FileName, unit.Url);
            var task = myWebClient.DownloadFileTaskAsync(unit.Url, unit.FileName);
            await task;
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", unit.FileName, unit.Url);
            ImageCompleted?.Invoke("Скачивание файла закончилось\n");
        }

        private class DownloadUnit
        {
            public string Url { get; set; }
            public Task Task { get; set; }
            public string FileName { get; set; }
        }
    }
}
