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
    public class RaportKlientowViewModel : WorkspaceViewModel
    {
        #region DB
        BazaCRMEntities bazaCRMEntities;
        #endregion
        #region Constructor

        public RaportKlientowViewModel()
        {
            base.DisplayName = "Raport klientów";
            bazaCRMEntities = new BazaCRMEntities();
        }
        #endregion
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
        private int _IdUzytkownika;

        public int IdUzytkownika
        {
            get
            {
                return _IdUzytkownika;
            }
            set
            {
                if (_IdUzytkownika != value)
                {
                    _IdUzytkownika = value;
                    OnPropertyChanged(() => IdUzytkownika);
                }
            }
        }

        private decimal? _IloscKlientow;
        public decimal? IloscKlientow
        {
            get
            {
                return _IloscKlientow;
            }
            set
            {
                if (_IloscKlientow != value)
                {
                    _IloscKlientow = value;
                    OnPropertyChanged(() => IloscKlientow);
                }
            }
        }
        public IQueryable<KeyAndValue> UzytkownikItems
        {
            get
            {
                return new UzytkownikB(bazaCRMEntities).GetUzytkownikKeyAndValueItems();
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
            IloscKlientow = new IloscKlientowB(bazaCRMEntities).ZestawienieIlosciKlientow(IdUzytkownika, DataOd, DataDo);
        }
        #endregion
    }
}
