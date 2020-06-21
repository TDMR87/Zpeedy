using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zpeedy_core_3
{
    class MainUIViewModel : BaseViewModel
    {       
        public MainUIViewModel()
        {
            LoaderVisibility = Constants.Hidden;

            // Instantiate commands.
            this.ExecuteSpeedTestCommand = new RelayCommand(ExecuteSpeedTest);
            this.StopSpeedTestCommand = new RelayCommand(StopSpeedTest);
        }

        #region Properties
        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                NotifyPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ExecuteSpeedTestCommand { get; set; }
        public ICommand StopSpeedTestCommand { get; set; }
        
        #endregion

        #region Methods
        /// <summary>
        /// Starts downloading data from the internet 
        /// and calculates the download speed.
        /// </summary>
        private async void ExecuteSpeedTest()
        {
            IsBusy = true;
            Result = "";
            ErrorMessage = "";

            // Instantiate cancellation token
            cancellationSource = new CancellationTokenSource();
            cancellationToken = cancellationSource.Token;

            // Start timing
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();

            try
            {
                // Create a web client
                using HttpClient httpClient = new HttpClient();

                // Perform a GET request
                using var result = await httpClient.GetAsync(
                                   SpeedTestUrl, 
                                   HttpCompletionOption.ResponseContentRead,
                                   cancellationToken);

                // Read bytes from the result
                byte[] bytes = await result.Content.ReadAsByteArrayAsync();

                // Get the time it took to download the file in seconds
                double seconds = stopwatch.Elapsed.TotalSeconds;

                // Calculate download speed
                double speed = await Calculations.CalculateDownloadSpeed(seconds, bytes.Length);

                // Rounding and formatting
                string megaBytesPerSecond = string.Format("{0:0}", speed);

                // Set the result property
                Result = $"{megaBytesPerSecond} MB/s";
            }
            catch (Exception ex) when (ex is OperationCanceledException) 
            {
                ErrorMessage = "*** Test cancelled ***";
                return;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is ArgumentNullException)
            {
                ErrorMessage = ex.Message;
                return;
            }
            finally
            {
                // Finished work
                IsBusy = false;
            }
        }

        /// <summary>
        /// Cancel tasks.
        /// </summary>
        private void StopSpeedTest()
        {
            // Cancel tasks
            cancellationSource.Cancel();
        }
        #endregion
    }
}
