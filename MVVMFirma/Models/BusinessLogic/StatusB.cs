using MVVMFirma.Models.Entities.EntitiesForView;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class StatusB : DataBaseClass
    {
        #region Constructor
        public StatusB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetStatusyKeyAndValueItems()
        {
            return
                (
                    from statusy in bazaCRMEntities.Statusy
                    select new KeyAndValue
                    {
                        Key = statusy.IdStatusu,
                        Value = statusy.NazwaStatusu
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
