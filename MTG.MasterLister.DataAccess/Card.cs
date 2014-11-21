using System.ComponentModel.DataAnnotations;

namespace MTG.MasterLister.DataAccess
{
    public class Card
    {
        public int IdealQuantity { get; set; }
        public int OwnedQuantity { get; set; }
        [Key]
        public string Name { get; set; }

        public Card()
        {
            
        }

        public Card(int quantity, string name)
        {
            IdealQuantity = quantity;
            Name = name;
        }
    }
}