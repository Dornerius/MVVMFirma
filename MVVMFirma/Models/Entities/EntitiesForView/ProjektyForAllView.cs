using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class ProjektyForAllView
    {
        public string UzytkownicyImie { get; set; }
        public string UzytkownicyNazwisko { get; set; }
        public string KlienciNazwaFirmy { get; set; }
        public string ZespolyNazwa { get; set; }
        public string NazwaProjektu { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string StatusyNazwaStatusu { get; set; }

    }
}
