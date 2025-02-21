using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class ZadaniaViewModel : WszystkieViewModel<ZadaniaForAllView>
    {

        #region Constructor

        public ZadaniaViewModel()
            : base("Zadania")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Opis", "Zespół", "Użytkownik", "Status" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<ZadaniaForAllView>(List.OrderBy(item => item.NazwaZadania));
            if (SortField == "Opis")
                List = new ObservableCollection<ZadaniaForAllView>(List.OrderBy(item => item.OpisZadania));
            if (SortField == "Zespół")
                List = new ObservableCollection<ZadaniaForAllView>(List.OrderBy(item => item.ZespolyNazwa));
            if (SortField == "Użytkownik")
                List = new ObservableCollection<ZadaniaForAllView>(List.OrderBy(item => item.UzytkownicyImie));
            if (SortField == "Status")
                List = new ObservableCollection<ZadaniaForAllView>(List.OrderBy(item => item.StatusyNazwaStatusu));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Opis", "Zespół", "Użytkownik", "Status" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<ZadaniaForAllView>(List.Where(item => item.NazwaZadania != null && item.NazwaZadania.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<ZadaniaForAllView>(List.Where(item => item.OpisZadania != null && item.OpisZadania.StartsWith(FindTextBox)));
            if (FindField == "Zespół")
                List = new ObservableCollection<ZadaniaForAllView>(List.Where(item => item.ZespolyNazwa != null && item.ZespolyNazwa.StartsWith(FindTextBox)));
            if (FindField == "Użytkownik")
                List = new ObservableCollection<ZadaniaForAllView>(List.Where(item => item.UzytkownicyImie != null && item.UzytkownicyImie.StartsWith(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<ZadaniaForAllView>(List.Where(item => item.StatusyNazwaStatusu != null && item.StatusyNazwaStatusu.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZadaniaForAllView>
                (
                    from zadania in bazaCRMEntities.Zadania
                    select new ZadaniaForAllView
                    {
                        IdZadania = zadania.IdZadania,
                        NazwaZadania = zadania.NazwaZadania,
                        OpisZadania = zadania.OpicZadania,
                        ZespolyNazwa = zadania.Zespoly.Nazwa,
                        UzytkownicyImie = zadania.Uzytkownicy1.Imie,
                        UzytkownicyNazwisko = zadania.Uzytkownicy1.Nazwisko,
                        StatusyNazwaStatusu = zadania.Statusy.NazwaStatusu
                    }
                );
        }

        #endregion

    }
}