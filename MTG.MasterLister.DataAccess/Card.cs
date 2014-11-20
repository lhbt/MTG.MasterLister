namespace MTG.MasterLister.DataAccess
{
    public class Card
    {
        public int QuantityNeeded { get; set; }
        public int QuantityOwned { get; set; }
        public string Name { get; set; }

        public Card(int quantity, string name)
        {
            QuantityNeeded = quantity;
            Name = name;
        }
    }
}