using PersonsIntoFiles.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Services.Security
{
    internal class FileInfo : IDisposable
    {
        private string _filePath = @"C:\Users\User\source\repos\PersonsIntoFiles\Files";
        private Person _person { get; set; }
        public FileStream _fileStream { get; private set; }
        private bool Disposed = false;
        public FileInfo(Person person)
        {
            _person = person;

        }
        public string CombinePath(string path)
        {
            return Path.Combine(_filePath, path);
        }
        public void Dispose()
        {
            _fileStream.Dispose();
        }
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                    _fileStream.Dispose();
                }
                Disposed = true;
            }

        }
        ~FileInfo()
        {
            Dispose(false);
        }
        public string GetPath => _filePath;
    }
}
