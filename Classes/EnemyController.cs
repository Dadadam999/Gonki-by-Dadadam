using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class EnemyController
    {
        public delegate void StateMachine(string State);
        public static event StateMachine State;
        public Car Car { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        float _widthscreen { get; set; }
        float _heightscreen { get; set; }
        public bool Freeze { get; set; }
        Collision collision { get; set; }
        public AnimationSprite DefaultSprite { get; set; }
        public AnimationSprite GoBack { get; set; }
        public AnimationSprite RotateRight { get; set; }
        public AnimationSprite RotateLeft { get; set; }
        public AnimationSprite Breaking { get; set; }

        public EnemyController(int WidthScreen, int HeightScreen)
        {
            _widthscreen = WidthScreen;
            _heightscreen = HeightScreen;

            Freeze = false;
            Left = 0;
            Top = 0;
            Width = 0;
            Height = 0;

            collision = new Collision("Enemy_Car", Left, Top, Width - Width * 0.13F, Height);
            CollisionManager.Collisions.Add(collision);
        }

        public void set_start_position()
        {
            Left = _widthscreen / 3;
            Top = _heightscreen / 9 * 5;

            Width = _widthscreen / 7;
            Height = _heightscreen / 9;
        }

        public void plus_speed()
        {
            if (Car.Current_Speed >= Car.Max_Speed * -1)
                Car.Current_Speed -= Car.Step_Speed;
            State?.Invoke("Forward");
        }

        public void minus_speed()
        {
            if (Car.Current_Speed <= Car.Back_Speed)
                Car.Current_Speed += Car.Step_Speed;
            State?.Invoke("Back");
        }

        public void move_enemy(float Current_Player_Speed)
        {
            if(Car.Current_Speed < Car.Max_Speed)
                Left -= Current_Player_Speed + Car.Current_Speed;
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

        public void boost(bool Turn) {
            if (!Turn && Car.Curent_Boost_Charge <= Car.Max_Boost_Charge)
                Car.Curent_Boost_Charge++;

            if (Turn && Car.Curent_Boost_Charge > 0)
            {
                Car.Curent_Boost_Charge = Car.Curent_Boost_Charge - 5;
                if (Car.Current_Speed > Car.Max_Speed + Car.Boost_Speed)
                    Car.Current_Speed += Car.Boost_Speed;

                if (Car.Curent_Boost_Charge >= 0)
                    Car.Current_Speed = Car.Max_Speed;

                State?.Invoke("Boost");
            }
            if (!Turn && Car.Current_Speed >= Car.Max_Speed)
                Car.Current_Speed = Car.Max_Speed;
        }

        public void update()
        {
            Car.Cover_Distance += Car.Current_Speed * -1;

            if (Freeze)
                Car.Current_Speed = 0; //машина дергается

            collision.update(Left, Top, Width - Width * 0.13F, Height);
        }
    }
}
