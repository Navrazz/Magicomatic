using System.Collections;
using System.IO;

namespace Magicomatic.Data.Tools
{
    public class FileManager
    {
        public virtual IEnumerable ReadLines(string path)
        {
            return File.ReadLines(path);
        }
    }
}
