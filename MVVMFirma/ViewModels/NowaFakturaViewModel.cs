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
    public class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Constructor
        public NowaFakturaViewModel()
            : base("Nowa faktura")
        {
            DisplayName = "Nowa faktura";
            item = new Faktury();
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
        public string NrFaktury
        {
            get 
            { 
                return item.NrFaktury; 
            }
            set
            {                
                {
                    item.NrFaktury = value;
                    OnPropertyChanged(() => NrFaktury);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
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
        public string KlienciNazwaFirmy{ get; set; }
        public int? KlienciNip { get; set; }
        public int? IdProduktuUslugi
        {
            get
            {
                return item.IdProduktuUslugi;
            }
            set
            {
                {
                    item.IdProduktuUslugi = value;
                    OnPropertyChanged(() => IdProduktuUslugi);
                }
            }
        }
        public int? IloscSztuk
        {
            get
            {
                return item.IloscSztuk;
            }
            set
            {
                {
                    item.IloscSztuk = value;
                    OnPropertyChanged(() => IloscSztuk);
                }
            }
        }

        public decimal? KwotaNetto
        {
            get
            {
                return item.KwotaNetto;
            }
            set
            {
                {
                    item.KwotaNetto = value;
                    OnPropertyChanged(() => KwotaNetto);
                }
            }
        }
        public decimal? KwotaBrutto
        {
            get
            {
                return item.KwotaBrutto;
            }
            set
            {
                {
                    item.KwotaBrutto = value;
                    OnPropertyChanged(() => KwotaBrutto);
                }
            }
        }
        public int? Podatek
        {
            get
            {
                return item.Podatek;
            }
            set
            {
                {
                    item.Podatek = value;
                    OnPropertyChanged(() => Podatek);
                }
            }
        }
        public int? IdRodzajuPlatnosci
        {
            get
            {
                return item.IdRodzajuPlatnosci;
            }
            set
            {
                {
                    item.IdRodzajuPlatnosci = value;
                    OnPropertyChanged(() => IdRodzajuPlatnosci);
                }
            }
        }   
        public int? IdStatusuFaktury
        {
            get
            {
                return item.IdStatusuFaktury;
            }
            set
            {
                {
                    item.IdStatusuFaktury = value;
                    OnPropertyChanged(() => IdStatusuFaktury);
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
        public IQueryable<KeyAndValue> ProduktyUslugiItems
        {
            get
            {
                return new ProduktB(bazaCRMEntities).GetProduktyUslugiKeyAndValueItems();

            }
        }
        public IQueryable<KeyAndValue> RodzajePlatnosciItems
        {
            get
            {
                return new RodzajePlatnosciB(bazaCRMEntities).GetRodzajePlatnosciKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> StatusyFakturyItems
        {
            get
            {
                return new StatusFakturyB(bazaCRMEntities).GetStatusFakturyKeyAndValueItems();
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
            bazaCRMEntities.Faktury.Add(item);
            bazaCRMEntities.SaveChanges();
        }
        

        #endregion
    }


}
