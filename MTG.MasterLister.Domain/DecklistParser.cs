using System;
using System.Collections.Generic;
using System.Linq;

namespace MTG.MasterLister.Domain
{
    public class DecklistParser : IDecklistParser
    {
        public List<string> ParseDecklist(string decklist)
        {
            if (string.IsNullOrEmpty(decklist))
            {
                throw new InvalidOperationException("Decklist cannot be empty.");
            }

            var deckListSplitByLine = decklist.Split(new [] { '\n', '\r' }).ToList();
            deckListSplitByLine.RemoveAll(string.IsNullOrEmpty);

            foreach (var line in deckListSplitByLine)
            {
                if (!line.Contains(" "))
                {
                    throw new InvalidOperationException("Formatting error at line " +
                                                        (deckListSplitByLine.IndexOf(line) + 1) + ".");
                }
            }

            return deckListSplitByLine;
        }
    }
}