using System;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Menu : UserControl
    {
        public static Menu SelfRef { get; set; }

        public Menu()
        {
            InitializeComponent();
            SelfRef = this;
            Dock = DockStyle.Fill;
            ResizeMenubar();
        }

        private void ResizeMenubar()
        {
            MenuBar.Left = Width / 2 - MenuBar.Width / 2;
            MenuBar.Top = Height / 2 - MenuBar.Height / 2;
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            ResizeMenubar();
        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Garage_Click(object sender, EventArgs e)
        {
            MainSpace.SelfRef.Show_Garage();
        }

        private void Menu_StartGame_Click(object sender, EventArgs e)
        {
            if (MainSpace.SelfRef.CarPlayerExmp == null)
                MainSpace.SelfRef.Show_Garage();
            else
                MainSpace.SelfRef.Show_Game();
        }
    }
}
