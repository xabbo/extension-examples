using System;
using System.Reflection;
using System.Windows;

using Xabbo.GEarth;

namespace b7.XabboExamples.WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GEarthOptions options = new GEarthOptions
            {
                Title = "xabbo example extension",
                Description = "an example extension using the xabbo framework",
                Author = "b7",
                Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "?",
                CanDelete = false,
                CanLeave = false,
                EnableOnClick = true
            };

            // Set the data context of the window to the extension handler
            // so we can bind to properties on it from XAML
            DataContext = new ExampleExtension(options, 9092);

            InitializeComponent();
        }
    }
}
