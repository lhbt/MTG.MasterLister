using System.Collections.Generic;
using MTG.MasterLister.Domain;
using MTG.MasterLister.Domain.Contracts;
using NUnit.Framework;
using Rhino.Mocks;

namespace MTG.MasterLister.Tests
{
    public class MasterListerTests
    {
        private IDecklistParser _deckListParser;
        private ICardFactory _cardFactory;
        private IDatabaseAgent _databaseAgent;
        private MTGMasterLister _masterLister;

        private const string DeckList = @"4 Tarmogoyf";

        [SetUp]
        public void Setup()
        {
            _deckListParser = MockRepository.GenerateMock<IDecklistParser>();
            _cardFactory = MockRepository.GenerateMock<ICardFactory>();
            _databaseAgent = MockRepository.GenerateMock<IDatabaseAgent>();

            _masterLister = new MTGMasterLister(_deckListParser, _cardFactory, _databaseAgent);
        }

        [Test]
        public void it_should_create_a_card_object_per_line_in_the_decklist()
        {
            _masterLister.Process(DeckList);

            _cardFactory.AssertWasCalled(x => x.GenerateCards(Arg<IEnumerable<string>>.Is.Anything));
        }

        [Test]
        public void it_should_format_the_decklist()
        { 
            _masterLister.Process(DeckList);

            _deckListParser.AssertWasCalled(x => x.ParseDecklist(DeckList));
        }

        [Test]
        public void it_should_check_the_database_for_those_cards()
        {
            _masterLister.Process(DeckList);

            _databaseAgent.AssertWasCalled(x => x.CheckAndUpdateForThoseCards(Arg<IEnumerable<Card>>.Is.Anything));
        }
    }
}
