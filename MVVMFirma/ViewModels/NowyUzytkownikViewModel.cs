using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyUzytkownikViewModel : JedenViewModel<Uzytkownicy>
    {
        #region Constructor        
        public NowyUzytkownikViewModel()
            :base("Nowy Użytkownik")
        {
            DisplayName = "Nowy użytkownik";
            item = new Uzytkownicy();
            Messenger.Default.Register<KlienciForAllView>(this, getWybranyKlient);

        }
        #endregion
        #region Command
        private BaseCommand _ShowKlienci;
        public ICommand ShowKlienci
        {
            get
            {
                if (_ShowKlienci == null)
                    _ShowKlienci = new BaseCommand(() => showKlienci());
                return _ShowKlienci;
            }
        }
        private void showKlienci()
        {
            Messenger.Default.Send<string>("KlienciAll");
        }
        #endregion
        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public string Nazwisko
        {
            get
            {  
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
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

        public int? Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                item.Telefon = value;
                OnPropertyChanged(() => Telefon);
            }
        }
        public string Rola
        {
            get
            {
                return item.Rola;
            }
            set
            {
                item.Rola = value;
                OnPropertyChanged(() => Rola);
            }
        }
        public int? IdKlienta
        {
            get
            {
                return item.IdKlienta;
            }
            set
            {
                {
                    item.IdKlienta = value;
                    OnPropertyChanged(() => IdKlienta);
                }
            }
        }
        public string KlienciNazwaFirmy { get; set; }
        public int? KlienciNip { get; set; }

        public int? IdProjektu
        {
            get
            {
                return item.IdProjektu;
            }
            set
            {
                {
                    item.IdProjektu = value;
                    OnPropertyChanged(() => IdProjektu);
                }
            }
        }
        public int? IdSzkolenia
        {
            get
            {
                return item.IdSzkolenia;
            }
            set
            {
                {
                    item.IdSzkolenia = value;
                    OnPropertyChanged(() => IdSzkolenia);
                }
            }
        }       
        public int? IdZaespolu
        {
            get
            {
                return item.IdZaespolu;
            }
            set
            {
                {
                    item.IdZaespolu = value;
                    OnPropertyChanged(() => IdZaespolu);
                }
            }
        }

        public int? IdZadania
        {
            get
            {
                return item.IdZadania;
            }
            set
            {
                {
                    item.IdZadania = value;
                    OnPropertyChanged(() => IdZadania);
                }
            }
        }
        #endregion
        #region ComboBoxProps
        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlientB(bazaCRMEntities).GetKlienciKeyAndValueItems();

            }
        }

        public IQueryable<KeyAndValue> ProjektyItems
        {
            get
            {
                return new ProjektyB(bazaCRMEntities).GetProjektyKeyAndValueItems();

            }
        }
        public IQueryable<KeyAndValue> ZespolyItems
        {
            get
            {
                return new ZespolyB(bazaCRMEntities).GetZespolyKeyAndValueItems();

            }
        }

        public IQueryable<KeyAndValue> ZadaniaItems
        {
            get
            {
                return new ZadaniaB(bazaCRMEntities).GetZadaniaKeyAndValueItems();

            }
        }

        private void getWybranyKlient(KlienciForAllView klienci)
        {
            IdKlienta = klienci.IdKlienta;
            KlienciNazwaFirmy = klienci.NazwaFirmy;
            KlienciNip = klienci.Nip;
        }

        public override void Save()
        {
            bazaCRMEntities.Uzytkownicy.Add(item);
            bazaCRMEntities.SaveChanges();
        }
        #endregion


    }
}
