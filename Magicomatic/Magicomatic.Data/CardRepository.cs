using System.Collections;
using System.Collections.Generic;
using Magicomatic.Data.Model;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data
{
    public class CardRepository : ICardRepository
    {
        private FileManager fileManager;
        private string filePath;

        private IEnumerable CardLibrary;

        public CardRepository(string filePath)
        {
            this.fileManager = new FileManager();
            this.filePath    = filePath;
        }

        public IEnumerable Retrieve()
        {
            CardLibrary = new CardRepositoryFactory(fileManager).CreateRepository(filePath).Retrieve();
            return CardLibrary;
        }
    }
}
