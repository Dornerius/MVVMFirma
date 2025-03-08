using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    internal class NoweSzkolenieViewModel : JedenViewModel <Szkolenia>
    {
        #region Constructor
        public NoweSzkolenieViewModel()
            : base("Nowe Szklenie")
        {
            DisplayName = "Nowe Szklenie";
            item = new Szkolenia();

        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public DateTime? DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                {
                    item.DataRozpoczecia = value;
                    OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }
        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                {
                    item.DataZakonczenia = value;
                    OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }
        public string Prowadzacy
        {
            get
            {
                return item.Prowadzacy;
            }
            set
            {
                {
                    item.Prowadzacy = value;
                    OnPropertyChanged(() => Prowadzacy);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            bazaCRMEntities.Szkolenia.Add(item);
            bazaCRMEntities.SaveChanges();
        }
        #endregion
    }
}

