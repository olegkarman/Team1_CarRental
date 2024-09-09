using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Managers;

namespace CarRental.BussinessLayer.Managers
{
    public class FileDataManager : FileManager, IFileContext
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
    }
}
