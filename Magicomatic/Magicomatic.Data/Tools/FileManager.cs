using System.IO;
using System.Collections;

namespace Magicomatic.Data.Tools
{
    public class FileManager
    {
        public virtual IEnumerable ReadLines(string filePath)
        {
            return File.ReadLines(filePath);
        }

        public virtual bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
