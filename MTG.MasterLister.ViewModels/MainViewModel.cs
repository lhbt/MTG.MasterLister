using System.Collections.ObjectModel;
using MTG.MasterLister.DataAccess;

namespace MTG.MasterLister.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Card> _cards;

        public ObservableCollection<Card> Cards
        {
            get { return _cards; } 
            set 
            { 
                _cards = value;
                OnPropertyChanged("Cards");
            }
        }

        public MainViewModel()
        {
            
        }

    }
}
