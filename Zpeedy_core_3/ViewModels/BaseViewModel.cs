using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Zpeedy_core_3
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected CancellationTokenSource cancellationSource;
        protected CancellationToken cancellationToken;

        /// <summary>
        /// This event fires for any property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties
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
                    LoaderVisibility = Visible;
                    StartButtonVisibility = Hidden;
                }
                else
                {
                    LoaderVisibility = Hidden;
                    StartButtonVisibility = Visible;
                }

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(LoaderVisibility)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(StartButtonVisibility)));
            }
        }
        #endregion

        public const string Visible = "Visible";
        public const string Hidden = "Hidden";
    }
}
