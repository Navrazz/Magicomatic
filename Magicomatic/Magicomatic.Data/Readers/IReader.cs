using System.Collections;

namespace Magicomatic.Data.Readers
{
    interface IReader
    {
        IEnumerable Read(string path);
    }
}
