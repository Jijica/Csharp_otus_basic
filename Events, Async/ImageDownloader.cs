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
                _urlList.Add(url);
            }
        }
        private static List<string> _urlList = new();
        private List<Task> _taskList = new();

        public async Task DownloadAsync()
        {
            foreach (var url in _urlList)
            {
                _taskList.Add(DownloadUnit(url));
            }
            foreach (var task in _taskList)
            {
                task.Start();
            }
            await Task.WhenAll(_taskList.ToArray());
        }

        public async void DownloadStatus()
        {
            foreach (var task in _taskList)
            {
                if (task.IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                await Console.Out.WriteLineAsync($"{task.Id} is downloaded - {task.IsCompleted}");
                Console.ResetColor();
            }
            await Console.Out.WriteLineAsync();
        }

        private async Task DownloadUnit(string url)
        {
            string fileName;
            fileName = "Otus_Test_" + url.Substring(url.LastIndexOf('/') + 1);
            var myWebClient = new WebClient();
            ImageStarted?.Invoke("Скачивание файла началось");
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, url);
            var task = myWebClient.DownloadFileTaskAsync(url, fileName);
            await task;
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, url);
            ImageCompleted?.Invoke("Скачивание файла закончилось\n");
        }
    }
}
