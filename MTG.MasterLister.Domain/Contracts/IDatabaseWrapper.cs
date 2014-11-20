namespace MTG.MasterLister.Domain.Contracts
{
    public interface IDatabaseWrapper
    {
        int CheckQuantityForCard(string cardName);
        void UpdateCardQuantityNeeded(string cardName, int newQuantity);
    }
}