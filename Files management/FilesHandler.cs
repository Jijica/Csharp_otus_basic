using System.Text;

namespace Files_management
{
    internal class FilesHandler
    {
        public static void CreateDirectory(string stringPath)
        {
            if (Path.IsPathFullyQualified(stringPath))
            {
                var directoryInfo = new DirectoryInfo(stringPath);
                try
                {
                    directoryInfo.Create();
                    Console.WriteLine($"{directoryInfo.FullName} is created - {directoryInfo.Exists}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid path!");
            }
        }

        public static void DeleteDirectory(string stringPath)
        {
            if (Path.IsPathFullyQualified(stringPath))
            {
                var directoryInfo = new DirectoryInfo(stringPath);
                try
                {
                    directoryInfo.Delete(true);
                    Console.WriteLine($"{directoryInfo.FullName} exists - {directoryInfo.Exists}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid path!");
            }
        }
        public static void CreateFiles(string stringPath, int numberOfFiles)
        {
            var diretoryInfo = new DirectoryInfo(stringPath);
            if (diretoryInfo.Exists)
            {
                for (int index = 1; index < numberOfFiles + 1; index++)
                {
                    var filename = $"File{index}";
                    var filePath = Path.Combine(diretoryInfo.FullName, filename);
                    var fileInfo = new FileInfo(filePath);
                    File.Create(filePath).Close();
                    Console.WriteLine($"{fileInfo.Name} at {fileInfo.DirectoryName} is created - {fileInfo.Exists}");
                }
            }
            else { Console.WriteLine("Catalog does not exist"); }
        }

        public static void FileWriteName(string stringPath)
        {
            var directoryInfo = new DirectoryInfo(stringPath);
            if (directoryInfo.Exists)
            {
                var fileList = directoryInfo.GetFiles();
                foreach (var file in fileList)
                {
                    try
                    {
                        var stream = file.AppendText();
                        stream.WriteLine(file.Name, Encoding.UTF8);
                        stream.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
            }
            else { Console.WriteLine("Catalog does not exist"); }
        }

        public static async Task FileWriteDateTime(string stringPath)
        {
            var directoryInfo = new DirectoryInfo(stringPath);
            if (directoryInfo.Exists)
            {
                var fileList = directoryInfo.GetFiles();
                foreach (var file in fileList)
                {
                    var stream = file.AppendText();
                    await stream.WriteLineAsync(DateTime.Now.ToString());
                    stream.Close();
                }
            }
            else { Console.WriteLine("Catalog does not exist"); }
        }

        public static void ReadFiles(string stringPath)
        {
            var directoryInfo = new DirectoryInfo(stringPath);
            if (directoryInfo.Exists)
            {
                var fileList = directoryInfo.GetFiles();
                foreach (var file in fileList)
                {
                    var stream = file.OpenText();
                    Console.WriteLine($"{file.FullName} : {stream.ReadLine()} + {stream.ReadLine()}");
                    stream.Close();
                }
            }
            else
            {
                Console.WriteLine("Catalog does not exist");
            }
        }
    }
}