using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    // Если нужен вызов в консоль комманд во время игры, создайте экзепляр этой формы
    // и выводите в консоль данные переменных через строку: Debug.SelfRef.Add_Input($"You var: { varinable }");
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
