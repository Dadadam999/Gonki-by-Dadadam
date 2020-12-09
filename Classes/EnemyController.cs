using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class EnemyController : CarController
    {
        public delegate void StateMachine(string State);
        public event StateMachine State;
        private float _widthscreen { get; set; }
        private float _heightscreen { get; set; }
        
        public EnemyController(int WidthScreen, int HeightScreen)
        {
            _widthscreen = WidthScreen;
            _heightscreen = HeightScreen;

            collision = new Collision("Enemy_Car", Left, Top, Width, Height);
            CollisionManager.Collisions.Add(collision);
        }

        public override void init_car(Car car)
        {
            Car = car;
            Car.AnimationDefault.Visible = true;
            AnimationManager.Animations.Add(Car.AnimationDefault);
            AnimationManager.Animations.Add(Car.AnimationBack);
            AnimationManager.Animations.Add(Car.AnimationStop);
            AnimationManager.Animations.Add(Car.AnimationRotateLeft);
            AnimationManager.Animations.Add(Car.AnimationRotateRight);
            AnimationManager.Animations.Add(Car.AnimationBreaking);
        }

        public override void set_start_position()
        {
            Left = _widthscreen / 3;
            Top = _heightscreen / 9 * 5;

            Width = _widthscreen / 7;
            Height = _heightscreen / 9;

            AnimationManager.group_transform(Left, Top, Width, Height, Car.Id);
        }

        public void plus_speed()
        {
            if (Car.Current_Speed >= Car.Max_Speed * -1)
            {
                Car.Current_Speed -= Car.Step_Speed;
                State?.Invoke("PlusSpeed");
            }
        }

        public void minus_speed()
        {
            if (Car.Current_Speed <= Car.Back_Speed)
            {
                Car.Current_Speed += Car.Step_Speed;
                State?.Invoke("Back");
            }
        }

        public void rotate_left()
        {
            Top -= Car.Rotate_Left_Speed;
            State?.Invoke("Left");
        }

        public void rotate_right()
        {
            Top += Car.Rotate_Right_Speed;
            State?.Invoke("Right");
        }

        public void boost(bool Turn) 
        {
            if (!Turn && Car.Curent_Boost_Charge <= Car.Max_Boost_Charge) 
                Car.Curent_Boost_Charge++;

            if (Turn && Car.Current_Speed < 0)
            {
                Car.Curent_Boost_Charge--;

                if (Car.Current_Speed > (Car.Max_Speed + Car.Boost_Speed) * -1)
                    Car.Current_Speed -= Car.Boost_Speed;

                if (Car.Curent_Boost_Charge <= 0)
                {
                    Car.Current_Speed = Car.Max_Speed * -1;
                    State?.Invoke("UnBoost");
                }
                else
                    State?.Invoke("Boost");
            }

            if (!Turn && Car.Current_Speed < Car.Max_Speed * -1)
                Car.Current_Speed = Car.Max_Speed * -1;
        }

        public void move_enemy(float Current_Player_Speed)
        {
            if (Car.Current_Speed < Car.Max_Speed)
                Left -= Current_Player_Speed + Car.Current_Speed;
        }


        public void at_overtake()
        {
            State?.Invoke("AtOvertake");
        }

        public bool is_out_screen()
        {
            return Left + Width < 0 || Left > _widthscreen; 
        }

        public void update()
        {
            if (Car.Current_Speed == 0)
                State?.Invoke("Stop");
            else
                State?.Invoke("Forward");

            Car.Cover_Distance += Car.Current_Speed * -1;

            if (Freeze)
                Car.Current_Speed = 0; //машина дергается

            AnimationManager.group_transform(Left, Top, Width, Height, Car.Id);

            collision.update(Left + Width * 0.08F, Top + Height * 0.08F, Width - Width * 0.18F, Height - Height * 0.18F);
        }
    }
}
