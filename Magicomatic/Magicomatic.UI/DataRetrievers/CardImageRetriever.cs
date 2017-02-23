using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Magicomatic.Data.Model;

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
            if (card.Name == "Plains" || card.Name == "Island" || card.Name == "Swamp" || card.Name == "Mountain" || card.Name == "Forest")
            {
                return null;
            }
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(CardImagePathBuilder(card.Name, card.SetCode), UriKind.Relative);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private string CardImagePathBuilder(string cardName, string cardSet)
        {
           return @"D:\Data\Images\" + cardSet + @"\" + cardName + ".full.jpg";
        }
    }
}
