using System;
using System.Collections.Generic;
using System.Windows;
using Magicomatic.Data.Models;

namespace Magicomatic.UI.Views
{
    public partial class TradeListViewer : Window
    {
        private IEnumerable<UserCard> userInventory;

        public TradeListViewer(IEnumerable<UserCard> userInventory)
        {
            this.userInventory = userInventory;
            InitializeComponent();
            TextBoxPolulate();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBoxPolulate()
        {
            foreach (UserCard card in userInventory)
            {
                textBox.AppendText(card.ForTrade + " " + card.Name);
                textBox.AppendText(Environment.NewLine);
            }
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBox.Text);
        }
    }
}
