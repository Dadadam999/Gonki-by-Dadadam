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

        public Game()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public void init_game() 
        {
            _car_player = new PlayerController(Width, Height);
            _car_player.Car = MainSpace.selfref.Car_Player_Exmp.Clone();

            _car_enemy = new EnemyController(Width, Height);
            _car_enemy.Car = MainSpace.selfref.Lst_Car[_rand.Next(0, MainSpace.selfref.Lst_Car.Count - 1)].Clone();

            _enemy_ai = new EnemyAI();
            _enemy_ai.Car_Enemy = _car_enemy;
            _enemy_ai.Car_Player = _car_player;

            _road = new RoadController(Width, Height);

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

                

                _car_enemy.plus_speed();
                _car_enemy.move_enemy();
                _car_enemy.update();

                _road.remove_road_parts();
                _road.prolong_road_parts();
                _road.move_road_parts(_car_player.Car.Current_Speed);
                    
                Speed_Info.Text = $"Скорость: {_car_player.Car.Current_Speed} test: {_car_enemy.Car.Current_Speed}\nНитро: {_car_player.Car.Curent_Boost_Charge}";
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

                gr.DrawImage(_car_enemy.Car.Sprite, _car_enemy.Left, _car_enemy.Top, _car_enemy.Width, _car_enemy.Height);
                gr.DrawImage(_car_player.Car.Sprite, _car_player.Left, _car_player.Top, _car_player.Width, _car_player.Height);
            }
        }
    }
}
