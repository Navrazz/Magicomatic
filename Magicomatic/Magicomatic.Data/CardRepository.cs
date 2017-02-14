using System;
using System.Collections;
using System.Collections.Generic;
using Magicomatic.Data.Model;

namespace Magicomatic.Data
{
    class CardRepository : ICardRepository
    {
        private List<Card> CardLibrary;

        public IEnumerable Retrieve(string path)
        {
            throw new NotImplementedException();
        }
    }
}
