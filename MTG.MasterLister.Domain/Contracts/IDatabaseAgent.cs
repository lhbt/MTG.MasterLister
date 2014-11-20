using System.Collections.Generic;
using MTG.MasterLister.DataAccess;

namespace MTG.MasterLister.Domain.Contracts
{
    public interface IDatabaseAgent
    {
        List<string> CheckAndUpdateForThoseCards(IEnumerable<Card> cards);
    }
}
