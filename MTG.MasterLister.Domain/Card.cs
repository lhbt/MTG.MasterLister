namespace MTG.MasterLister.Domain
{
    public class Card
    {
        public int Quantity { get; set; }
        public string Name { get; set; }

        public Card(int quantity, string name)
        {
            Quantity = quantity;
            Name = name;
        }
    }
}