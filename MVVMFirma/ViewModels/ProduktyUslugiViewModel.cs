using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class ProduktyUslugiViewModel : WszystkieViewModel <ProduktyUslugi> 
    {

        #region Constructor

        public ProduktyUslugiViewModel()
            :base("Produkty i uslugi")
        {}

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Opis", "Cena" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<ProduktyUslugi>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<ProduktyUslugi>(List.OrderBy(item => item.Opis));
            if (SortField == "Cena")
                List = new ObservableCollection<ProduktyUslugi>(List.OrderBy(item => item.Cena));
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Opis", "Cena" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<ProduktyUslugi>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<ProduktyUslugi>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Cena")
                List = new ObservableCollection<ProduktyUslugi>(List.Where(item => item.Cena != null && item.Cena.ToString().StartsWith(FindTextBox)));
        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ProduktyUslugi>
                (
                    bazaCRMEntities.ProduktyUslugi.ToList() 
                );
        }

        #endregion

    }
}