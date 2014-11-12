using MTG.MasterLister.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace MTG.MasterLister.Tests
{
    public class MasterListerTests
    {
        [Test]
        public void it_should_create_a_card_object_per_line_in_the_decklist()
        {
            var cardFactory = MockRepository.GenerateMock<ICardFactory>();
            const string deckList = @"4 Tarmogoyf";

            var masterLister = new MTGMasterLister(new DecklistParser(), cardFactory);
            masterLister.Process(deckList);

            cardFactory.AssertWasCalled(x => x.GenerateCard(4, "Tarmogoyf"));
        }

        [Test]
        public void it_should_handle_cards_with_complex_names()
        {
            var cardFactory = MockRepository.GenerateMock<ICardFactory>();
            const string deckList = @"4 Deathrite Shaman";

            var masterLister = new MTGMasterLister(new DecklistParser(), cardFactory);
            masterLister.Process(deckList);

            cardFactory.AssertWasCalled(x => x.GenerateCard(4, "Deathrite Shaman"));
        }
    }
}
