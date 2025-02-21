using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Entities.EntitiesForView
{
    public class KlienciForAllView
    {
        public int IdKlienta { get; set; }
        public string NazwaFirmy { get; set; }
        public string OsobowoscPrawna { get; set; }
        public string Email { get; set; }
        public int? Telefon { get; set; }
        public string Wojewodztwo { get; set; }
        public string KodPocztowy { get; set; } 
        public string Powiat { get; set; } 
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string NrBudynku { get; set; }
        public string NrLokalu { get; set; }
        public string Poczta { get; set; }
        public int? Regon { get; set; }
        public int? Nip { get; set; }
        public int? Krs { get; set; }
        public string MediaSpolecznosciowe { get; set; }
        public string DodatkoweInformacje { get; set; }
        public string UzytkownicyImie { get; set; }
        public string UzytkownicyNazwisko { get; set; }
        public string UzytkownicyRola { get; set; }         
        public string ZespolyNazwa { get; set; }
        public string ProjektyNazwaProjektu { get; set; }
    }
}
