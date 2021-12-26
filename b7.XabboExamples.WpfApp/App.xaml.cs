using System;
using System.Windows;

using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp
{
    public partial class App : Application
    {
        public ExampleExtension? Extension { get; private set; }
        public GEarthApplicationHandler? Handler { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create an extension using the specified options
            Extension = new ExampleExtension(
                GEarthOptions.Default
                    .WithName("Xabbo WPF") // defaults to the entry assembly's name
                    //.WithVersion("1.0.0") // defaults to the entry assembly's version
                    .WithDescription("example extension using the Xabbo framework")
                    .WithAuthor("b7")
                    .WithArguments(e.Args) // Applies the command-line arguments to the options
            );

            // Create the main window, passing in the extension
            MainWindow = new MainWindow(Extension);

            // Create the extension handler
            Handler = new GEarthApplicationHandler(this, Extension);

            // Run the extension
            await Handler.RunAsync();
        }
    }
}
