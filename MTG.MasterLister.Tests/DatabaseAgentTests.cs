using System.Collections.Generic;
using MTG.MasterLister.Domain;
using MTG.MasterLister.Domain.Contracts;
using NUnit.Framework;
using Rhino.Mocks;

namespace MTG.MasterLister.Tests
{
    [TestFixture]
    public class DatabaseAgentTests
    {
        [Test]
        public void it_should_check_if_the_database_already_contains_a_card()
        {
            const string cardName = "Tarmogoyf";
            var cards = new List<Card>
                {
                    new Card(4, cardName)
                };

            var databaseWrapper = MockRepository.GenerateStub<IDatabaseWrapper>();
            databaseWrapper.Stub(x => x.CheckQuantityForCard(cardName)).Return(2);

            var databaseAgent = new DatabaseAgent(databaseWrapper);

            databaseAgent.CheckAndUpdateForThoseCards(cards);

            databaseWrapper.AssertWasCalled(x => x.CheckQuantityForCard(cardName));
        }
    }
}
