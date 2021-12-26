using System;
using System.Windows;
using System.Windows.Controls;

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxLog.ScrollToEnd();
        }
    }
}
