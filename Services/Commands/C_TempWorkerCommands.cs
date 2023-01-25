using EksamenFinish.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace EksamenFinish.Services.Commands
{
    public class C_TempWorkerCommands : INotifyPropertyChanged
    {
        #region Fields

        private M_TempWorker m_tempWorker;
        private ObservableCollection<M_TempWorker> TempWorkers;
        private S_TempWorkerRepository s_tempWorkerRepository;

        #endregion Fields

        public C_TempWorkerCommands(S_TempWorkerRepository tempWorkerRepository, M_TempWorker tempWorker, ObservableCollection<M_TempWorker> tempWorkers)
        {
            s_tempWorkerRepository = tempWorkerRepository;
            m_tempWorker = tempWorker;
            TempWorkers = tempWorkers;
        }




        #region CreateTempWorkerCommand

        public ICommand CreateTempWorkerCommand
        {
            get
            {
                return new RelayCommand(() => s_tempWorkerRepository.CreateTempWorker(m_tempWorker),
                    () =>
                    {
                        if (string.IsNullOrWhiteSpace(m_tempWorker.FirstName)
                        || string.IsNullOrWhiteSpace(m_tempWorker.LastName)
                        || string.IsNullOrWhiteSpace(m_tempWorker.Address)
                        || string.IsNullOrWhiteSpace(m_tempWorker.City)
                        || (m_tempWorker.ZipCode == 0)
                        || string.IsNullOrWhiteSpace(m_tempWorker.PersonalNumber))
                        {
                            ErrorMessageEmptyBox = "All boxes must have a value";
                            return false;
                        }
                        else
                        {
                            ErrorMessageEmptyBox = "";
                            return true;
                        }
                    });
            }
        }

        #endregion CreateTempWorkerCommand

        #region SearchTempWorkerCommand

        public ICommand SearchTempWorkerCommand => new RelayCommand(() =>
        {
            TempWorkers.Clear();
            var newTempWorkers = s_tempWorkerRepository.SearchWorkers(m_tempWorker);
            foreach (var worker in newTempWorkers)
            {
                TempWorkers.Add(worker);
            }
        }, () => true);

        #endregion

        #region UpdateTempWorker
        public ICommand UpdateTempWorkerCommand => new RelayCommand(() => s_tempWorkerRepository.UpdateTempWorker(m_tempWorker), () => true);

        #endregion

        #region INottifyPropertyChanged_Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INottifyPropertyChanged_Implementation

        #region ErrorMessages

        private string _errorMessageEmptyBox;

        public string ErrorMessageEmptyBox
        {
            get { return _errorMessageEmptyBox; }
            set
            {
                _errorMessageEmptyBox = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        #endregion ErrorMessages
    }
}