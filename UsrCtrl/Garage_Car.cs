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
    public partial class Garage_Car : UserControl
    {
        public Car car { get; set; }
        
        public Garage_Car(Car car)
        {
            InitializeComponent();
            this.car = car;
            
            Car_Sprite.Image = car.AnimationDefault.Frame[0];
            Car_Info.Text = $"Name: {car.Name}\nMax_Speed: {car.Max_Speed}\nAcceleration: {car.Step_Speed}\nBoost: {car.Boost_Speed} Charge: {car.Max_Boost_Charge}";
        }

        private void Car_Sprite_Click(object sender, EventArgs e)
        {
            MainSpace.selfref.Car_Player_Exmp = car.Clone();
            Menu.selfref.Car_Selected_Info.Text = $"Selected car {car.Name}";
            MainSpace.selfref.show_menu();
        }
    }
}
