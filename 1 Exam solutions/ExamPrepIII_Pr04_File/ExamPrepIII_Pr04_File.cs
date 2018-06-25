using System;
using System.Collections.Generic;
using System.Linq;


namespace ExamPrepIII_Pr04_File
{
    class ExamPrepIII_Pr04_File
    {
        // 100/100
        static void Main()
        {
            int fileCount = int.Parse(Console.ReadLine());

            List<FileData> listFileInRoots = new List<FileData>();

            for (int i = 0; i < fileCount; i++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { '\\' },StringSplitOptions.RemoveEmptyEntries).ToArray();

                string root = currentLine[0].Trim();
                string fileName = currentLine[currentLine.Length - 1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                long fileSize = long.Parse(currentLine[currentLine.Length - 1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                                

                int isRootExists = listFileInRoots.FindIndex(x => x.Root == root);

                FileData currentRecord = new FileData(root, fileName, fileSize);

                if (isRootExists != -1)
                {
                    if (listFileInRoots[isRootExists].Name == fileName)
                    {
                        listFileInRoots[isRootExists].Size = fileSize;
                    }
                    else
                    {
                        listFileInRoots.Add(currentRecord);
                    }
                    
                }
                else
                {
                    listFileInRoots.Add(currentRecord);
                }
            }

            string[] whatToFind = Console.ReadLine().Split();

            string searchedExt = whatToFind[0].Trim();
            string searchedRoot = whatToFind[2].Trim();

            List<FileData> listSearchedRoot = listFileInRoots.Where(x => x.Root == searchedRoot && x.Name.EndsWith(searchedExt)).OrderByDescending (x => x.Size).ThenBy(x => x.Name).ToList();

            if (listSearchedRoot.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var item in listSearchedRoot)
            {
                Console.WriteLine($"{item.Name} - {item.Size} KB");
            }
        }
    }
    class FileData
    {
        public FileData(string root, string name, long size)
        {
            Root = root;
            Name = name;
            Size = size;
        }

        public string Root { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
    }
}