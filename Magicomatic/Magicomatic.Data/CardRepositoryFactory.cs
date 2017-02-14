using System;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data
{
    public class CardRepositoryFactory
    {
        private FileManager fileManager;

        public CardRepositoryFactory(FileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public virtual ICardRepository CreateRepository(string filePath)
        {
            if (this.fileManager.FileExists(filePath))
            {
                return new CardFileRepository(fileManager, filePath);
            }
            else
            {
                return new CardOnlineRepository(fileManager, filePath);
            }
        }

    }
}
