using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class IloscKlientowB : DataBaseClass
    {
        #region Constructor       
        public IloscKlientowB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction  
        public int? ZestawienieIlosciKlientow(int idUzytkownika, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from projekty in bazaCRMEntities.Projekty
                    where
                    idUzytkownika == projekty.IdUzytkownika &&                    
                    projekty.DataRozpoczecia >= dataOd &&
                    projekty.DataRozpoczecia <= dataDo
                    select projekty.IdKlienta
                    ).Sum();
        }
        #endregion
    }
}
