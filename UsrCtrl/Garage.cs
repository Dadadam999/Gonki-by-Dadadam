using System;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Garage : UserControl
    {
        public Garage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            foreach (Car car in MainSpace.SelfRef.TemplateCars)
                Garage_List_Car.Controls.Add(new Garage_Car(car));
        }

        private void Garage_Back_Click(object sender, EventArgs e)
        {
            MainSpace.SelfRef.Show_Menu();
        }
    }
}
