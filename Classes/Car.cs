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
        public string Id { get; set; }
        public string Name { get; set; }
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
        public AnimationSprite AnimationDefault { get; set; }
        public AnimationSprite AnimationBack { get; set; }
        public AnimationSprite AnimationStop { get; set; }
        public AnimationSprite AnimationRotateRight { get; set; }
        public AnimationSprite AnimationRotateLeft { get; set; }
        public AnimationSprite AnimationBreaking { get; set; }

        public Car()
        {
            Current_Speed = 0;
            Cover_Distance = 0;
            Curent_Boost_Charge = 0;
        }

        public Car Clone()
        {
            Car car = new Car
            {
                Id = Id,
                Name = Name,
                Max_Speed = Max_Speed,
                Current_Speed = Current_Speed,
                Step_Speed = Step_Speed,
                Back_Speed = Back_Speed,
                Boost_Speed = Boost_Speed,
                Max_Boost_Charge = Max_Boost_Charge,
                Curent_Boost_Charge = Curent_Boost_Charge,
                Rotate_Right_Speed = Rotate_Right_Speed,
                Rotate_Left_Speed = Rotate_Left_Speed,
                Cover_Distance = Cover_Distance,
                AnimationDefault = AnimationDefault.Clone(),
                AnimationBack = AnimationBack.Clone(),
                AnimationRotateRight = AnimationRotateRight.Clone(),
                AnimationRotateLeft = AnimationRotateLeft.Clone(),
                AnimationBreaking = AnimationBreaking.Clone(),
                AnimationStop = AnimationStop.Clone()
            };
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
