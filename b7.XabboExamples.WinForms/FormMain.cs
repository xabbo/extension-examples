using System;
using System.Windows.Forms;

namespace b7.XabboExamples.WinForms
{
    public partial class FormMain : Form
    {
        private readonly ExampleExtension _extension;

        public FormMain(ExampleExtension extension)
        {
            _extension = extension;
            _extension.LogMessage += OnLogMessage;

            InitializeComponent();
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
