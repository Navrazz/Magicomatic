using System.IO;
using System.Collections;

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
