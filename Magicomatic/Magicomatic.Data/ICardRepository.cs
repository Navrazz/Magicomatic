using System.Collections;

namespace Magicomatic.Data
{
    public interface ICardRepository
    {
        IEnumerable Retrieve();
    }
}
