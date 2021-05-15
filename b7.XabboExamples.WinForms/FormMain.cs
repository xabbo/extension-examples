using System;
using System.Windows.Forms;

namespace b7.XabboExamples.WinForms
{
    public partial class FormMain : Form
    {
        private readonly ExampleExtension _extension;

        public FormMain()
        {
            _extension = new ExampleExtension(Program.Port);
            _extension.LogMessage += OnLogMessage;

            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                await _extension.RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An unhandled error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                Close();
            }
        }

        private void OnLogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => OnLogMessage(message)));
                return;
            }

            textBoxLog.AppendText(message + Environment.NewLine);
        }

        private void ButtonInjectClient_Click(object sender, EventArgs e) => _extension.InjectPacketClient();
        private void ButtonInjectServer_Click(object sender, EventArgs e) => _extension.InjectPacketServer();

        private void CheckBoxManipulate_CheckedChanged(object sender, EventArgs e)
        {
            _extension.EnablePacketManipulation = checkBoxManipulate.Checked;
        }

        private void checkBoxBlock_CheckedChanged(object sender, EventArgs e)
        {
            _extension.EnablePacketBlocking = checkBoxBlock.Checked;
        }
    }
}
