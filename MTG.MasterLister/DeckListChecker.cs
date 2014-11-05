using System.Collections.Generic;
using System.Linq;

namespace MTG.MasterLister
{
    public class DeckListChecker
    {
        public List<string> Process(string deckList)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(deckList))
            {
                errors.Add("Decklist cannot be empty.");
                return errors;
            }

            var deckListSplitByLine = deckList.Split('\n').ToList();

            foreach (var line in deckListSplitByLine)
            {
                if (!line.Contains(" "))
                {
                    errors.Add("Formatting error at line " + (deckListSplitByLine.IndexOf(line) + 1) + ".");
                }
            }

            return errors;
        }
    }
}