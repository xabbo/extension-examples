using System;
using System.Reflection;
using System.Windows;

using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly ExampleExtension _extension;

        public MainWindow()
        {
            _extension = new ExampleExtension(App.Port);

            // Set the data context of the window to the extension handler
            // so we can bind to its properties from the UI (XAML)
            DataContext = _extension;

            InitializeComponent();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;

            try
            {
                _extension.Log("Connecting to remote interceptor...");
                await _extension.RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An unhandled error occurred: {ex}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                Application.Current.Shutdown();
            }
        }
    }
}
