using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Models;

namespace Magicomatic.Data.Readers
{
    //Reads csv from deckbox.org website
    public class UserInventoryReader : IReader
    {
        private const int Amount = 0;
        private const int ForTrade = 1;
        private const int Name = 2;
        private const int Set = 3;
        private const int Condition = 5;
        private const int Language = 6;
        private const int Foil = 7;

        private FileManager fileManager;

        public UserInventoryReader(FileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public IEnumerable Read(string path)
        {
            int counter = 1;

            List<UserCard> UserInventory = new List<UserCard>();
            IEnumerable csvFileRows = fileManager.ReadLines(path);

            foreach (string csvFileRow in csvFileRows)
            {
                if (counter > 1)
                {
                    UserCard userCard = ReadCard(csvFileRow);
                    UserInventory.Add(userCard);
                }
                counter++;
            }

            return UserInventory;
        }

        private UserCard ReadCard(string row)
        {
            UserCard userCard = new UserCard();

            var dataRow = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))"); //don't split after comma if words are in quotations

            userCard.Amount    = Int32.Parse(dataRow[Amount]);
            userCard.ForTrade  = Int32.Parse(dataRow[ForTrade]);
            userCard.Name      = dataRow[Name].Replace("\"", "");
            userCard.Set       = dataRow[Set];
            userCard.Condition = dataRow[Condition];
            userCard.Language  = dataRow[Language];
            userCard.Foil      = dataRow[Foil];

            return userCard;
        }
    }
}
