
using EksamenFinish.Services;
using System.Windows.Input;

namespace EksamenFinish.ViewModels.Commands
{
    public class C_TempWorkerCommands
    {
        #region Fields

        
        private VM_TempWorker seletedTempWorker;

        private VM_TempWorkerCollection vm_tempWorkerCollection;
        private S_TempWorkerRepository s_tempWorkerRepository;

        #endregion Fields

        public C_TempWorkerCommands(VM_TempWorker seletedTempWorker)
        {
            this.seletedTempWorker = seletedTempWorker;
            vm_tempWorkerCollection = new VM_TempWorkerCollection();
            s_tempWorkerRepository = new S_TempWorkerRepository();
        }

        #region CreateTempWorkerCommand

        public ICommand CreateTempWorkerCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    s_tempWorkerRepository.CreateTempWorker(seletedTempWorker);
                },
                () => true);

            }
        }

        #endregion CreateTempWorkerCommand

        #region SearchTempWorkerCommand

        public ICommand SearchTempWorkerCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //vm_tempWorkerCollection.TempWorkers.Clear();
                    vm_tempWorkerCollection.GetTempWorkers(seletedTempWorker);
                },
                () => true);
            }
        }

        #endregion SearchTempWorkerCommand

        #region UpdateTempWorker

        public ICommand UpdateTempWorkerCommand => new RelayCommand(() =>
        {
            s_tempWorkerRepository.UpdateTempWorker(seletedTempWorker);
        }, () => true);



        #endregion UpdateTempWorker

        #region DeleteCommand

        public ICommand DeleteTempWorkerCommand => new RelayCommand(() =>
        {
            s_tempWorkerRepository.DeleteTempWorker(seletedTempWorker.Id);
        }, () => true);

        #endregion DeleteCommand
    }
}

// ICommand validation for SearchTempWorker: 

//if (string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.FirstName)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.LastName)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.Address)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.City)
//    || (vm_tempWorkerViewModel.ZipCode == 0)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.PersonalNumber))
//{
//    return false;
//}
//else
//{