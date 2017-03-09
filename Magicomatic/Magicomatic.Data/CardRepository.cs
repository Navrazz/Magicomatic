using System.Collections.Generic;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Models;

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

        public IEnumerable<Card> Retrieve()
        {
            ICardRepository repository = new CardRepositoryFactory(this.filePath, this.url, this.fileManager).CreateRepository();
            IEnumerable<Card> CardLibrary = repository.Retrieve();
            return CardLibrary;
        }
    }
}
