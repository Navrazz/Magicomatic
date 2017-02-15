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

        public CardRepository(FileManager fileManager, string filePath)
        {
            this.fileManager = fileManager;
            this.filePath    = filePath;
        }

        public IEnumerable Retrieve()
        {
            CardLibrary = new CardRepositoryFactory(fileManager).CreateRepository(filePath).Retrieve() as IEnumerable<Card>;
            return CardLibrary;
        }
    }
}
