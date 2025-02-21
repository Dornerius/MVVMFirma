using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities.EntitiesForView;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class FakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {

        #region Constructor

        public FakturyViewModel()
            : base("Faktury")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nr Faktury", "Data Wystawienia", "Nazwa", "Cena", "Ilosc Sztuk", "Kwota Netto", "Podatek", "Kwota Brutto", "Rodzaje Platnosci", "Nazwa Firmy", "Osobowosc Prawna", "Status Faktury" };
        }

        public override void Sort()
        {
            if(SortField== "Nr Faktury")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.NrFaktury));
            if (SortField == "Data Wystawienia")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.DataWystawienia));
            if (SortField == "Nazwa")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.ProduktyUslugiNazwa));
            if (SortField == "Cena")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.ProduktyUslugiCena));
            if (SortField == "Ilosc Sztuk")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.IloscSztuk));
            if (SortField == "Kwota Netto")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KwotaNetto));
            if (SortField == "Podatek")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Podatek));
            if (SortField == "Kwota Brutto")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KwotaBrutto));
            if (SortField == "Rodzaje Platnosci")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.RodzajePlatnosciNazwaRodzajuPlatnosci));
            if (SortField == "Nazwa Firmy")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Osobowosc Prawna")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KlienciOsobowoscPrawna));
            if (SortField == "Status Faktury")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.StatusFakturyNazwaStatusu));

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nr Faktury", "Data Wystawienia", "Nazwa", "Cena", "Ilosc Sztuk", "Kwota Netto", "Podatek", "Kwota Brutto", "Rodzaje Platnosci", "Nazwa Firmy", "Osobowosc Prawna", "Status Faktury" };
        }
        public override void Find()
        {
            if (FindField == "Nr Faktury")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.NrFaktury != null && item.NrFaktury.StartsWith(FindTextBox)));
            if (FindField == "Data Wystawienia")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.DataWystawienia != null && item.DataWystawienia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.ProduktyUslugiNazwa != null && item.ProduktyUslugiNazwa.StartsWith(FindTextBox)));
            if (FindField == "Cena")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.ProduktyUslugiCena != null && item.ProduktyUslugiCena.ToString().StartsWith(FindTextBox)));
            if (FindField == "Ilosc Sztuk")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.IloscSztuk != null && item.IloscSztuk.ToString().StartsWith(FindTextBox)));
            if (FindField == "Kwota Netto")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KwotaNetto != null && item.KwotaNetto.ToString().StartsWith(FindTextBox)));
            if (FindField == "Podatek")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.Podatek != null && item.Podatek.ToString().StartsWith(FindTextBox)));
            if (FindField == "Kwota Brutto")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KwotaBrutto != null && item.KwotaBrutto.ToString().StartsWith(FindTextBox)));
            if (FindField == "Rodzaje Platnosci")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.RodzajePlatnosciNazwaRodzajuPlatnosci != null && item.RodzajePlatnosciNazwaRodzajuPlatnosci.StartsWith(FindTextBox)));
            if (FindField == "Nazwa Firmy")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Osobowosc Prawna")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.KlienciOsobowoscPrawna != null && item.KlienciOsobowoscPrawna.StartsWith(FindTextBox)));
            if (FindField == "Status Faktury")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.StatusFakturyNazwaStatusu != null && item.StatusFakturyNazwaStatusu.StartsWith(FindTextBox)));

        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                    from faktury in bazaCRMEntities.Faktury
                    select new FakturaForAllView
                    {
                        NrFaktury = faktury.NrFaktury,
                        DataWystawienia = faktury.DataWystawienia,
                        ProduktyUslugiNazwa = faktury.ProduktyUslugi.Nazwa,
                        ProduktyUslugiCena = faktury.ProduktyUslugi.Cena,
                        IloscSztuk = faktury.IloscSztuk,
                        KwotaNetto = faktury.KwotaNetto,
                        Podatek = faktury.Podatek,
                        KwotaBrutto = faktury.KwotaBrutto,
                        RodzajePlatnosciNazwaRodzajuPlatnosci = faktury.RodzajePlatnosci.NazwaRodzajuPlatnosci,
                        KlienciNazwaFirmy = faktury.Klienci.NazwaFirmy,
                        KlienciOsobowoscPrawna = faktury.Klienci.OsobowoscPrawna,
                        StatusFakturyNazwaStatusu = faktury.StatusFaktury.NazwaStatusu
                    }
                );
        }

        #endregion

    }
}
