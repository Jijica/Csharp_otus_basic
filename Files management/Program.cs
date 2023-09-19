namespace Files_management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"c:\Otus\TestDir1",
                path2 = @"c:\Otus\TestDir2";
            FilesHandler.CreateDirectory(path1);
            FilesHandler.CreateDirectory(path2);
            FilesHandler.CreateFiles(path1, 10);
            FilesHandler.CreateFiles(path2, 10);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            FilesHandler.FileWriteName(path1);
            FilesHandler.FileWriteName(path2);
            FilesHandler.FileWriteDateTime(path1);
            FilesHandler.FileWriteDateTime(path2);
            FilesHandler.ReadFiles(path1);
            FilesHandler.ReadFiles(path2);
            Console.WriteLine("Press any key to delete directories and exit");
            Console.ReadKey(true);
            FilesHandler.DeleteDirectory(@"c:\Otus");
        }
    }
}