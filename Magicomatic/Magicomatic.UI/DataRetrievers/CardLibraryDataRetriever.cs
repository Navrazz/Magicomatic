using System.Collections;
using Magicomatic.Data;

namespace Magicomatic.UI.DataRetrievers
{
    public class CardLibraryDataRetriever
    {
        public IEnumerable RetrieveCardLibrary(string filePath, string url)
        {
            return new CardRepository(filePath, url).Retrieve();
        }
    }
}
