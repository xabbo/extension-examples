using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xabbo.GEarth;

namespace b7.XabboExamples.WinForms
{
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
            ExampleExtension extension = new ExampleExtension(
                GEarthOptions.Default
                    .WithTitle("Xabbo WinForms") // defaults to the entry assembly's name
                    //.WithVersion("1.0.0") // defaults to the entry assembly's version
                    .WithDescription("example extension using the Xabbo framework")
                    .WithAuthor("b7")
                    .WithArguments(args) // Applies the command-line arguments to the options
            );

            // Create the main form, passing in the extension
            FormMain form = new FormMain(extension);

            // Create the extension handler
            GEarthFormHandler handler = new GEarthFormHandler(form, extension);

            // Run the extension
            _ = handler.RunAsync();

            // Run the application
            Application.Run();
        }
    }
}
