using System.Collections.Generic;
using Magicomatic.Data.Models;

namespace Magicomatic.Data.Readers
{
    interface IReader
    {
        IEnumerable<Card> Read(string path);
    }
}
