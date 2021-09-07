using System;
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

            ExampleExtension extension = new ExampleExtension(
                GEarthOptions.Default
                    .WithTitle("Xabbo WinForms") // defaults to the entry assembly's name
                    //.WithVersion("1.0.0") // defaults to the entry assembly's version
                    .WithDescription("example extension using the Xabbo framework")
                    .WithAuthor("b7")
                    .WithArguments(args) // Applies the command-line arguments to the options
            );

            _ = new GEarthFormHandler(extension, new FormMain(extension)).RunAsync();

            Application.Run();
        }
    }
}
