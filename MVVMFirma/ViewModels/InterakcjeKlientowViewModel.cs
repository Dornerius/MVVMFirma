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
    public class InterakcjeKlientowViewModel : WszystkieViewModel<InterakcjeKlientowForAllView>
    {

        #region Constructor

        public InterakcjeKlientowViewModel()
            : base("Interakcje Klientów")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> {"Klient", "Typ Interakcji", "Data", "Opis" };
        }

        public override void Sort()
        {
           if (SortField=="Klient")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Typ Interakcji")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.OrderBy(item => item.TypyInterakcjiNazwaTypuInterakcji));
            if (SortField == "Data")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.OrderBy(item => item.Data));
            if (SortField == "Opis")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.OrderBy(item => item.Opis));

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Klient", "Typ Interakcji", "Data", "Opis" };
        }
        public override void Find()
        {
           if (FindField== "Klient")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Typ Interakcji")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.Where(item => item.TypyInterakcjiNazwaTypuInterakcji != null && item.TypyInterakcjiNazwaTypuInterakcji.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<InterakcjeKlientowForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<InterakcjeKlientowForAllView>
                (
                    from interakcjeKlientow in bazaCRMEntities.InterakcjeKlientow
                    select new InterakcjeKlientowForAllView
                    {
                        KlienciNazwaFirmy = interakcjeKlientow.Klienci.NazwaFirmy,
                        TypyInterakcjiNazwaTypuInterakcji = interakcjeKlientow.TypyInterakcji.NazwaTypuInterakcji,
                        Data = interakcjeKlientow.Data,
                        Opis = interakcjeKlientow.Opis
                    }
                );
        }

        #endregion

    }
}