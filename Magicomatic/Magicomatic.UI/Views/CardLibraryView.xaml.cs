using Magicomatic.Data.Model;
using Magicomatic.UI.DataRetrievers;
using System.Windows;
using System.Windows.Controls;

namespace Magicomatic.UI.Views
{
    public partial class CardLibraryView : UserControl
    {
        public CardLibraryView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            CardLibraryDataRetriever model = new CardLibraryDataRetriever();

            dataGrid.ItemsSource = model.RetrieveCardLibrary();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            //logic
        }

        private void dataGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Card card = dataGrid.SelectedItem as Card;
            DataContext = card;
        }

    }
}
