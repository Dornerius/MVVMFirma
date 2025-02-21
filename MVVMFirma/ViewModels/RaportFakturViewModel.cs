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
    public class RaportFakturViewModel : WorkspaceViewModel
    {
        #region DB
        BazaCRMEntities bazaCRMEntities;
        #endregion        
   
        #region Constructor
     public RaportFakturViewModel()
        {
            base.DisplayName = "Raport faktur";
            bazaCRMEntities = new BazaCRMEntities();
        }
        #endregion

        #region Fields

        private int _IdKlienta;
        public int IdKlienta
        {
            get
            {
                return _IdKlienta;
            }
            set
            {
                if (_IdKlienta != value)
                {
                    _IdKlienta = value;
                    OnPropertyChanged(() => IdKlienta);
                }
            }
        }
        private int _IdStatusuFaktury;
        public int IdStatusuFaktury
        {
            get
            {
                return _IdStatusuFaktury;
            }
            set
            {
                if (_IdStatusuFaktury != value)
                {
                    _IdStatusuFaktury = value;
                    OnPropertyChanged(() => IdStatusuFaktury);
                }
            }
        }
        
        private decimal? _IloscFaktur;
        public decimal? IloscFaktur
        {
            get
            {
                return _IloscFaktur;
            }
            set
            {
                if (_IloscFaktur != value)
                {
                    _IloscFaktur = value;
                    OnPropertyChanged(() => IloscFaktur);
                }
            }
        }
        public IQueryable<KeyAndValue> KlienciItems
        {
            get
            {
                return new KlientB(bazaCRMEntities).GetKlienciKeyAndValueItems();

            }
        }
        public IQueryable<KeyAndValue> StatusyFakturyItems
        {
            get
            {
                return new StatusFakturyB(bazaCRMEntities).GetStatusFakturyKeyAndValueItems();

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
           
            IloscFaktur = new JakiStatusFakturyB(bazaCRMEntities).JakiStatusFaktury(IdKlienta, IdStatusuFaktury);


        }
        #endregion
    }
}
