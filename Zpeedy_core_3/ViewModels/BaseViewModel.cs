using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Zpeedy_core_3
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected CancellationTokenSource cancellationSource;
        protected CancellationToken cancellationToken;
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            this.SmallTestCommand = new RelayCommand(SmallTestSelected);
            this.MediumTestCommand = new RelayCommand(MediumTestSelected);
            this.LargeTestCommand = new RelayCommand(LargeTestSelected);
            this.ExitCommand = new RelayCommand(Exit);

            // Set the default test when app is opened for the first time.
            SpeedTestUrl = Constants.MediumTest;
        }

        #region Properties
        protected string SpeedTestUrl { get; set; }

        private string _loaderVisibility;
        public string LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                if (_loaderVisibility == value)
                {
                    return;
                }

                _loaderVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private string _startButtonVisibility;
        public string StartButtonVisibility
        {
            get => _startButtonVisibility;
            set
            {
                if (_startButtonVisibility == value)
                {
                    return;
                }

                _startButtonVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = !_isBusy;

                // Loader image is shown when busy
                if (_isBusy)
                {
                    LoaderVisibility = Constants.Visible;
                    StartButtonVisibility = Constants.Hidden;
                }
                else
                {
                    LoaderVisibility = Constants.Hidden;
                    StartButtonVisibility = Constants.Visible;
                }

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LoaderVisibility)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(StartButtonVisibility)));
            }
        }
        #endregion

        #region Commands
        public ICommand SmallTestCommand { get; set; }
        public ICommand MediumTestCommand { get; set; }
        public ICommand LargeTestCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        #endregion

        #region Methods
        private void SmallTestSelected()
        {
            SpeedTestUrl = Constants.SmallTest;
        }

        private void MediumTestSelected()
        {
            SpeedTestUrl = Constants.MediumTest;
        }

        private void LargeTestSelected()
        {
            SpeedTestUrl = Constants.LargeTest;
        }
        private void Exit()
        {
            Application.Current.Shutdown();
        }
        #endregion

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
