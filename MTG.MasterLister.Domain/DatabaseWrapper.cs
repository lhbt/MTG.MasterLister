using System.Data.SQLite;
using System.Linq;
using MTG.MasterLister.DataAccess;
using MTG.MasterLister.Domain.Contracts;

namespace MTG.MasterLister.Domain
{
    public class DatabaseWrapper : IDatabaseWrapper
    {
        private readonly CardsContext _context = new CardsContext();

        public int CheckQuantityForCard(string cardName)
        {
            var quantity = 0;
            var card = _context.Cards.Single(x => x.Name == cardName);

            if (card == null)
                InsertNewCard(cardName);

            else quantity = card.IdealQuantity;
            return quantity;
        }

        public void UpdateCardQuantityNeeded(string cardName, int newQuantity)
        {
            var card = _context.Cards.Single(x => x.Name == cardName);

            if (card == null)
                InsertNewCard(cardName);

            else card.IdealQuantity = newQuantity;

            _context.SaveChanges();
        }

        private void InsertNewCard(string cardName)
        {
            _context.Cards.Add(new Card(0, cardName));
            _context.SaveChanges();
        }
    }
}
