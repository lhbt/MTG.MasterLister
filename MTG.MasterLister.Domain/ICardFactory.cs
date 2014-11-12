namespace MTG.MasterLister.Domain
{
    public interface ICardFactory
    {
        Card GenerateCard(int quantity, string name);
    }

    public class CardFactory : ICardFactory
    {
        public Card GenerateCard(int quantity, string name)
        {
            return new Card(quantity, name);
        }
    }
}