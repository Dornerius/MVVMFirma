using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RodzajePlatnosciB : DataBaseClass
    {
        #region Constructor
        public RodzajePlatnosciB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetRodzajePlatnosciKeyAndValueItems()
        {
            return
                (
                    from rodzajePlatnosci in bazaCRMEntities.RodzajePlatnosci
                    select new KeyAndValue
                    {
                        Key = rodzajePlatnosci.IdRodzajuPlatnosci,
                        Value = rodzajePlatnosci.NazwaRodzajuPlatnosci
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
