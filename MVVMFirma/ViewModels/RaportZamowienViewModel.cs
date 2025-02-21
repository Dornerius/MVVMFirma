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
    public class RaportZamowienViewModel : WorkspaceViewModel


    {
        #region DB
        BazaCRMEntities bazaCRMEntities;
        #endregion
        #region Constructor


        #endregion

        public RaportZamowienViewModel()
        {
            base.DisplayName = "Raport zamówień";
            bazaCRMEntities = new BazaCRMEntities();
        }

        #region Fields
        private DateTime _DataOd;     

        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IdProduktuUslugi;
        public int IdProduktuUslugi
        {
            get
            {
                return _IdProduktuUslugi;
            }
            set
            {
                if (_IdProduktuUslugi != value)
                {
                    _IdProduktuUslugi = value;
                    OnPropertyChanged(() => IdProduktuUslugi);
                }
            }
        }
        private int _IdStatusu;
        public int IdStatusu
        {
            get
            {
                return _IdStatusu;
            }
            set
            {
                if (_IdStatusu != value)
                {
                    _IdStatusu = value;
                    OnPropertyChanged(() => IdStatusu);
                }
            }
        }
        private decimal? _KwotaZamowien;
        public decimal? KwotaZamowien
        {
            get
            {
                return _KwotaZamowien;
            }
            set
            {
                if (_KwotaZamowien != value)
                {
                    _KwotaZamowien = value;
                    OnPropertyChanged(() => KwotaZamowien);
                }
            }
        }
        private decimal? _IloscZamowien;
        public decimal? IloscZamowien
        {
            get
            {
                return _IloscZamowien;
            }
            set
            {
                if (_IloscZamowien != value)
                {
                    _IloscZamowien = value;
                    OnPropertyChanged(() => IloscZamowien);
                }
            }
        }
        public IQueryable<KeyAndValue> ProduktyUslugiItems
        {
            get
            {
                return new ProduktB(bazaCRMEntities).GetProduktyUslugiKeyAndValueItems();

            }
        }
        public IQueryable<KeyAndValue> StatusyItems
        {
            get
            {
                return new StatusB(bazaCRMEntities).GetStatusyKeyAndValueItems();
            }
        }

        #endregion

        #region Command
        private ICommand _RaportCommand;
        public ICommand RaportCommand
        {
            get
            {
                if (_RaportCommand == null)                
                    _RaportCommand = new BaseCommand(() => this.RaportOnClickButton());
                return _RaportCommand;

            }
        }
        private void RaportOnClickButton()
        {
            KwotaZamowien = new SprzedazB(bazaCRMEntities).ZestawienieKwotyZamowien(IdProduktuUslugi, IdStatusu, DataOd, DataDo);
            IloscZamowien = new SprzedazB(bazaCRMEntities).ZestawienieIlosciZamowien(IdProduktuUslugi, IdStatusu, DataOd, DataDo);


        }
        #endregion
    }
}
