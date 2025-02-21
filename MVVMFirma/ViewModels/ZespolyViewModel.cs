using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;
using MVVMFirma.Models.Entities.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class ZespolyViewModel : WszystkieViewModel<ZespolyForAllView>
    {

        #region Constructor

        public ZespolyViewModel()
            : base("Zespoly")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Opis", "Uzytkownik", "Uzytkownik1", "Uzytkownik2", "Uzytkownik3", "Uzytkownik4", "Projekt", "Klient", "Zadanie" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Uzytkownik")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.UzytkownicyImie));
            if (SortField == "Uzytkownik1")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Uzytkownicy1Imie));
            if (SortField == "Uzytkownik2")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Uzytkownicy2Imie));
            if (SortField == "Uzytkownik3")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Uzytkownicy3Imie));
            if (SortField == "Uzytkownik4")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.Uzytkownicy4Imie));
            if (SortField == "Projekt")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.ProjektyNazwaProjektu));
            if (SortField == "Klient")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.KlienciNazwaFirmy));
            if (SortField == "Zadanie")
                List = new ObservableCollection<ZespolyForAllView>(List.OrderBy(item => item.ZadaniaNazwaZadania));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Opis", "Uzytkownik", "Uzytkownik1", "Uzytkownik2", "Uzytkownik3", "Uzytkownik4", "Projekt", "Klient", "Zadanie" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Uzytkownik")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.UzytkownicyImie != null && item.UzytkownicyImie.StartsWith(FindTextBox)));
            if (FindField == "Uzytkownik1")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Uzytkownicy1Imie != null && item.Uzytkownicy1Imie.StartsWith(FindTextBox)));
            if (FindField == "Uzytkownik2")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Uzytkownicy2Imie != null && item.Uzytkownicy2Imie.StartsWith(FindTextBox)));
            if (FindField == "Uzytkownik3")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Uzytkownicy3Imie != null && item.Uzytkownicy3Imie.StartsWith(FindTextBox)));
            if (FindField == "Uzytkownik4")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.Uzytkownicy4Imie != null && item.Uzytkownicy4Imie.StartsWith(FindTextBox)));
            if (FindField == "Projekt")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.ProjektyNazwaProjektu != null && item.ProjektyNazwaProjektu.StartsWith(FindTextBox)));
            if (FindField == "Klient")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.KlienciNazwaFirmy != null && item.KlienciNazwaFirmy.StartsWith(FindTextBox)));
            if (FindField == "Zadanie")
                List = new ObservableCollection<ZespolyForAllView>(List.Where(item => item.ZadaniaNazwaZadania != null && item.ZadaniaNazwaZadania.StartsWith(FindTextBox)));
            
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZespolyForAllView>
                (
                    from zespoly in bazaCRMEntities.Zespoly
                    select new ZespolyForAllView
                    {
                        IdZespolu = zespoly.IdZespolu,
                        Nazwa = zespoly.Nazwa,
                        Opis = zespoly.Opis,
                        UzytkownicyImie = zespoly.Uzytkownicy1.Imie,
                        UzytkownicyNazwisko = zespoly.Uzytkownicy1.Nazwisko,
                        Uzytkownicy1Imie = zespoly.Uzytkownicy2.Imie,
                        Uzytkownicy1Nazwisko = zespoly.Uzytkownicy2.Nazwisko,
                        Uzytkownicy2Imie = zespoly.Uzytkownicy3.Imie,
                        Uzytkownicy2Nazwisko = zespoly.Uzytkownicy3.Nazwisko,
                        Uzytkownicy3Imie = zespoly.Uzytkownicy4.Imie,
                        Uzytkownicy3Nazwisko = zespoly.Uzytkownicy4.Nazwisko,
                        Uzytkownicy4Imie = zespoly.Uzytkownicy5.Imie,
                        Uzytkownicy4Nazwisko = zespoly.Uzytkownicy5.Nazwisko,                        
                        ProjektyNazwaProjektu = zespoly.Projekty1.NazwaProjektu,                        
                        KlienciNazwaFirmy = zespoly.Klienci.NazwaFirmy,
                        ZadaniaNazwaZadania = zespoly.Zadania1.NazwaZadania

                    }
                );
        }

        #endregion

    }
}