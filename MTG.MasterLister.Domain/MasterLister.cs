using MTG.MasterLister.Domain.Contracts;

namespace MTG.MasterLister.Domain
{
    public class MTGMasterLister
    {
        private readonly IDecklistParser _decklistParser;
        private readonly ICardFactory _cardFactory;
        private readonly IDatabaseAgent _databaseAgent;

        public MTGMasterLister(IDecklistParser decklistParser, ICardFactory cardFactory, IDatabaseAgent databaseAgent)
        {
            _decklistParser = decklistParser;
            _cardFactory = cardFactory;
            _databaseAgent = databaseAgent;
        }

        public void Process(string decklist)
        {
            var deckListSplitByLine = _decklistParser.ParseDecklist(decklist);

            var cards = _cardFactory.GenerateCards(deckListSplitByLine);

            var updates = _databaseAgent.CheckAndUpdateForThoseCards(cards);
        }
    }
}