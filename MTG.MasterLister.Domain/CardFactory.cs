using System;
using System.Collections.Generic;
using System.Globalization;
using MTG.MasterLister.DataAccess;
using MTG.MasterLister.Domain.Contracts;

namespace MTG.MasterLister.Domain
{
    public class CardFactory : ICardFactory
    {
        public Card GenerateCard(int quantity, string name)
        {
            return new Card(quantity, name);
        }

        public List<Card> GenerateCards(IEnumerable<string> deckListSplitByLine)
        {
            var cards = new List<Card>();

            foreach (var line in deckListSplitByLine)
            {
                var quantity = Convert.ToInt32(line[0].ToString(CultureInfo.InvariantCulture));
                var name = line.Substring(2, line.Length - 2);

                cards.Add(GenerateCard(quantity, name));
            }

            return cards;
        }
    }
}