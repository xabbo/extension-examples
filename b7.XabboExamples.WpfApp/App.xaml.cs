using System;
using System.Windows;
using System.Linq;

namespace b7.XabboExamples.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int Port { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Port = 9092;

            int index = Array.IndexOf(e.Args, "-p");
            if (index >= 0 && e.Args.Length > (index + 1))
            {
                Port = int.Parse(e.Args[index + 1]);
            }
        }
    }
}
