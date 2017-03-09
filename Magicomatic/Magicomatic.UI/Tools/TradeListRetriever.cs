using System.Collections.Generic;
using Magicomatic.Data.Models;

namespace Magicomatic.UI.Tools
{
    class TradeListRetriever
    {
        public IEnumerable<UserCard> Retrieve(IEnumerable<UserCard> userInventory)
        {
            var userTradeList = new List<UserCard>();

            foreach (UserCard card in userInventory)
            {
                if (card.ForTrade > 0)
                {
                    userTradeList.Add(card);
                }
            }
            return userTradeList;
        }
    }
}
