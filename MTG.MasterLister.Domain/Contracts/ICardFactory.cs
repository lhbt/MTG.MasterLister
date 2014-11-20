using System.Collections.Generic;

namespace MTG.MasterLister.Domain.Contracts
{
    public interface ICardFactory
    {
        Card GenerateCard(int quantity, string name);
        List<Card> GenerateCards(IEnumerable<string> deckListSplitByLine);
    }
}