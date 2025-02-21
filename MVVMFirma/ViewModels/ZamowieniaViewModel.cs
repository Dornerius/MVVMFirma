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
    public class ZamowieniaViewModel : WszystkieViewModel<ZamowieniaForAllView>
    {

        #region Constructor

        public ZamowieniaViewModel()
            : base("Zamowienia")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Status", "Data Zamowienia", "Kwota", "Produkt/Usluga", "Ilosc Sztuk" };
        }

        public override void Sort()
        {
            if (SortField == "Status")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.StatusNazwaStatusu));
            if (SortField == "Data Zamowienia")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.DataZamowienia));
            if (SortField == "Kwota")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.Kwota));
            if (SortField == "Produkt/Usluga")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.PorduktyUslugiNazwa));
            if (SortField == "Ilosc Sztuk")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.IloscSztuk));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Status", "Data Zamowienia", "Kwota", "Produkt/Usluga", "Ilosc Sztuk" };
        }
        public override void Find()
        {
            if (FindField == "Status")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.StatusNazwaStatusu != null && item.StatusNazwaStatusu.StartsWith(FindTextBox)));
            if (FindField == "Data Zamowienia")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.DataZamowienia != null && item.DataZamowienia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Kwota")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.Kwota != null && item.Kwota.ToString().StartsWith(FindTextBox)));
            if (FindField == "Produkt/Usluga")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.PorduktyUslugiNazwa != null && item.PorduktyUslugiNazwa.StartsWith(FindTextBox)));
            if (FindField == "Ilosc Sztuk")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.IloscSztuk != null && item.IloscSztuk.ToString().StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaForAllView>
                (
                    from zamowienia in bazaCRMEntities.Zamowienia
                    select new ZamowieniaForAllView
                    {
                        IdZamowienia = zamowienia.IdZamowienia,
                        StatusNazwaStatusu = zamowienia.Statusy.NazwaStatusu,
                        DataZamowienia = zamowienia.DataZamowienia,
                        Kwota = zamowienia.Kwota,
                        PorduktyUslugiNazwa = zamowienia.ProduktyUslugi.Nazwa,
                        IloscSztuk = zamowienia.IloscSztuk
                    }
                );
        }

        #endregion

    }
}
