using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class ZamowieniaForAllView
    {
        public int IdZamowienia { get; set; }
        public string StatusNazwaStatusu { get; set; }
        public Nullable<System.DateTime> DataZamowienia { get; set; }
        public Nullable<decimal> Kwota { get; set; }
        public string PorduktyUslugiNazwa { get; set; }
        public int? IloscSztuk { get; set; }


    }
}
