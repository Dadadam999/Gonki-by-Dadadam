using System;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Garage_Car : UserControl
    {
        public Car TemplateCar { get; set; }

        public Garage_Car(Car templateCar)
        {
            InitializeComponent();
            TemplateCar = templateCar;

            Car_Sprite.Image = TemplateCar.AnimationDefault.Frame[0];
            Car_Info.Text = $"Name: {TemplateCar.Name}\n" +
                            $"Max_Speed: {TemplateCar.MaxSpeed}\n" +
                            $"Acceleration: {TemplateCar.StepSpeed}\n" +
                            $"Boost: {TemplateCar.BoostSpeed} Charge: {TemplateCar.MaxBoostCharge}";
        }

        private void Car_Sprite_Click(object sender, EventArgs e)
        {
            MainSpace.SelfRef.CarPlayerExmp = TemplateCar.Clone();
            Menu.SelfRef.Car_Selected_Info.Text = $"Selected car {TemplateCar.Name}";
            MainSpace.SelfRef.Show_Menu();
        }
    }
}
