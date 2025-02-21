using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel <T> : WorkspaceViewModel
    {
        #region DB
        protected readonly BazaCRMEntities bazaCRMEntities;

        #endregion

        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }

            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor

        public WszystkieViewModel(String displayname)
        {           
            bazaCRMEntities = new BazaCRMEntities();
            base.DisplayName = displayname;

        }

        #endregion
        #region Sort and Find
        #region Sort
        public string SortField { get; set; }
        public List<String> SortComboboxItems
        {
            get
            {
                return GetComboBoxSortList();
            }

        }
        public abstract List<String> GetComboBoxSortList();
        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        public abstract void Sort();

        #endregion
        #region Find
        public string FindField { get; set; }
        public List<String> FindComboboxItems

        {
            get
            {
                return GetComboBoxFindList();
            }
        }
        public abstract List<String> GetComboBoxFindList();
        public string FindTextBox { get; set; }
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        public abstract void Find();

        #endregion
        #endregion
        #region Helpers
        public abstract void Load();
        private void add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
    }
}
