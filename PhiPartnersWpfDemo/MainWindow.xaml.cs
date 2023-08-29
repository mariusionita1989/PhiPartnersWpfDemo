using PhiPartnersWpfDemo.Dto;
using PhiPartnersWpfDemo.Services;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace PhiPartnersWpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IHackerNewsWebService? _webService;
        public MainWindow()
        {
            InitializeComponent();
            var apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            var bestStoriesEndpointUrl = ConfigurationManager.AppSettings["BestStoriesEndpointUrl"];
            if (!string.IsNullOrEmpty(apiBaseUrl) && !string.IsNullOrEmpty(bestStoriesEndpointUrl))
            {
                _webService = new HackerNewsWebService(apiBaseUrl, bestStoriesEndpointUrl);
                RefreshData();
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        public async void RefreshData()
        {
            try
            {
                if (_webService != null)
                {
                    var stories = await _webService.GetBestStoriesAsync();
                    if (stories != null)
                    {
                        storyListView.ItemsSource = stories;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenUrlInBrowser(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening URL: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void storyListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                var selectedItem = (sender as ListView)?.SelectedItem as StoryDto;
                if (selectedItem != null && !string.IsNullOrEmpty(selectedItem.Url))
                {
                    OpenUrlInBrowser(selectedItem.Url);
                }
            }
        }
    }
}
