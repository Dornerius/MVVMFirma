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
    public class TransakcjeViewModel : WszystkieViewModel<TransakcjeForAllView>
    {

        #region Constructor

        public TransakcjeViewModel()
            : base("Transakcje")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Status", "Klient", "Rodzaj Transakcji", "Data Transakcji", "Kwota Transakcji", "Dodatkowe Informacje" };
        }

        public override void Sort()
        {
            if (SortField == "Status")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.StatusyNazwaStatusu));
            if (SortField == "Klient")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Rodzaj Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.RodzajTransakcji));
            if (SortField == "Data Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.DataTransakcji));
            if (SortField == "Kwota Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.KwotaTransakcji));
            if (SortField == "Dodatkowe Informacje")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.DodatkoweInformacje));

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Status", "Klient", "Rodzaj Transakcji", "Data Transakcji", "Kwota Transakcji", "Dodatkowe Informacje" };
        }
        public override void Find()
        {
            if (FindField == "Status")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.StatusyNazwaStatusu != null && item.StatusyNazwaStatusu.StartsWith(FindTextBox)));
            if (FindField == "Klient")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Rodzaj Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.RodzajTransakcji != null && item.RodzajTransakcji.StartsWith(FindTextBox)));
            if (FindField == "Data Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.DataTransakcji != null && item.DataTransakcji.ToString().StartsWith(FindTextBox)));

            if (FindField == "Kwota Transakcji")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.KwotaTransakcji != null && item.KwotaTransakcji.ToString().StartsWith(FindTextBox)));
            if (FindField == "Dodatkowe Informacje")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.DodatkoweInformacje != null && item.DodatkoweInformacje.StartsWith(FindTextBox)));
                
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TransakcjeForAllView>
                (
                    from transakcje in bazaCRMEntities.Transakcje
                    select new TransakcjeForAllView
                    {
                        IdTransakcji = transakcje.IdTransakcji,
                        StatusyNazwaStatusu = transakcje.Statusy.NazwaStatusu,
                        KlienciNazwaFirmy = transakcje.Klienci.NazwaFirmy,
                        RodzajTransakcji = transakcje.RodzajTransakcji,
                        DataTransakcji = transakcje.DataTransakcji,
                        KwotaTransakcji = transakcje.KwotaTransakcji,
                        DodatkoweInformacje = transakcje.DodatkoweInformacje
                    }

                );
        }

        #endregion

    }
}