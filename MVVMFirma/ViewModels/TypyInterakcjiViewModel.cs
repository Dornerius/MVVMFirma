using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class TypyInterakcjiViewModel : WszystkieViewModel<TypyInterakcji>
    {

        #region Constructor

        public TypyInterakcjiViewModel()
            : base("Typy Interakcji")
        { }

        #endregion
        #region Sort and find
        public override List<string> GetComboBoxSortList()
        {
            return null;
        }

        public override void Sort()
        {

        }

        public override List<string> GetComboBoxFindList()
        {
            return null;
        }
        public override void Find()
        {

        }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypyInterakcji>
                (
                    bazaCRMEntities.TypyInterakcji.ToList()
                );
        }

        #endregion

    }
}