using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Debug : Form
    {
        public static Debug selfref { get; set; }
        public Debug()
        {
            InitializeComponent();
            selfref = this;
        }

        public void add_input(string text)
        {
            Output.Text += Output.Lines.Length + ":" + text + "\n" ;
            Output.SelectionStart = Output.Text.Length;
            Output.ScrollToCaret();
        }
    }
}
