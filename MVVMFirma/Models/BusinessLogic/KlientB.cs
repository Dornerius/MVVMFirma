using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class KlientB : DataBaseClass
    {
        #region Constructor
        public KlientB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetKlienciKeyAndValueItems()
        {
            return
                (
                    from klienci in bazaCRMEntities.Klienci
                    select new KeyAndValue
                    {
                        Key = klienci.IdKlienta,
                        Value = klienci.NazwaFirmy + " " + klienci.Nip
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
