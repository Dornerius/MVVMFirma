using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class ZespolyB : DataBaseClass
    {
        #region Constructor
        public ZespolyB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetZespolyKeyAndValueItems()
        {
            return
                (
                    from zespoly in bazaCRMEntities.Zespoly
                    select new KeyAndValue
                    {
                        Key = zespoly.IdZespolu,
                        Value = zespoly.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
