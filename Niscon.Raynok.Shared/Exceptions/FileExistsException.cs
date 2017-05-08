using System;

namespace Niscon.Raynok.Shared.Exceptions
{
    public class FileExistsException : Exception
    {
        public FileExistsException(string fileName) : base($"File {fileName} already exists") { }
        public FileExistsException(string fileName, Exception innerException) : base($"File {fileName} already exists", innerException) { }
    }
}
