using System.Collections;
using Magicomatic.Data.Readers;
using Magicomatic.Data.Tools;

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

        public IEnumerable Retrieve()
        {
            return new CardLibraryReader(this.fileManager).Read(filePath);
        }
    }
}
