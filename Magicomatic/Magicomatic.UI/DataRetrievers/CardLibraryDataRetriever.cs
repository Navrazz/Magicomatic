using System.Collections;
using Magicomatic.Data;

namespace Magicomatic.UI.DataRetrievers
{
    class CardLibraryDataRetriever
    {
        public IEnumerable RetrieveCardLibrary()
        {
            return new CardRepository("CardLibrary.csv", "https://www.dropbox.com/s/xjxk5gonurjt1qe/MTGCardDatabase.csv?dl=1").Retrieve();
        }
    }
}
