using System.Collections;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data
{
    public class CardRepository : ICardRepository
    {
        private string filePath;
        private string url;

        private FileManager fileManager;

        public CardRepository(string filePath, string url)
        {
            this.filePath    = filePath;
            this.url         = url;
            this.fileManager = new FileManager();
        }

        public IEnumerable Retrieve()
        {
            ICardRepository repository = new CardRepositoryFactory(this.filePath, this.url, this.fileManager).CreateRepository();
            IEnumerable CardLibrary = repository.Retrieve();
            return CardLibrary;
        }
    }
}
