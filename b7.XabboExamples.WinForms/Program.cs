using System;
using System.Windows.Forms;

using Xabbo.GEarth;

namespace b7.XabboExamples.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Create an extension using the specified options
        var extension = new ExampleExtension(
            GEarthOptions.FromArgs(args) with { 
                Title = "Xabbo WinForms", // defaults to the entry assembly's name
                // Version = "1.0.0", // defaults to the entry assembly's version
                Description = "example extension using the Xabbo framework",
                Author = "b7",
            }
        );

        // Create the main form, passing in the extension
        var form = new FormMain(extension);

        // Create the extension handler
        var handler = new GEarthFormHandler(form, extension);

        // Run the extension
        _ = handler.RunAsync();

        // Run the application
        Application.Run();
    }
}
