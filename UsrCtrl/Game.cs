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
        private static Random _rand = new Random();
        private bool _play_game = false;
        private string _preview_state_enemy = ""; //

        private RoadController _road;
        private EnemyController _car_enemy;
        private PlayerController _car_player;
        private EnemyAI _enemy_ai;
        private Finish _finish;

        public Game()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Size = new Size(Width, Width * 3 / 4);
        }

        public void init_game() 
        {
            CollisionManager.Collisions.Clear();
            CollisionManager.Work = true;
            CollisionManager.Interact += new CollisionManager.InteractCollision(collision_handler);

            AnimationManager.Animations.Clear();

            _road = new RoadController(Width, Height);

            _car_player = new PlayerController(Width, Height);
            _car_player.init_car(MainSpace.selfref.Car_Player_Exmp.Clone());
            _car_player.State += new PlayerController.StateMachine(player_state_machine);

            _car_enemy = new EnemyController(Width, Height);
            _car_enemy.init_car(MainSpace.selfref.Cars[_rand.Next(0, MainSpace.selfref.Cars.Count - 1)].Clone());
            _car_enemy.State += new EnemyController.StateMachine(enemy_state_machine);

            _enemy_ai = new EnemyAI();
            _enemy_ai.Car_Enemy = _car_enemy;
            _enemy_ai.Car_Player = _car_player;

            _finish = new Finish(_rand.Next(10,30), Width, Height);

            Focus();
            start_resize();

            Game_Loop.Start();
        }

        void start_resize() 
        {
            Pause_Label.Left = Width / 2 - Pause_Label.Width / 2;
            Pause_Label.Top = Height / 5 * 4;

            EndGame_Label.Left = Width / 2 - EndGame_Label.Width / 2;
            EndGame_Label.Top = Height - EndGame_Label.Height * 2;

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
                VoiceManager.change_voice("Go");
            }

            if (pressed_key == "Escape")
            {
                Game_Loop.Stop();
                Instruction.Visible = false;
                Pause_Label.Visible = true;
                EndGame_Label.Visible = false;
                _play_game = false;
                SoundManager.stop_all_sound();
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
                
                Speed_Info.Text = $"Скорость: {_car_player.Car.Current_Speed} test: {_car_enemy.Car.Current_Speed}\nНитро: {_car_player.Car.Curent_Boost_Charge}\ndist {_finish.Distance * Width}\nplayer {_car_player.Car.Cover_Distance }\nenemy {_car_enemy.Car.Cover_Distance}\nf_pos {_finish.Sprite.Left } ";
                if (!String.IsNullOrEmpty(_finish.Result) && EndGame_Label.Visible == false)
                    EndGame_Label.Visible = true;

            }
            Repaint();
        }

        void Repaint()
        {
            BackgroundImage = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(BackgroundImage))
            {
                foreach (AnimationSprite anim in from animation in AnimationManager.Animations where animation.Visible orderby animation.Zindex select animation)
                    gr.DrawImage(anim.nextframe(), anim.Left, anim.Top, anim.Width, anim.Height);

                //test collision
                foreach (Collision collision in CollisionManager.Collisions)
                    gr.DrawRectangle(new Pen(Color.Red, 1), collision.Left, collision.Top, collision.Width, collision.Height);
            }
        }

        private void player_state_machine(string State)
        {
            if (State == "")
            {
                SoundManager.stop_sound("TurnSignalCar");
                SoundManager.stop_sound("BoostCar");
                SoundManager.stop_sound("Back");
            }

                if (State == "Forward")
                    SoundManager.play_sound(_car_player.Car.Id + "_Forward");

                if (State == "Stop")
                    SoundManager.stop_sound(_car_player.Car.Id + "_Forward");

                if (State == "Back")
                    SoundManager.play_sound("Back");

                if (State == "Left" || State == "Right")
                    SoundManager.play_sound("TurnSignalCar");

                if (State == "Boost")
                    SoundManager.play_sound("BoostCar");
        }

        private void enemy_state_machine(string State)
        {
            if (State != _preview_state_enemy && String.IsNullOrEmpty(_preview_state_enemy))
            {
                SoundManager.stop_sound("TurnSignalCarEnemy");
                SoundManager.stop_sound("BoostCarEnemy");
                SoundManager.stop_sound("BackEnemy");
                _preview_state_enemy = State;
            }

            if (State == "Forward")
                SoundManager.play_sound(_car_enemy.Car.Id + "_ForwardEnemy");

            if (State == "Stop" || _car_enemy.is_out_screen())
                SoundManager.stop_sound(_car_enemy.Car.Id + "_ForwardEnemy");
         
            if (!_car_enemy.is_out_screen())
            {
                if (State == "Back")
                    SoundManager.play_sound("BackEnemy");

                if (State == "Left" || State == "Right")
                    SoundManager.play_sound("TurnSignalCarEnemy");

                if (State == "Boost")
                    SoundManager.play_sound("BoostCarEnemy");
            }
        }

        private void collision_handler(string Name1, string Name2) {
            if (Name1 == "Player_Car" && Name2 == "Enemy_Car" )
            {
                CollisionManager.Work = false;
                Win_test.Text = "Crash car";
                _finish.Lose_Anim.Visible = true;
                _car_player.Freeze = true;
                _car_enemy.Freeze = true;
                EndGame_Label.Visible = true;
                MusicManager.change_music("GameOver");
                VoiceManager.change_voice("GameOver");
                SoundManager.play_sound("BrokenCar");
            }

            if (Name1 == "Player_Car" && (Name2 == "Left_Board" || Name2 == "Right_Board"))
            {
                CollisionManager.Work = false;
                Win_test.Text = "Crash Player on border";
                _finish.Lose_Anim.Visible = true;
                _car_player.Freeze = true;
                EndGame_Label.Visible = true;
                MusicManager.change_music("GameOver");
                VoiceManager.change_voice("GameOver");
                SoundManager.play_sound("BrokenCar");
            }

            if (Name1 == "Enemy_Car" && (Name2 == "Left_Board" || Name2 == "Right_Board"))
            {
                CollisionManager.Work = false;
                Win_test.Text = "Crash Enemy on border";
                _finish.Win_Anim.Visible = true;
                _car_enemy.Freeze = true;
                EndGame_Label.Visible = true;
                MusicManager.change_music("Win");
                VoiceManager.change_voice("Winner");
                SoundManager.play_sound("BrokenCar");
            }
        }
    }
}