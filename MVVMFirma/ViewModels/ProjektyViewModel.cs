using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities.EntitiesForView;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class ProjektyViewModel: WszystkieViewModel<ProjektyForAllView>
    {

        #region Constructor

        public ProjektyViewModel()
            : base("Projekty")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Imie", "Nazwisko", "Nazwa Firmy", "Nazwa Zespołu", "Nazwa Projektu", "Data Rozpoczecia", "Data Zakonczenia", "Status" };
        }

        public override void Sort()
        {
            if (SortField == "Imie")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.UzytkownicyImie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.UzytkownicyNazwisko));
            if (SortField == "Nazwa Firmy")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Nazwa Zespołu")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.ZespolyNazwa));
            if (SortField == "Nazwa Projektu")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.NazwaProjektu));
            if (SortField == "Data Rozpoczecia")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.DataRozpoczecia));
            if (SortField == "Data Zakonczenia")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.DataZakonczenia));
            if (SortField == "Status")
                List = new ObservableCollection<ProjektyForAllView>(List.OrderBy(item => item.StatusyNazwaStatusu));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Imie", "Nazwisko", "Nazwa Firmy", "Nazwa Zespołu", "Nazwa Projektu", "Data Rozpoczecia", "Data Zakonczenia", "Status" };
        }
        public override void Find()
        {
            if (FindField == "Imie")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.UzytkownicyImie != null && item.UzytkownicyImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.UzytkownicyNazwisko != null && item.UzytkownicyNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Nazwa Firmy")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Nazwa Zespołu")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.ZespolyNazwa != null && item.ZespolyNazwa.StartsWith(FindTextBox)));
            if (FindField == "Nazwa Projektu")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.NazwaProjektu != null && item.NazwaProjektu.StartsWith(FindTextBox)));
            if (FindField == "Data Rozpoczecia")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.DataRozpoczecia != null && item.DataRozpoczecia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Data Zakonczenia")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.DataZakonczenia != null && item.DataZakonczenia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<ProjektyForAllView>(List.Where(item => item.StatusyNazwaStatusu != null && item.StatusyNazwaStatusu.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ProjektyForAllView>
                (
                    from projekty in bazaCRMEntities.Projekty
                    select new ProjektyForAllView
                    {
                        UzytkownicyImie = projekty.Uzytkownicy.Imie,
                        UzytkownicyNazwisko = projekty.Uzytkownicy.Nazwisko,
                        KlienciNazwaFirmy = projekty.Klienci1.NazwaFirmy,                        
                        ZespolyNazwa = projekty.Zespoly.Nazwa,
                        NazwaProjektu = projekty.NazwaProjektu,
                        DataRozpoczecia = projekty.DataRozpoczecia,
                        DataZakonczenia = projekty.DataZakonczenia,
                        StatusyNazwaStatusu = projekty.Statusy.NazwaStatusu
                    }
                );
        }

        #endregion

    }
}