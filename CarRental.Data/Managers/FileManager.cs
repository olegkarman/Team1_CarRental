using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarRental.Data.Managers
{
    public class FileManager
    {
        public void WriteTextFileCurrentFolder(string fileName, string text)
        {
            string path = CombineCurrentFolderFileName(fileName);

            File.WriteAllText(path, text);
        }

        public string ReadTextFileCurrentFolder(string fileName)
        {
            string path = CombineCurrentFolderFileName(fileName);

            string result = File.ReadAllText(path);

            return result;
        }

        public string CombineCurrentFolderFileName(string fileName)
        {
            string currentFolder = Directory.GetCurrentDirectory();

            string path = currentFolder + "\\" + fileName;

            return path;
        }
    }
}
