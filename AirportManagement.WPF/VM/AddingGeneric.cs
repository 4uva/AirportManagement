using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportManagement.WPF.VM
{
    abstract class AddingGeneric<T> : ViewModel
    {
        AirportListViewModel parent;
        public AddingGeneric()
        {
            RelayCommand SaveCommand = new RelayCommand(SaveAndExit, CanSave);
            RelayCommand CancelCommand = new RelayCommand(CancelAndExit, CanCancel);
        }

        void SaveAndExit()
        {
            T addedEntity = Save();
            parent.AddingFinished(addedEntity); // какая сигнатура AddingFinished?
        }

        protected abstract T Save();
        protected abstract bool CanSave();
        bool CanCancel() => true;
        void CancelAndExit()
        {
            parent.AddingFinished(null);
        }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
    }
}
