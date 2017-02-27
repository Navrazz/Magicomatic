using System;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data
{
    public class CardRepositoryFactory
    {
        private string filePath;
        private string url;

        private FileManager fileManager;

        public CardRepositoryFactory(string filePath, string url, FileManager fileManager)
        {
            this.filePath    = filePath;
            this.url         = url;
            this.fileManager = fileManager;
        }

        public virtual ICardRepository CreateRepository()
        {
            if (this.fileManager.FileExists(filePath))
            {
                return new CardFileRepository(filePath, fileManager);
            }
            else
            {
                return new CardOnlineRepository(filePath, url, fileManager);
            }
        }

    }
}
