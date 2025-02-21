using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{



    public class NowyKlientViewModel : JedenViewModel<Klienci>
    {
        #region Constructor
        public NowyKlientViewModel()
            : base("Nowy klient")
        {
            DisplayName = "Nowy klient";
            item = new Klienci();
            Messenger.Default.Register<UzytkownicyAllForView>(this, getWybranyUzytkownik);

        }
        #endregion
        #region Command
        private BaseCommand _ShowUzytkownicy;
        public ICommand ShowUzytkownicy
        {
            get
            {
                if (_ShowUzytkownicy == null)
                    _ShowUzytkownicy = new BaseCommand(() => showUzytkownicy());
                return _ShowUzytkownicy;
            }
        }
        private void showUzytkownicy()
        {
            Messenger.Default.Send<string>("UzytkownicyAll");
        }
        #endregion
        #region Properties
        public string NazwaFirmy
        {
            get
            {
                return item.NazwaFirmy;
            }
            set
            {
                item.NazwaFirmy = value;
                OnPropertyChanged(() => NazwaFirmy);
            }
        }
        public string OsobowoscPrawna
        {
            get
            {
                return item.OsobowoscPrawna;
            }
            set
            {
                item.OsobowoscPrawna = value;
                OnPropertyChanged(() => OsobowoscPrawna);
            }
        }
        public int? Telefon
        {
            get
            {
                return item.telefon;
            }
            set
            {
                item.telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }
        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                item.Email = value;
                OnPropertyChanged(() => Email);
            }
        }
        public int? IdUzytkownika
        {
            get
            {
                return item.IdUzytkownika;
            }
            set
            {
                item.IdUzytkownika = value;
                OnPropertyChanged(() => IdUzytkownika);
            }
        }
        public string UzytkownicyImie { get; set; }
        public string UzytkownicyNazwisko { get; set; }
        public int? IdZespolu
        {
            get
            {
                return item.IdZespolu;
            }
            set
            {
                item.IdZespolu = value;
                OnPropertyChanged(() => IdZespolu);
            }
        }
        public int? IdProjektu
        {
            get
            {
                return item.IdProjektu;
            }
            set
            {
                item.IdProjektu = value;
                OnPropertyChanged(() => IdProjektu);
            }
        }

        public string Wojewodztwo
        {
            get
            {
                return item.Wojewodztwo;
            }
            set
            {
                item.Wojewodztwo = value;
                OnPropertyChanged(() => Wojewodztwo);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Powiat
        {
            get
            {
                return item.Powiat;
            }
            set
            {
                item.Powiat = value;
                OnPropertyChanged(() => Powiat);
            }
        }
        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                item.Miejscowosc = value;
                OnPropertyChanged(() => Miejscowosc);
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string NrBudynku
        {
            get
            {
                return item.NrBudynku;
            }
            set
            {
                item.NrBudynku = value;
                OnPropertyChanged(() => NrBudynku);
            }
        }
        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                item.NrLokalu = value;
                OnPropertyChanged(() => NrLokalu);
            }
        }
        public string Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                item.Poczta = value;
                OnPropertyChanged(() => Poczta);
            }
        }
        public int? Regon
        {
            get
            {
                return item.Regon;
            }
            set
            {
                item.Regon = value;
                OnPropertyChanged(() => Regon);
            }
        }
        public int? Nip
        {
            get
            {
                return item.Nip;
            }
            set
            {
                item.Nip = value;
                OnPropertyChanged(() => Nip);
            }
        }
        public int? Krs
        {
            get
            {
                return item.Krs;
            }
            set
            {
                item.Krs = value;
                OnPropertyChanged(() => Krs);
            }
        }
        public string MediaSpolecznosciowe
        {
            get
            {
                return item.MediaSpolecznosciowe;
            }
            set
            {
                item.MediaSpolecznosciowe = value;
                OnPropertyChanged(() => MediaSpolecznosciowe);
            }
        }
        public string DodatkoweInformacje
        {
            get
            {
                return item.DodatkoweInformacje;
            }
            set
            {
                item.DodatkoweInformacje = value;
                OnPropertyChanged(() => DodatkoweInformacje);
            }
        }
        #endregion
        #region ComboBoxProps
        public IQueryable<KeyAndValue> UzytkownicyItems
        {
            get
            {
                return new UzytkownikB(bazaCRMEntities).GetUzytkownikKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> ZespolyItems
        {
            get
            {
                return new ZespolyB(bazaCRMEntities).GetZespolyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> ProjektyItems
        {
            get
            {
                return new ProjektyB(bazaCRMEntities).GetProjektyKeyAndValueItems();
            }
        }
        private void getWybranyUzytkownik(UzytkownicyAllForView uzytkownicy)
        {

            UzytkownicyImie = uzytkownicy.Imie;
            UzytkownicyNazwisko = uzytkownicy.Nazwisko;
        }
        public override void Save()
        {
            bazaCRMEntities.Klienci.Add(item);
            bazaCRMEntities.SaveChanges();
        }

        #endregion

    }
}