using System.Collections.Generic;
using MTG.MasterLister.Domain.Contracts;

namespace MTG.MasterLister.Domain
{
    public class DatabaseAgent : IDatabaseAgent
    {
        private readonly IDatabaseWrapper _databaseWrapper;

        public DatabaseAgent(IDatabaseWrapper databaseWrapper)
        {
            _databaseWrapper = databaseWrapper;
        }

        public List<string> CheckAndUpdateForThoseCards(IEnumerable<Card> cards)
        {
            var updates = new List<string>();

            foreach (var card in cards)
            {
                var actualCardQuantity = _databaseWrapper.CheckQuantityForCard(card.Name);

                if (actualCardQuantity >= card.Quantity) continue;

                _databaseWrapper.UpdateCardQuantity(card.Name, card.Quantity);
                var updateMessage = string.Format("Updated card: {0}. Old quantity was: {1}, new quantity is {2}.", card.Name, actualCardQuantity, card.Quantity);
                updates.Add(updateMessage);
            }

            return updates;
        }
    }
}
