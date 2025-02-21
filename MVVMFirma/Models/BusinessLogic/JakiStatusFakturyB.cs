using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class JakiStatusFakturyB : DataBaseClass
    {
        #region Constructor       
        public JakiStatusFakturyB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }
        #endregion
        #region BusinessFunction  
        public int? JakiStatusFaktury(int idKlienta, int IdStatusuFaktury)
        {
            return
                (
                    from faktury in bazaCRMEntities.Faktury
                    where
                    idKlienta == faktury.IdKlienta &&
                    IdStatusuFaktury == faktury.IdStatusuFaktury
                    select faktury.IdStatusuFaktury
                    ).Sum();
        }
        #endregion
    }
}
