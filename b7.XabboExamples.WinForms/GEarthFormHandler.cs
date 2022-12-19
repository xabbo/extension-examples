using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xabbo.Extension;
using Xabbo.GEarth;

namespace b7.XabboExamples.WinForms;

/*
 * This helper class handles the following basic extension functionality:
 * - Opening / focusing the window when the extension is clicked in G-Earth.
 * - Hiding the window when closed by the user.
 * - Shutting down the extension when the connection to G-Earth is lost.
 */
public class GEarthFormHandler
{
    public Form Form { get; }
    public GEarthExtension Extension { get; }

    public GEarthFormHandler(Form form, GEarthExtension extension)
    {
        Form = form;
        Form.FormClosing += OnFormClosing;

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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }

    private void OnExtensionClicked(object sender, EventArgs e)
    {
        // Shows the form if it is not currently visible.
        if (!Form.Visible)
        {
            Form.Show();
        }

        // Attempts to bring the extension form to the foreground.
        Form.Activate();
        Form.BringToFront();
    }

    private void OnInterceptorDisconnected(object sender, DisconnectedEventArgs e)
    {
        // Shuts down the application when the connection to G-Earth is lost.
        Application.Exit();
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
        // Hides the form instead of closing if the extension is still connected to G-Earth.
        if (Extension.IsInterceptorConnected)
        {
            e.Cancel = true;
            Form.Hide();
        }
    }
}
