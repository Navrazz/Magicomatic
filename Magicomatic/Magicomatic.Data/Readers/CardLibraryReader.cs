using System;
using System.Collections;
using System.Collections.Generic;
using Magicomatic.Data.Model;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data.Readers
{
    public class CardLibraryReader
    {
        private const int Name              = 0;
        private const int Set               = 1;
        private const int SetCode           = 2;
        private const int ID                = 3;
        private const int Type              = 4;
        private const int Power             = 5;
        private const int Toughness         = 6;
        private const int Loyality          = 7;
        private const int ManaCost          = 8;
        private const int ConvertedManaCost = 9;
        private const int Artist            = 10;
        private const int Flavor            = 11;
        private const int Color             = 12;
        private const int GeneratedMana     = 13;
        private const int Number            = 14;
        private const int Rarity            = 15;
        private const int Ruling            = 17;
        private const int Ability           = 19;

        private FileManager fileManager;

        public CardLibraryReader(FileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public IEnumerable Read(string path)
        {
            int counter = 1;
            List<Card> CardList = new List<Card>();

            IEnumerable csvFileRows = fileManager.ReadLines(path);

            foreach (string csvFileRow in csvFileRows)
            {
                if (counter > 3)  //read from 3rd row
                {
                    Card card = ReadCard(csvFileRow);
                    CardList.Add(card);
                }
                counter++;
            }

            return CardList;
        }

        private static Card ReadCard(string row)
        {
            Card card = new Card();
            string separator = "||";
            string[] dataRow = row.Split(new[] { separator }, StringSplitOptions.None);

            card.ID                = dataRow[ID];
            card.Number            = dataRow[Number];
            card.Set               = dataRow[Set];
            card.SetCode           = dataRow[SetCode];
            card.Name              = dataRow[Name];
            card.Type              = dataRow[Type];
            card.Power             = dataRow[Power];
            card.Toughness         = dataRow[Toughness];
            card.Loyality          = dataRow[Loyality];
            card.ManaCost          = dataRow[ManaCost];
            card.ConvertedManaCost = dataRow[ConvertedManaCost];
            card.Ability           = TextFormatter(dataRow[Ability]);
            card.Ruling            = TextFormatter(dataRow[Ruling]);
            card.Rarity            = dataRow[Rarity];
            card.Color             = dataRow[Color];
            card.GeneratedMana     = dataRow[GeneratedMana];
            card.Flavor            = TextFormatter(dataRow[Flavor]);
            card.Artist            = dataRow[Artist];

            return card;
        }

        private static string TextFormatter(string text)
        {
            text = text.Replace("_#", "");
            text = text.Replace("#_", "");
            text = text.Replace("£", "\n\n");
            text = text.TrimStart('\n');
            return text;
        }
    }
}
