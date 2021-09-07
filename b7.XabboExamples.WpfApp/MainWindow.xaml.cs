using System;
using System.Windows;

namespace b7.XabboExamples.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly ExampleExtension _extension;

        public MainWindow(ExampleExtension extension)
        {
            _extension = extension;
            // Set the data context of the window to the extension handler
            // so we can bind to its properties from the UI (XAML)
            DataContext = _extension;

            InitializeComponent();
        }
    }
}
