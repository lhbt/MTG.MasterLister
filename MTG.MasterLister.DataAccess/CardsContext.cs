using System.Data.Entity;

namespace MTG.MasterLister.DataAccess
{
    public class CardsContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
    }
}
