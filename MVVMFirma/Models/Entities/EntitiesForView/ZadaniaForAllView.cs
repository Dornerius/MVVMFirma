using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class ZadaniaForAllView
    {
        public int IdZadania { get; set; }
        public string NazwaZadania { get; set; }
        public string OpisZadania { get; set; }
        public string ZespolyNazwa { get; set; }
        public string UzytkownicyImie { get; set; }
        public string UzytkownicyNazwisko { get; set; } 
        public string StatusyNazwaStatusu { get; set; }
        
    }
}
