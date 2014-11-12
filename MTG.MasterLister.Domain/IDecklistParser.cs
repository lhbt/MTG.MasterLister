using System.Collections.Generic;

namespace MTG.MasterLister.Domain
{
    public interface IDecklistParser
    {
        List<string> ParseDecklist(string decklist);
    }
}