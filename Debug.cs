using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Debug : Form
    {
        public static Debug SelfRef { get; set; }
        public Debug()
        {
            InitializeComponent();
            SelfRef = this;
        }

        public void Add_Input(string text)
        {
            Output.Text += Output.Lines.Length + ":" + text + "\n";
            Output.SelectionStart = Output.Text.Length;
            Output.ScrollToCaret();
        }
    }
}
