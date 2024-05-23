using System.Windows.Forms;

namespace TyTrainer
{
    public partial class InfoWindow : Form
    {
        public InfoWindow(string hotkeyText)
        {
            InitializeComponent();
            LabelHotkey.Text = $"Hotkey List: \r\n{hotkeyText}";
        }

        private void OpenLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LabelSupportInfo.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/seanstan95/Ty2Trainer");
        }
    }
}
