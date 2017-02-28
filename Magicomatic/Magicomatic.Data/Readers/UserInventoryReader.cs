using System;
using System.Linq;
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
        private IEnumerable cardLibrary;

        public UserInventoryReader(FileManager fileManager, IEnumerable cardLibrary)
        {
            this.fileManager = fileManager;
            this.cardLibrary = cardLibrary;
        }

        public IEnumerable Read(string path)
        {
            int counter = 1;


            List<UserCard> userInventory = new List<UserCard>();
            IEnumerable<string> csvFileRows = fileManager.ReadLines(path) as IEnumerable<string>;

            if (IsFileValid(csvFileRows))
            {
                foreach (string csvFileRow in csvFileRows)
                {
                    if (counter > 1)
                    {
                        UserCard userCard = ReadCard(csvFileRow);
                        userInventory.Add(userCard);
                    }
                    counter++;
                }

                return userInventory;
            }

            return null;

        }

        private bool IsFileValid(IEnumerable<string> csvFileRows)
        {
            var csvFileRowsList = csvFileRows.ToList();
            if (csvFileRowsList[0] == "Count,Tradelist Count,Name,Edition,Card Number,Condition,Language,Foil,Signed,Artist Proof,Altered Art,Misprint,Promo,Textless,My Price")
            {
                return true;
            }

            return false;
        }

        private UserCard ReadCard(string row)
        {
            UserCard userCardWithPartialData = new UserCard();

            var dataRow = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))"); //don't split after comma if words are in quotations

            userCardWithPartialData.Amount    = Int32.Parse(dataRow[Amount]);
            userCardWithPartialData.ForTrade  = Int32.Parse(dataRow[ForTrade]);
            userCardWithPartialData.Name      = dataRow[Name].Replace("\"", "");
            userCardWithPartialData.Set       = dataRow[Set];
            userCardWithPartialData.Condition = dataRow[Condition];
            userCardWithPartialData.Language  = dataRow[Language];
            userCardWithPartialData.Foil      = dataRow[Foil];

            UserCard userCardWithAllData = GetMissingCardData(userCardWithPartialData);

            return userCardWithPartialData;
        }

        private UserCard GetMissingCardData(UserCard userCard)
        {
            Card card = ((List<Card>)cardLibrary).FirstOrDefault(x => x.Name == userCard.Name && x.Set == userCard.Set);
            if (card != null)
            {
                userCard.ID                = card.ID;
                userCard.Number            = card.Number;
                userCard.SetCode           = card.SetCode;
                userCard.Type              = card.Type;
                userCard.Power             = card.Power;
                userCard.Toughness         = card.Toughness;
                userCard.Loyality          = card.Loyality;
                userCard.ManaCost          = card.ManaCost;
                userCard.ConvertedManaCost = card.ConvertedManaCost;
                userCard.Ability           = card.Ability;
                userCard.Ruling            = card.Ruling;
                userCard.Rarity            = card.Rarity;
                userCard.Color             = card.Color;
                userCard.GeneratedMana     = card.GeneratedMana;
                userCard.Flavor            = card.Flavor;
                userCard.Artist            = card.Artist;
            }
            return userCard;
        }
    }
}
