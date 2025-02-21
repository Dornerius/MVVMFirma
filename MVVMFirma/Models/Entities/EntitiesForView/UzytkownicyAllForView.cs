using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class UzytkownicyAllForView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int? Telefon { get; set; }
        public string Rola { get; set; }
        public string ZespolyNazwa { get; set; }
        public string ZadaniaNazwa { get; set; }
        public string ProjektyNazwaProjektu { get; set; }
        public string KlienciNazwaFirmy { get; set; }        
        public string SzkoleniaNazwa { get; set; }

    }
}
