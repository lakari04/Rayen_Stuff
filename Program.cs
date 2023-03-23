using System;
using System.IO;

namespace RayenTest
{
    public class Program
    {

        private const string baseFolderName = "temp_folder";
        private static int structureDepth = 0;
        private static string workingDir;
        private static string workingDirInfo;
        private readonly string directoryPathToSave;

        public static void Initializer()
        {
            workingDir = Directory.GetCurrentDirectory();
            workingDirInfo = new DirectoryInfo(workingDir).Name;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("...........starting.........");

            Initializer();

            var input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    {
                        Console.WriteLine("...........rekusion.........");

                        if (!workingDirInfo.Equals(baseFolderName))
                        {
                            var compositePath = $"{workingDir}\\{baseFolderName}";
                            CreateDirectoriesRecursiv(compositePath);
                        }
                        break;
                    }

                case '2':
                    {
                        Console.WriteLine("...........reference.........");

                        string name = "Test_Folder";
                        HandleReference(ref name);
                        Console.WriteLine($"Foldername: {name}");
                        break;
                    }
                case '3':
                    {
                        Console.WriteLine("...........NO reference.........");

                        string name = "Test_Folder";
                        HandleNoReference(name);

                        Console.WriteLine($"Foldername: {name}");
                        break;
                    }
                case '4':
                    {
                        Console.WriteLine("...........Out.........");

                        string name = "Test_Folder";
                        var id = string.Empty;

                        HandleOut(name, out id);
                        Console.WriteLine($"Foldername: {name}");
                        Console.WriteLine($"ID: {id}");
                        break;
                    }

            }

        }

        private static void HandleReference(ref string folderName)
        {
            var uuid = Guid.NewGuid();
            folderName = $"{folderName}{uuid}";
        }

        private static void HandleOut(string folderName, out string id)
        {
            id = Guid.NewGuid().ToString();
            folderName = $"{folderName}{id}";
        }

        private static void HandleNoReference(string folderName)
        {
            var uuid = Guid.NewGuid();
            folderName = $"{folderName}{uuid}";
        }

        private static void CreateDirectoriesRecursiv(string directoryPathToSave)
        {
            while (structureDepth < 10)
            {
                var newDir = Directory.CreateDirectory($"{directoryPathToSave}\\{structureDepth}").FullName;
                ++structureDepth;
                CreateDirectoriesRecursiv(newDir);
            }
        }


    }
}