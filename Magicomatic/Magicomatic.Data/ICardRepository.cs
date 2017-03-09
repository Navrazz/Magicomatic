using System.Collections.Generic;
using Magicomatic.Data.Models;

namespace Magicomatic.Data
{
    public interface ICardRepository
    {
        IEnumerable<Card> Retrieve();
    }
}
