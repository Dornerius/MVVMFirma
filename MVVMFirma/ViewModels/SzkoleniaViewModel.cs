using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class SzkoleniaViewModel : WszystkieViewModel<Szkolenia>
    {

        #region Constructor

        public SzkoleniaViewModel()
            : base("Klienci")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Data Rozpoczęcia", "Data Zakończenia", "Prowadzący" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Szkolenia>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Data Rozpoczęcia")
                List = new ObservableCollection<Szkolenia>(List.OrderBy(item => item.DataRozpoczecia));
            if (SortField == "Data Zakończenia")
                List = new ObservableCollection<Szkolenia>(List.OrderBy(item => item.DataZakonczenia));
            if (SortField == "Prowadzący")
                List = new ObservableCollection<Szkolenia>(List.OrderBy(item => item.Prowadzacy));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Data Rozpoczęcia", "Data Zakończenia", "Prowadzący" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<Szkolenia>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Data Rozpoczęcia")
                List = new ObservableCollection<Szkolenia>(List.Where(item => item.DataRozpoczecia != null && item.DataRozpoczecia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Data Zakończenia")
                List = new ObservableCollection<Szkolenia>(List.Where(item => item.DataZakonczenia != null && item.DataZakonczenia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Prowadzący")
                List = new ObservableCollection<Szkolenia>(List.Where(item => item.Prowadzacy != null && item.Prowadzacy.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Szkolenia>
                (
                    bazaCRMEntities.Szkolenia.ToList()
                );
        }

        #endregion

    }
}