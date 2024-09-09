using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IFileContext
    {
        public void WriteTextFileCurrentFolder(string fileName, string text);
        public string ReadTextFileCurrentFolder(string fileName);
        public string CombineCurrentFolderFileName(string fileName);
    }
}
