using System.Collections.Generic;

namespace MTG.MasterLister
{
    public interface IDecklistParser
    {
        List<string> ParseDecklist(string decklist);
    }
}