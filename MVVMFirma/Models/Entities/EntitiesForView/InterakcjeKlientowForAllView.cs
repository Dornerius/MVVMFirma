using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class InterakcjeKlientowForAllView
    {
        public string KlienciNazwaFirmy { get; set; }
        public string TypyInterakcjiNazwaTypuInterakcji { get; set; }
        public DateTime? Data { get; set; }
        public string Opis { get; set; }
    }
}
