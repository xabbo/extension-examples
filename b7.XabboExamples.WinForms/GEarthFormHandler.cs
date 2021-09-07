using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xabbo.GEarth;
using Xabbo.Interceptor;

namespace b7.XabboExamples.WinForms
{
    // Provides extension behaviour such as showing/hiding the form
    // and shutting down the application when the connection to G-Earth is lost.
    public class GEarthFormHandler
    {
        public GEarthExtension Extension { get; }
        public Form Form { get; }

        public GEarthFormHandler(GEarthExtension extension, Form form)
        {
            Extension = extension;
            Extension.Clicked += OnExtensionClicked;
            Extension.InterceptorDisconnected += OnInterceptorDisconnected;

            Form = form;
            Form.FormClosing += OnFormClosing;
        }

        public async Task RunAsync()
        {
            try
            {
                await Extension.RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }

        private void OnExtensionClicked(object sender, EventArgs e)
        {
            // Show the form if it is not currently visible.
            if (!Form.Visible)
            {
                Form.Show();
            }

            // Attempt to bring the extension form to the foreground.
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
            // Hide the form if the extension is still connected to G-Earth.
            if (Extension.IsInterceptorConnected)
            {
                e.Cancel = true;
                Form.Hide();
            }
        }
    }
}
