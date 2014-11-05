using System.Linq;
using NUnit.Framework;

namespace MTG.MasterLister.Tests
{
    [TestFixture]
    public class DeckListCheckerTests
    {
        private readonly DeckListChecker _classUnderTest = new DeckListChecker();

        [Test]
        public void it_should_return_an_error_if_the_decklist_is_an_empty_string()
        {
            const string deckList = @"";
            var errors = _classUnderTest.Process(deckList);

            Assert.That(errors.Count, Is.EqualTo(1));
            Assert.That(errors.First(), Is.EqualTo("Decklist cannot be empty."));
        }

        [Test]
        public void it_should_return_an_error_if_a_line_doesnt_have_a_space_between_quantity_and_card_name()
        {
            const string deckList = @"4Tarmogoyf";
            var errors = _classUnderTest.Process(deckList);

            Assert.That(errors.First(), Is.EqualTo("Formatting error at line 1."));
        }
    }
}
