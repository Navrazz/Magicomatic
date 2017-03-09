using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Magicomatic.Data;
using Magicomatic.Data.Models;
using Magicomatic.UI.DataRetrievers;
using Magicomatic.UI.Tools;

namespace Magicomatic.UI.Views
{
    public partial class UserInventory : UserControl
    {
        private IEnumerable<UserCard> userInventory;

        public UserInventory()
        {
            InitializeComponent();
        }

        private void buttonOpenUserLibrary_Click(object sender, RoutedEventArgs e)
        {
            string filePath = GetFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                var cardLibrary = new CardRepository(Args.filePath, Args.fileUrl).Retrieve() as List<Card>;

                UserInventoryRepository userInventoryRepository = new UserInventoryRepository(filePath, cardLibrary);

                this.userInventory = userInventoryRepository.Retrieve() as List<UserCard>;

                if (userInventory == null)
                {
                    MessageBox.Show("File is invalid");
                }
                else
                {
                    dataGrid.ItemsSource = userInventory;
                    dataGrid.IsHitTestVisible = true;
                }
            }

            return;
        }

        private void buttonGenerateTradeList_Click(object sender, RoutedEventArgs e)
        {
            if (this.userInventory != null)
            {
                TradeListRetriever tradeListRetriever = new TradeListRetriever();
                IEnumerable<UserCard> tradeList = tradeListRetriever.Retrieve(this.userInventory);

                TradeListViewer tradeListViewer = new TradeListViewer(tradeList);
                tradeListViewer.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                tradeListViewer.Show();
            }

            else return;
        }

        private void dataGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserCard card = dataGrid.SelectedItem as UserCard;
            imageCard.Source = new CardImageRetriever(card).Retrieve();
        }

        private string GetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".csv";
            openFileDialog.ShowDialog();

            return openFileDialog.FileName;
        }


    }
}
