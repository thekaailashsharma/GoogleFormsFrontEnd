using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace YourNamespace.ViewModels
{
    public class ViewSubmissionsViewModel : BindableObject
    {
        private int _currentIndex;
        private ObservableCollection<Submission> _submissions;

        public ICommand PreviousCommand { get; }
        public ICommand NextCommand { get; }

        private Submission _currentSubmission;
        public Submission CurrentSubmission
        {
            get => _currentSubmission;
            set
            {
                _currentSubmission = value;
                OnPropertyChanged();
            }
        }

        private readonly HttpClient _httpClient;

        public ViewSubmissionsViewModel()
        {
            _httpClient = new HttpClient();
            PreviousCommand = new Command(OnPrevious);
            NextCommand = new Command(OnNext);
            _ = LoadSubmissionsAsync();
        }

        private async Task LoadSubmissionsAsync()
        {
            // Initialize the submissions collection
            _submissions = new ObservableCollection<Submission>();

            // Load the first submission from the backend
            await FetchSubmissionAsync(0);

            // Set the initial current submission
            if (_submissions.Count > 0)
            {
                _currentIndex = 0;
                CurrentSubmission = _submissions[_currentIndex];
            }
        }

        private async Task FetchSubmissionAsync(int index)
        {
            try
            {
                // Replace this URL with your actual backend URL
                var url = $"http://localhost:3000/read?index={index}";
                var submission = await _httpClient.GetFromJsonAsync<Submission>(url);

                if (submission != null)
                {
                    _submissions.Add(submission);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur during the HTTP request
                Console.WriteLine($"Error fetching submission: {ex.Message}");
            }
        }

        private async void OnPrevious()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                CurrentSubmission = _submissions[_currentIndex];
            }
        }

        private async void OnNext()
        {
            if (_currentIndex < _submissions.Count - 1)
            {
                _currentIndex++;
                CurrentSubmission = _submissions[_currentIndex];
            }
            else
            {
                // Fetch the next submission from the backend
                await FetchSubmissionAsync(_currentIndex + 1);

                if (_submissions.Count > _currentIndex + 1)
                {
                    _currentIndex++;
                    CurrentSubmission = _submissions[_currentIndex];
                }
            }
        }
    }

    public class Submission
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GitHubLink { get; set; }
        public string StopwatchTime { get; set; }
    }

    public class CreateSubmissionViewModel : BindableObject
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _gitHubLink;
        private string _stopwatchTime;
        private bool _isRunning;
        private readonly HttpClient _httpClient;
        private readonly Stopwatch _stopwatch;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public string GitHubLink
        {
            get => _gitHubLink;
            set
            {
                _gitHubLink = value;
                OnPropertyChanged();
            }
        }

        public string StopwatchTime
        {
            get => _stopwatchTime;
            set
            {
                _stopwatchTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartStopCommand { get; }
        public ICommand SubmitCommand { get; }

        public CreateSubmissionViewModel()
        {
            _httpClient = new HttpClient();
            _stopwatch = new Stopwatch();
            _isRunning = false;

            StartStopCommand = new Command(OnStartStop);
            SubmitCommand = new Command(async () => await OnSubmitAsync());

            Device.StartTimer(TimeSpan.FromMilliseconds(100), UpdateStopwatchLabel);
        }

        private void OnStartStop()
        {
            if (_isRunning)
            {
                _stopwatch.Stop();
            }
            else
            {
                _stopwatch.Start();
            }
            _isRunning = !_isRunning;
        }

        private bool UpdateStopwatchLabel()
        {
            StopwatchTime = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
            return _isRunning;
        }

        private async Task OnSubmitAsync()
        {
            var submission = new Submission
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                GitHubLink = GitHubLink,
                StopwatchTime = StopwatchTime
            };

            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(submission);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://localhost:3000/submit", content);
                Console.WriteLine(response.Content);
                Debug.WriteLine(response.Content);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Submission successfully created.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to create submission.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}

