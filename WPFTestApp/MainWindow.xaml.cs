using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetaWeather.NET;

namespace WPFTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LocationSearchButton_Click(object sender, RoutedEventArgs e)
        {
            LocationSearchButton.IsEnabled = false;
            LocationSearch[] locationSearches;
            using (var client = new MetaWeatherClient())
            {
                locationSearches = await client.LocationSearch(LocationSearchTextBox.Text);
            }
            LocationSearchGrid.ItemsSource = locationSearches;
            LocationSearchButton.IsEnabled = true;
        }

        private async void LocationFetchButton_Click(object sender, RoutedEventArgs e)
        {
            LocationFetchButton.IsEnabled = false;
            Location location;
            using (var client = new MetaWeatherClient())
            {
                location = await client.Location(long.Parse(WOEIDTextBox.Text));
            }
            LocationGrid.ItemsSource = new List<Location> { location };
            ForecastGrid.ItemsSource = location.ConsolidatedWeather;
            LocationFetchButton.IsEnabled = true;
        }
    }
}
