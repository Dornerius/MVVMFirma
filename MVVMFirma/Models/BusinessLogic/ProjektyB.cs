using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class ProjektyB : DataBaseClass
    {
        #region Constructor
        public ProjektyB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetProjektyKeyAndValueItems()
        {
            return
                (
                    from projekty in bazaCRMEntities.Projekty
                    select new KeyAndValue
                    {
                        Key = projekty.IdProjektu,
                        Value = projekty.NazwaProjektu
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
