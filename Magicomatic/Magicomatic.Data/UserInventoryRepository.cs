using System.Collections;
using System.Collections.Generic;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Models;
using Magicomatic.Data.Readers;
using System;

namespace Magicomatic.Data
{
    public class UserInventoryRepository : ICardRepository
    {
        private string filePath;
        private IEnumerable<Card> cardLibrary;

        private FileManager fileManager;

        public UserInventoryRepository(string filePath, IEnumerable<Card> cardLibrary)
        {
            this.filePath = filePath;
            this.cardLibrary = cardLibrary;

            this.fileManager = new FileManager();
        }

        public IEnumerable<Card> Retrieve()
        {
            return new UserInventoryReader(fileManager, cardLibrary).Read(filePath) as List<UserCard>;
        }
    }
}
