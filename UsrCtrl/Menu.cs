using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Menu : UserControl
    {
        public static Menu selfref { get; set; }
        public Menu()
        {
            InitializeComponent();
            selfref = this;
            Dock = DockStyle.Fill;
            resize_menubar();
        }
        void resize_menubar()
        {
            MenuBar.Left = Width / 2 - MenuBar.Width / 2;
            MenuBar.Top = Height / 2 - MenuBar.Height / 2;
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            resize_menubar();
        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Garage_Click(object sender, EventArgs e)
        {
            MainSpace.selfref.show_garage();
        }

        private void Menu_StartGame_Click(object sender, EventArgs e)
        {
            if (MainSpace.selfref.Car_Player_Exmp == null)
                MainSpace.selfref.show_garage();
            else
                MainSpace.selfref.show_game();
        }
    }
}
