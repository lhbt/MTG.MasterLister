using System;
using System.Collections.Generic;

namespace MTG.MasterLister.Domain
{
    public class MTGMasterLister
    {
        private readonly IDecklistParser _decklistParser;
        private readonly ICardFactory _cardFactory;

        public MTGMasterLister(IDecklistParser decklistParser, ICardFactory cardFactory)
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
                var quantity = Convert.ToInt32(line[0].ToString());
                var name = line.Substring(2, line.Length - 2);

                cards.Add(_cardFactory.GenerateCard(quantity, name));
            }
        }
    }
}