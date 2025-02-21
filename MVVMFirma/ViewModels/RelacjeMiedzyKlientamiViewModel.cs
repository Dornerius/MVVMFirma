using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities.EntitiesForView;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class RelacjeMiedzyKlientamiViewModel : WszystkieViewModel<RelacjeMiedzyKlientamiForAllView>
    {

        #region Constructor

        public RelacjeMiedzyKlientamiViewModel()
            : base("Relacje Między Klientami")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Klient #1", "Klient #2", "Opis Relacji" };
        }

        public override void Sort()
        {
            if (SortField == "Klient #1")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Klient #2")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.OrderBy(item => item.Klienci1NazwaFirmy));
            if (SortField == "Opis Relacji")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.OrderBy(item => item.OpisRelacji));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Klient #1", "Klient #2", "Opis Relacji" };
        }
        public override void Find()
        {
            if (FindField == "Klient #1")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Klient #2")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.Where(item => item.Klienci1NazwaFirmy != null && item.Klienci1NazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Opis Relacji")
                List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>(List.Where(item => item.OpisRelacji != null && item.OpisRelacji.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RelacjeMiedzyKlientamiForAllView>
                (
                    from relacjeMiedzyKlientami in bazaCRMEntities.RelacjeMiedzyKlientami
                        
                    select new RelacjeMiedzyKlientamiForAllView
                    {
                        KlienciNazwaFirmy = relacjeMiedzyKlientami.Klienci.NazwaFirmy,
                        Klienci1NazwaFirmy = relacjeMiedzyKlientami.Klienci1.NazwaFirmy,
                        OpisRelacji = relacjeMiedzyKlientami.OpisRelacji
                    }
                );
        }

        #endregion

    }
}