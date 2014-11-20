using System.Collections.Generic;

namespace MTG.MasterLister.Domain.Contracts
{
    public interface IDecklistParser
    {
        List<string> ParseDecklist(string decklist);
    }
}