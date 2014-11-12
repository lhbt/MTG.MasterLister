using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace MTG.MasterLister.Tests
{
    [TestFixture]
    public class MasterListerTests
    {
        [Test]
        public void it_should_throw_an_exception_if_decklist_is_empty()
        {
            const string deckList = @"";
            var exception = new Exception();
            var masterLister = new MasterLister(new DecklistParser(), null);
            try
            {
                masterLister.Process(deckList);
            }
            catch (InvalidOperationException e)
            {
                exception = e;
            }

            Assert.That(exception.Message, Is.EqualTo("Decklist cannot be empty."));
        }

        [Test]
        public void it_should_return_an_error_if_a_line_doesnt_have_a_space_between_quantity_and_card_name()
        {
            const string deckList = @"4Tarmogoyf";
            var exception = new Exception();
            var masterLister = new MasterLister(new DecklistParser(), null);
            try
            {
                masterLister.Process(deckList);
            }
            catch (InvalidOperationException e)
            {
                exception = e;
            }

            Assert.That(exception.Message, Is.EqualTo("Formatting error at line 1."));
        }

        [Test]
        public void it_should_handle_multiple_lines_correctly()
        {
            const string deckList = @"4 Tarmogoyf
4 Duress";
            Exception exception = null;
            var masterLister = new MasterLister(new DecklistParser(), new CardFactory());
            try
            {
                masterLister.Process(deckList);
            }
            catch (InvalidOperationException e)
            {
                exception = e;
            }

            Assert.That(exception, Is.Null);
            
        }

        [Test]
        public void it_should_create_a_card_object_per_line_in_the_decklist()
        {
            var cardFactory = MockRepository.GenerateMock<ICardFactory>();
            const string deckList = @"4 Tarmogoyf";

            var masterLister = new MasterLister(new DecklistParser(), cardFactory);
            masterLister.Process(deckList);
            cardFactory.AssertWasCalled(x => x.GenerateCard(4, "Tarmogoyf"));
        }
    }
}
