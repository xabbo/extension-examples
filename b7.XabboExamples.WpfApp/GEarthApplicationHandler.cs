using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using Xabbo.Extension;
using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp;

/*
 * This helper class handles the following basic extension functionality:
 * - Opening / focusing the window when the extension is clicked in G-Earth.
 * - Hiding the window when closed by the user.
 * - Shutting down the extension when the connection to G-Earth is lost.
 */
public class GEarthApplicationHandler
{
    public Application Application { get; }
    public Window Window => Application.MainWindow;
    public GEarthExtension Extension { get; }

    public GEarthApplicationHandler(Application application, GEarthExtension extension)
    {
        Application = application;
        Window.Closing += OnWindowClosing;

        Extension = extension;
        Extension.Clicked += OnExtensionClicked;
        Extension.InterceptorDisconnected += OnInterceptorDisconnected;
    }

    public async Task RunAsync()
    {
        try
        {
            await Extension.RunAsync();
        }
        catch (Exception ex)
        {
            // Shows an error message and shuts down when an unhandled error occurs.
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Application.Shutdown();
        }
    }

    private void OnExtensionClicked(object? sender, EventArgs e)
    {
        // Shows the window if it is not currently visible.
        if (!Window.IsVisible)
        {
            Window.Show();
        }

        // Attempts to bring the extension window to the foreground.
        Window.Activate();
        Window.BringIntoView();
    }

    private void OnInterceptorDisconnected(object? sender, DisconnectedEventArgs e)
    {
        // Shuts down the application when the connection to G-Earth is lost.
        Application.Shutdown();
    }

    private void OnWindowClosing(object? sender, CancelEventArgs e)
    {
        // Hides the window instead of closing if the extension is still connected to G-Earth.
        if (Extension.IsInterceptorConnected)
        {
            e.Cancel = true;
            Window.Hide();
        }
    }
}
