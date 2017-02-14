using System.Collections;

namespace Magicomatic.Data
{
    interface ICardRepository
    {
        IEnumerable Retrieve(string path);
    }
}
