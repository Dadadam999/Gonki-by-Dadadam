using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class PlayerController : CarController
    {
        public delegate void StateMachine(string State);
        public event StateMachine State;
        
        private float _widthscreen { get; set; }
        private float _heightscreen { get; set; }

        public PlayerController(int WidthScreen, int HeightScreen)
        {
            _widthscreen = WidthScreen;
            _heightscreen = HeightScreen;

            collision = new Collision("Player_Car", Left, Top, Width, Height);
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
            Top = _heightscreen / 3;

            Width = _widthscreen / 7;
            Height = _heightscreen / 9;

            AnimationManager.group_transform(Left, Top, Width, Height, Car.Id);
        }

        public void key_event(string pressed_key)
        {
            if (String.IsNullOrEmpty(pressed_key))
                State?.Invoke("");

            if (Car.Current_Speed == 0)
                State?.Invoke("Stop");
            else
                State?.Invoke("Move");

            if (pressed_key == "W" && Car.Current_Speed <= Car.Max_Speed)
            {
                Car.Current_Speed += Car.Step_Speed;
            }

            if (pressed_key == "S" && Car.Current_Speed >= Car.Back_Speed * -1)
            {
                Car.Current_Speed -= Car.Step_Speed;
                State?.Invoke("Back");
            }

            if (pressed_key == "A" && Car.Current_Speed != 0)
            {
                Top -= Car.Rotate_Left_Speed;
                State?.Invoke("Left");
            }

            if (pressed_key == "D" && Car.Current_Speed != 0)
            {
                Top += Car.Rotate_Right_Speed;
                State?.Invoke("Right");
            }

            if (pressed_key != "ShiftKey" && Car.Curent_Boost_Charge <= Car.Max_Boost_Charge)
                Car.Curent_Boost_Charge++;

            if (pressed_key == "ShiftKey" && Car.Curent_Boost_Charge > 0 && Car.Current_Speed > 0)
            {
                Car.Curent_Boost_Charge--;
                if (Car.Current_Speed < Car.Max_Speed + Car.Boost_Speed)
                    Car.Current_Speed += Car.Boost_Speed;

                if (Car.Curent_Boost_Charge <= 0)
                    Car.Current_Speed = Car.Max_Speed;

                State?.Invoke("Boost");
            }
            if (pressed_key != "ShiftKey" && Car.Current_Speed >= Car.Max_Speed)
                Car.Current_Speed = Car.Max_Speed;
        }

        public void update()
        {
            Car.Cover_Distance += Car.Current_Speed;

            if (Car.Current_Speed != 0 &&
                Car.Current_Speed > Car.Back_Speed * -1 &&
                Car.Current_Speed < Car.Max_Speed)
                    Left = _widthscreen / 3 + Car.Current_Speed; // Width / 3 - стартовая позиция

            if (Freeze)
                Car.Current_Speed = 0;

            AnimationManager.group_transform(Left, Top, Width, Height, Car.Id);

            collision.update(Left + Width * 0.08F, Top + Height * 0.08F, Width - Width * 0.18F, Height - Height * 0.18F);
        }
    }
}