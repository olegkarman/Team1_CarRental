using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Managers
{
    public class FileDataManager : IFileContext
    {
        // FIELDS

        private const string _noData = "NO DATA";

        // METHODS

        public string IfExistsGetAttributes(string path)
        {
            string attributes;

            if (File.Exists(path))
            {
                attributes = File.GetAttributes(path).ToString();
            }
            else
            {
                attributes = _noData;
            }

            return attributes;
        }

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
