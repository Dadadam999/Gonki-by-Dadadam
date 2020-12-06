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
    public partial class Garage : UserControl
    {
        public Garage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            
            foreach (Car car in MainSpace.selfref.TemplateCars)
                Garage_List_Car.Controls.Add(new Garage_Car(car));
        }

        private void Garage_Back_Click(object sender, EventArgs e)
        {
           MainSpace.selfref.show_menu();
        }
    }
}
