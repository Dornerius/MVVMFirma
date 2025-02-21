using MVVMFirma.Models.Entities.EntitiesForView;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class StatusFakturyB : DataBaseClass
    {
        #region Constructor
        public StatusFakturyB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetStatusFakturyKeyAndValueItems()
        {
            return
                (
                    from statusFaktury in bazaCRMEntities.StatusFaktury
                    select new KeyAndValue
                    {
                        Key = statusFaktury.IdStatusuFaktury,
                        Value = statusFaktury.NazwaStatusu
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
