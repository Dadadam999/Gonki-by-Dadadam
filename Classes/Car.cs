using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class Car
    {
        public string Name { get; set; }
        public Bitmap Sprite { get; set; }
        public float Max_Speed { get; set; }
        public float Current_Speed { get; set; }
        public float Step_Speed { get; set; }

        public float Back_Speed { get; set; }
        public float Boost_Speed { get; set; }
        public float Max_Boost_Charge { get; set; }
        public float Curent_Boost_Charge { get; set; }
        public float Rotate_Right_Speed { get; set; }
        public float Rotate_Left_Speed { get; set; }
        public float Cover_Distance { get; set; }


        public Car()
        {
            Current_Speed = 0;
            Cover_Distance = 0;
            Curent_Boost_Charge = 0;
        }

        public Car Clone()
        {
            Car car = new Car();
            car.Name = Name;
            car.Max_Speed = Max_Speed;
            car.Current_Speed = Current_Speed;
            car.Step_Speed = Step_Speed;
            car.Sprite = Sprite;
            car.Back_Speed = Back_Speed;
            car.Boost_Speed = Boost_Speed;
            car.Max_Boost_Charge = Max_Boost_Charge;
            car.Curent_Boost_Charge = Curent_Boost_Charge;
            car.Rotate_Right_Speed = Rotate_Right_Speed;
            car.Rotate_Left_Speed = Rotate_Left_Speed;
            car.Cover_Distance = Cover_Distance;
            return car;
        }

        public void Reset()
        {
            Current_Speed = 0;
            Cover_Distance = 0;
            Curent_Boost_Charge = 0;
        }
    }
}
