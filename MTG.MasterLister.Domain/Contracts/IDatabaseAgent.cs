using System.Collections.Generic;

namespace MTG.MasterLister.Domain.Contracts
{
    public interface IDatabaseAgent
    {
        List<string> CheckAndUpdateForThoseCards(IEnumerable<Card> cards);
    }
}
