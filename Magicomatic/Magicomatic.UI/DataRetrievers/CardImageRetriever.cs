using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Magicomatic.Data.Models;

namespace Magicomatic.UI.DataRetrievers
{
    class CardImageRetriever
    {
        private Card card;

        public CardImageRetriever(Card card)
        {
            this.card = card;
        }

        public ImageSource Retrieve()
        {
            //Land cards images won't be retrieve
            if (card.Name == "Plains" || card.Name == "Island" || card.Name == "Swamp" || card.Name == "Mountain" || card.Name == "Forest")
            {
                return null;
            }
            else
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(CardImagePathBuilder(card.Name, card.SetCode), UriKind.Relative);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private string CardImagePathBuilder(string cardName, string cardSet)
        {
           // It's just my local folder where i keep card images. It will change when i figure out place in web to put it.
           // Path is like that for tests only
           return @"D:\Data\Images\" + cardSet + @"\" + cardName + ".full.jpg"; 
        }
    }
}
