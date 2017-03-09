using System.Collections.Generic;
using Magicomatic.Data.Readers;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Models;

namespace Magicomatic.Data
{
    public class CardFileRepository : ICardRepository
    {
        private string filePath;

        private FileManager fileManager;

        public CardFileRepository(string filePath, FileManager fileManager)
        {
            this.filePath    = filePath;
            this.fileManager = fileManager;
        }

        public IEnumerable<Card> Retrieve()
        {
            return new CardLibraryReader(this.fileManager).Read(filePath);
        }
    }
}
