using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class SprzedazB : DataBaseClass
    {
        #region Constructor       
        public SprzedazB(BazaCRMEntities bazaCRMEntities)
            : base(bazaCRMEntities)
        {
        }        
        #endregion
        #region BusinessFunction  
    public decimal? ZestawienieKwotyZamowien(int idProduktuUslugi, int idStatusu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from zamowienia in bazaCRMEntities.Zamowienia
                    where
                    idProduktuUslugi == zamowienia.IdZamowienia &&
                    idStatusu == zamowienia.IdStatusu &&
                    zamowienia.DataZamowienia >= dataOd &&
                    zamowienia.DataZamowienia <= dataDo
                    select zamowienia.Kwota * zamowienia.IloscSztuk
                    ).Sum();



        }
        public decimal? ZestawienieIlosciZamowien(int idProduktuUslugi, int idStatusu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from zamowienia in bazaCRMEntities.Zamowienia
                    where
                    idProduktuUslugi == zamowienia.IdZamowienia &&
                    idStatusu == zamowienia.IdStatusu &&
                    zamowienia.DataZamowienia >= dataOd &&
                    zamowienia.DataZamowienia <= dataDo
                    select zamowienia.IloscSztuk
                    ).Sum();



        }
        #endregion
    } 
}

