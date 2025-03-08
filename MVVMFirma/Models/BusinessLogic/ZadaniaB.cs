using MVVMFirma.Models.Entities.EntitiesForView;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class ZadaniaB : DataBaseClass
    {
        #region Constructor
        public ZadaniaB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetZadaniaKeyAndValueItems()
        {
            return
                (
                    from zadania in bazaCRMEntities.Zadania
                    select new KeyAndValue
                    {
                        Key = zadania.IdZadania,
                        Value = zadania.NazwaZadania
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    
    }
}
