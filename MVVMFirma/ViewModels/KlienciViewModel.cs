using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities.EntitiesForView;
using MVVMFirma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class KlienciViewModel : WszystkieViewModel<KlienciForAllView>
    {
        #region Constructor

        public KlienciViewModel()
            : base("Klienci")
        { }

        #endregion
        #region Properties
        private KlienciForAllView _WybranyKlient;
        public KlienciForAllView WybranyKlient
        {
            get
            {
                return _WybranyKlient;
            }
            set
            {
                _WybranyKlient = value;
                Messenger.Default.Send(_WybranyKlient);
                OnRequestClose();
            }
        }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa firmy", "Osobowość prawna", "Email", "Telefon", "Województwo", "Kod pocztowy", "Powiat", "Miejscowość", "Ulica", "Nr budynku", "Nr lokalu", "Poczta", "Regon", "Nip", "Krs", "Media społecznościowe", "Dodatkowe informacje", "Imię", "Nazwisko", "Rola", "Nazwa zespołu", "Nazwa projektu" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa firmy")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.NazwaFirmy));
            if (SortField == "Osobowość prawna")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.OsobowoscPrawna));
            if (SortField == "Email")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Email));
            if (SortField == "Telefon")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Telefon));
            if (SortField == "Województwo")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Wojewodztwo));
            if (SortField == "Kod pocztowy")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "Powiat")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Powiat));
            if (SortField == "Miejscowość")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Miejscowosc));
            if (SortField == "Ulica")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Ulica));
            if (SortField == "Nr budynku")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.NrBudynku));
            if (SortField == "Nr lokalu")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.NrLokalu));
            if (SortField == "Poczta")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Poczta));
            if (SortField == "Regon")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Regon));
            if (SortField == "Nip")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Nip));
            if (SortField == "Krs")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.Krs));
            if (SortField == "Media społecznościowe")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.MediaSpolecznosciowe));
            if (SortField == "Dodatkowe informacje")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.DodatkoweInformacje));
            if (SortField == "Imię")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.UzytkownicyImie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.UzytkownicyNazwisko));
            if (SortField == "Rola")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.UzytkownicyRola));
            if (SortField == "Nazwa zespołu")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.ZespolyNazwa));
            if (SortField == "Nazwa projektu")
                List = new ObservableCollection<KlienciForAllView>(List.OrderBy(item => item.ProjektyNazwaProjektu));

        }



        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa firmy", "Osobowość prawna", "Email", "Telefon", "Województwo", "Kod pocztowy", "Powiat", "Miejscowość", "Ulica", "Nr budynku", "Nr lokalu", "Poczta", "Regon", "Nip", "Krs", "Media społecznościowe", "Dodatkowe informacje", "Imię", "Nazwisko", "Rola", "Nazwa zespołu", "Nazwa projektu" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa firmy")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.NazwaFirmy != null && item.NazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Osobowość prawna")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.OsobowoscPrawna != null && item.OsobowoscPrawna.StartsWith(FindTextBox)));
            if (FindField == "Email")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
            if (FindField == "Telefon")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Telefon != null && item.Telefon.ToString().StartsWith(FindTextBox)));
            if (FindField == "Województwo")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Powiat")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Powiat != null && item.Powiat.StartsWith(FindTextBox)));
            if (FindField == "Miejscowość")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Miejscowosc != null && item.Miejscowosc.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Nr budynku")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.NrBudynku != null && item.NrBudynku.StartsWith(FindTextBox)));
            if (FindField == "Nr lokalu")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.NrLokalu != null && item.NrLokalu.StartsWith(FindTextBox)));
            if (FindField == "Poczta")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Poczta != null && item.Poczta.StartsWith(FindTextBox)));
            if (FindField == "Regon")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Regon != null && item.Regon.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nip")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Nip != null && item.Nip.ToString().StartsWith(FindTextBox)));
            if (FindField == "Krs")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.Krs != null && item.Krs.ToString().StartsWith(FindTextBox)));
            if (FindField == "Media społecznościowe")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.MediaSpolecznosciowe != null && item.MediaSpolecznosciowe.StartsWith(FindTextBox)));
            if (FindField == "Dodatkowe informacje")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.DodatkoweInformacje != null && item.DodatkoweInformacje.StartsWith(FindTextBox)));
            if (FindField == "Imię")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.UzytkownicyImie != null && item.UzytkownicyImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.UzytkownicyNazwisko != null && item.UzytkownicyNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Rola")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.UzytkownicyRola != null && item.UzytkownicyRola.StartsWith(FindTextBox)));
            if (FindField == "Nazwa zespołu")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.ZespolyNazwa != null && item.ZespolyNazwa.StartsWith(FindTextBox)));
            if (FindField == "Nazwa projektu")
                List = new ObservableCollection<KlienciForAllView>(List.Where(item => item.ProjektyNazwaProjektu != null && item.ProjektyNazwaProjektu.StartsWith(FindTextBox)));


        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KlienciForAllView>
                (
                    from klienci in bazaCRMEntities.Klienci
                    select new KlienciForAllView
                    {
                        NazwaFirmy = klienci.NazwaFirmy,
                        OsobowoscPrawna = klienci.OsobowoscPrawna,
                        Email = klienci.Email,
                        Telefon = klienci.telefon,
                        Wojewodztwo = klienci.Wojewodztwo,
                        KodPocztowy = klienci.KodPocztowy,
                        Powiat = klienci.Powiat,
                        Miejscowosc = klienci.Miejscowosc,
                        Ulica = klienci.Ulica,
                        NrBudynku = klienci.NrBudynku,
                        NrLokalu = klienci.NrLokalu,
                        Poczta = klienci.Poczta,
                        Regon = klienci.Regon,
                        Nip = klienci.Nip,
                        Krs = klienci.Krs,
                        MediaSpolecznosciowe = klienci.MediaSpolecznosciowe,
                        DodatkoweInformacje = klienci.DodatkoweInformacje,
                        UzytkownicyImie = klienci.Uzytkownicy.Imie,
                        UzytkownicyNazwisko = klienci.Uzytkownicy.Nazwisko,
                        UzytkownicyRola = klienci.Uzytkownicy.Rola,
                        ZespolyNazwa = klienci.Zespoly1.Nazwa,
                        ProjektyNazwaProjektu = klienci.Projekty.NazwaProjektu
                    }


                );
        }

        #endregion

    }
}