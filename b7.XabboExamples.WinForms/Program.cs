using System;
using System.Windows.Forms;

namespace b7.XabboExamples.WinForms
{
    static class Program
    {
        public static int Port { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Port = 9092;
            int index = Array.IndexOf(args, "-p");
            if (index >= 0 && (index + 1) < args.Length)
            {
                Port = int.Parse(args[index + 1]);
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
