using System.Windows.Forms;

namespace TyTrainer
{
    public partial class HelpWindow : Form
    {
        public HelpWindow(string name, string type, string information)
        {
            InitializeComponent();
            HelpName.Text = "NAME: " + name;
            DataType.Text = "DATA TYPE: " + type;
            Information.Text = "INFORMATION: " + information;
        }
    }
}
