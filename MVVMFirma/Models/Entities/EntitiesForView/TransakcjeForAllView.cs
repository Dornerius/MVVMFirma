using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class TransakcjeForAllView
    {
        public int IdTransakcji { get; set; }
        public string StatusyNazwaStatusu { get; set; }
        public string KlienciNazwaFirmy { get; set; }
        public string RodzajTransakcji { get; set; }
        public DateTime? DataTransakcji { get; set; }
        public decimal? KwotaTransakcji { get; set; }
        public string DodatkoweInformacje { get; set; }
    }
}
