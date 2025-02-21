using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Entities.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UzytkownikB : DataBaseClass
    {
        #region Constructor
        public UzytkownikB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public IQueryable<KeyAndValue> GetUzytkownikKeyAndValueItems()
        {
            return
                (
                    from uzytkownicy in bazaCRMEntities.Uzytkownicy
                    select new KeyAndValue
                    {
                        Key = uzytkownicy.IdUzytkownika,
                        Value = uzytkownicy.Imie + " " + uzytkownicy.Nazwisko
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
