using System;
using MTG.MasterLister.Domain;
using NUnit.Framework;

namespace MTG.MasterLister.Tests
{
    [TestFixture]
    public class DecklistParserTests
    {
        [Test]
        public void it_should_throw_an_exception_if_decklist_is_empty()
        {
            const string deckList = @"";
            var exception = new Exception();
            var classUnderTest = new DecklistParser();
            try
            {
                classUnderTest.ParseDecklist(deckList);
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
            var classUnderTest = new DecklistParser();
            try
            {
                classUnderTest.ParseDecklist(deckList);
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
            var classUnderTest = new DecklistParser();
            try
            {
                classUnderTest.ParseDecklist(deckList);
            }
            catch (InvalidOperationException e)
            {
                exception = e;
            }

            Assert.That(exception, Is.Null);
        }

        [Test]
        public void it_should_trim_empty_lines()
        {
            const string deckList = @"4 Tarmogoyf

4 Duress";
            var classUnderTest = new DecklistParser();
            var lines = classUnderTest.ParseDecklist(deckList);
            Assert.That(lines.Count, Is.EqualTo(2));
        }
    }
}