using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyProduktUslugaViewModel : JedenViewModel<ProduktyUslugi>
    {
        #region Constructor
        public NowyProduktUslugaViewModel()
            : base("Nowy produkt, usługa")
        {
            DisplayName = "Nowy produkt, usługa";
            item = new ProduktyUslugi();

        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            bazaCRMEntities.ProduktyUslugi.Add(item);
            bazaCRMEntities.SaveChanges();
        }
        #endregion
    }


}
