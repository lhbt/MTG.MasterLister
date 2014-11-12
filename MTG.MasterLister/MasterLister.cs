using System;
using System.Collections.Generic;

namespace MTG.MasterLister
{
    public class MasterLister
    {
        private readonly IDecklistParser _decklistParser;
        private readonly ICardFactory _cardFactory;

        public MasterLister(IDecklistParser decklistParser, ICardFactory cardFactory)
        {
            _decklistParser = decklistParser;
            _cardFactory = cardFactory;
        }

        public void Process(string decklist)
        {
            var deckListSplitByLine = _decklistParser.ParseDecklist(decklist);

            var cards = new List<Card>();

            foreach (var line in deckListSplitByLine)
            {
                var splittedLine = line.Split(' ');
                cards.Add(_cardFactory.GenerateCard(Convert.ToInt32(splittedLine[0]), splittedLine[1]));
            }
        }
    }
}