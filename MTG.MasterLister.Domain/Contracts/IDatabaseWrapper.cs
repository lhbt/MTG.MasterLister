namespace MTG.MasterLister.Domain.Contracts
{
    public interface IDatabaseWrapper
    {
        int CheckQuantityForCard(string cardName);
        void UpdateCardQuantity(string cardName, int newQuantity);
    }
}