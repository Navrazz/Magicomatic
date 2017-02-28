using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;
using Magicomatic.Data.Models;
using Magicomatic.UI.DataRetrievers;

namespace Magicomatic.UI.Views
{
    public partial class CardLibraryView : UserControl
    {
        private List<Card> cardLibrary;

        public CardLibraryView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            CardLibraryDataRetriever cardLibraryDataRetriever = new CardLibraryDataRetriever();
            cardLibrary = cardLibraryDataRetriever.RetrieveCardLibrary(Args.filePath, Args.fileUrl) as List<Card>;
            dataGrid.ItemsSource = cardLibrary;

            autoCompleteBoxSearch.ItemsSource = GetCardNameList(cardLibrary);
            autoCompleteBoxSearch.PopulateComplete();
        }

        private HashSet<string> GetCardNameList(List<Card> cardList)
        {
            HashSet<string> cardNames = new HashSet<string>();
            foreach (Card card in cardList)
            {
                cardNames.Add(card.Name);
            }
            return cardNames;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var query = cardLibrary.Where(c => c.Name.ToLower().Contains(autoCompleteBoxSearch.Text.ToLower()));
            dataGrid.ItemsSource = query;

            dataGrid.Focus();
            dataGrid.SelectedIndex = 0;

            Card card = dataGrid.SelectedItem as Card;
            LoadCardData(card);
        }

        private void dataGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Card card = dataGrid.SelectedItem as Card;
            LoadCardData(card);
        }

        private void LoadCardData(Card card)
        {
            DataContext = card;
            imageCard.Source = new CardImageRetriever(card).Retrieve();
        }
    }
}
