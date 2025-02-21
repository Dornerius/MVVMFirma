using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class ZapytaniaKlientowForAllView
    {
        public int IdZapytania { get; set; }       
        public Nullable<System.DateTime> DataZapytania { get; set; }
        public string KlienciNazwaFirmy { get; set; }
        public string TrescZapytania { get; set; }        
        public string StatusyNazwaStatusu { get; set; }
    }
}
