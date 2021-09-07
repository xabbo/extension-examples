using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using Xabbo.GEarth;
using Xabbo.Interceptor;

namespace b7.XabboExamples.WpfApp
{
    public class GEarthApplicationHandler
    {
        public GEarthExtension Extension { get; }
        public Application Application { get; }
        public Window Window => Application.MainWindow;

        public GEarthApplicationHandler(GEarthExtension extension, Application application)
        {
            Extension = extension;
            Extension.Clicked += OnExtensionClicked;
            Extension.InterceptorDisconnected += OnInterceptorDisconnected;

            Application = application;
            Window.Closing += OnWindowClosing;
        }

        public async Task RunAsync()
        {
            try
            {
                await Extension.RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Shutdown();
            }
        }

        private void OnExtensionClicked(object? sender, EventArgs e)
        {
            // Show the window if it is not currently visible
            if (!Window.IsVisible)
            {
                Window.Show();
            }

            // Attempt to bring the extension window to the foreground
            Window.Activate();
            Window.BringIntoView();
        }

        private void OnInterceptorDisconnected(object? sender, DisconnectedEventArgs e)
        {
            // Shuts down the application when the connection to G-Earth is lost.
            Application.Shutdown();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            // Hide the form if the extension is still connected to G-Earth.
            if (Extension.IsInterceptorConnected)
            {
                e.Cancel = true;
                Window.Hide();
            }
        }
    }
}
