
using Magicomatic.Data;
using Magicomatic.Data.Model;
using System.Collections;

namespace Magicomatic.UI.DataRetrievers
{
    class CardLibraryDataRetriever
    {
        public IEnumerable RetrieveCardLibrary()
        {
            return new CardRepository("CardLibrary.csv").Retrieve();
        }
    }
}
