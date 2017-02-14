using System.Collections;
using Magicomatic.Data.Readers;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data
{
    public class CardFileRepository : ICardRepository
    {
        private FileManager fileManager;
        private string filePath;

        public CardFileRepository(FileManager fileManager, string filePath)
        {
            this.fileManager = fileManager;
            this.filePath    = filePath;
        }

        public IEnumerable Retrieve()
        {
            return new CardLibraryReader(this.fileManager).Read(filePath);
        }

    }
}
