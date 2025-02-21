using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ProduktB : DataBaseClass
    {
        #region Constructor
        public ProduktB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetProduktyUslugiKeyAndValueItems()
        {
            return 
                (
                    from produktyUslugi in bazaCRMEntities.ProduktyUslugi
                    select new KeyAndValue
                    {
                        Key = produktyUslugi.IdProduktuUslugi,
                        Value = produktyUslugi.Nazwa + " " + produktyUslugi.Cena    
                    }
                ) .ToList().AsQueryable();
        }
        #endregion
    }
}
