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
    public partial class Game : UserControl
    {
        static Random _rand = new Random();
        bool _play_game = false;

        RoadController _road;
        EnemyController _car_enemy;
        PlayerController _car_player;
        EnemyAI _enemy_ai;
        Finish _finish;

        public Game()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.Size = new Size(Width, Width * 3 / 4);
        }

        public void init_game() 
        {
            CollisionManager.Collisions.Clear();
            CollisionManager.Interact += new CollisionManager.InteractCollision(collision_handler);

            AnimationManager.Init();

            _car_player = new PlayerController(Width, Height);
            _car_player.Car = MainSpace.selfref.Car_Player_Exmp.Clone();

            _car_enemy = new EnemyController(Width, Height);
            _car_enemy.Car = MainSpace.selfref.Lst_Car[_rand.Next(0, MainSpace.selfref.Lst_Car.Count - 1)].Clone();
            
            _enemy_ai = new EnemyAI();
            _enemy_ai.Car_Enemy = _car_enemy;
            _enemy_ai.Car_Player = _car_player;

            _road = new RoadController(Width, Height);

            _finish = new Finish(10, Width, Height);
            

            Focus();
            start_resize();

            Game_Loop.Start();
        }

        void start_resize() 
        {
            Pause_Label.Left = Width / 2 - Pause_Label.Width / 2;
            Pause_Label.Top = Height / 5 * 4;

            _car_player.set_start_position();
            _car_enemy.set_start_position();
        }


        private void Game_Loop_Tick(object sender, EventArgs e)
        {
            string pressed_key = MainSpace.selfref.Pressed_Key;
            if (pressed_key == "R") 
            {
                Instruction.Visible = true;
                Pause_Label.Visible = false;
                _play_game = true;
            }

            if (pressed_key == "Escape")
            {
                Game_Loop.Stop();
                Instruction.Visible = false;
                Pause_Label.Visible = true;
                _play_game = false;
                MainSpace.selfref.show_menu();
            }

            if (_play_game)
            {
                _car_player.key_event(pressed_key);
                _car_player.update();

                _enemy_ai.behavior();
                _car_enemy.move_enemy(_car_player.Car.Current_Speed);
                _car_enemy.update();

                _road.remove_road_parts();
                _road.prolong_road_parts();
                _road.move_road_parts(_car_player.Car.Current_Speed);

                CollisionManager.check();

                _finish.move(_car_player.Car.Current_Speed);
                _finish.check_win(_car_player.Car.Cover_Distance, _car_enemy.Car.Cover_Distance);
                
                Speed_Info.Text = $"Скорость: {_car_player.Car.Current_Speed} test: {_car_enemy.Car.Current_Speed}\nНитро: {_car_player.Car.Curent_Boost_Charge}\ndist {_finish.Distance * Width}\nplayer {_car_player.Car.Cover_Distance }\nenemy {_car_enemy.Car.Cover_Distance}\nf_pos {_finish.Left } ";

            }
            Repaint();
        }

        void Repaint()
        {
            BackgroundImage = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(BackgroundImage))
            {
                foreach (Road road in _road.Road_Parts)  
                    gr.DrawImage(road.Sprite, road.Left, road.Top, road.Width, road.Height);
                
                gr.DrawImage(_finish.Sprite, _finish.Left, _finish.Top, _finish.Width, _finish.Height);
                
                gr.DrawImage(_car_enemy.Car.Sprite, _car_enemy.Left, _car_enemy.Top, _car_enemy.Width, _car_enemy.Height);
                gr.DrawImage(_car_player.Car.Sprite, _car_player.Left, _car_player.Top, _car_player.Width, _car_player.Height);
               
                //test
                foreach (Collision collision in CollisionManager.Collisions)
                    gr.DrawRectangle(new Pen(Color.Red, 1), collision.Left, collision.Top, collision.Width, collision.Height);

                foreach (AnimationSprite anim in AnimationManager.Animations)
                    if(anim.Visible)
                        gr.DrawImage(anim.nextframe(), anim.Left, anim.Top, anim.Width, anim.Height);

            }
        }

        void collision_handler(string Name1, string Name2) {
            if (Name1 == "Player_Car" && Name2 == "Enemy_Car" )
            {
                Win_test.Text = "Crash car";
                _finish.Lose_Anim.Visible = true;
                _car_player.Freeze = true;
                _car_enemy.Freeze = true;
            }

            if (Name1 == "Player_Car" && Name2 == "Left_Board" || Name2 == "Right_Board")
            {
                Win_test.Text = "Crash Player on border";
                _finish.Lose_Anim.Visible = true;
                _car_player.Freeze = true;
            }

            if (Name1 == "Enemy_Car" && Name2 == "Left_Board" || Name2 == "Right_Board")
            {
                Win_test.Text = "Crash Enemy on border";
                _finish.Win_Anim.Visible = true;
                _car_enemy.Freeze = true;
            }
        }
    }
}
