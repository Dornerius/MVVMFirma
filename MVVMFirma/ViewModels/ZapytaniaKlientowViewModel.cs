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
    public class ZapytaniaKlientowViewModel : WszystkieViewModel<ZapytaniaKlientowForAllView>
    {

        #region Constructor

        public ZapytaniaKlientowViewModel()
            : base("Zapytania Klientów")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Klient", "Data Zapytania", "Status" };
        }

        public override void Sort()
        {
            if (SortField == "Klient")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Data Zapytania")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.OrderBy(item => item.DataZapytania));
            if (SortField == "Status")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.OrderBy(item => item.StatusyNazwaStatusu));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Klient", "Data Zapytania", "Status" };
        }
        public override void Find()
        {
            if (FindField == "Klient")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Data Zapytania")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.Where(item => item.DataZapytania != null && item.DataZapytania.ToString().StartsWith(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<ZapytaniaKlientowForAllView>(List.Where(item => item.StatusyNazwaStatusu != null && item.StatusyNazwaStatusu.StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZapytaniaKlientowForAllView>
                (
                    from zapytaniaKlientow in bazaCRMEntities.ZapytaniaKlientow
                    select new ZapytaniaKlientowForAllView
                    {
                        IdZapytania = zapytaniaKlientow.IdZapytania,
                        KlienciNazwaFirmy = zapytaniaKlientow.Klienci.NazwaFirmy,                        
                        DataZapytania = zapytaniaKlientow.DataZapytania,
                        TrescZapytania = zapytaniaKlientow.TrescZapytania,
                        StatusyNazwaStatusu= zapytaniaKlientow.Statusy.NazwaStatusu
                    }
                );
        }

        #endregion

    }
}