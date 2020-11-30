using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class MainSpace : Form
    {
        public Game Game;
        public Menu MenuGame;
        public Garage Garage;

        public List<Car> Cars = new List<Car>();
        public Car Car_Player_Exmp;

        public string Pressed_Key = "";

        public static MainSpace selfref { get; set; }

        public MainSpace()
        {
            InitializeComponent();
            selfref = this;
            init_cars();
            init_sound();

            Game = new Game();
            MenuGame = new Menu();
            Garage = new Garage();

            Controls.AddRange(new Control[] { MenuGame, Game, Garage });  
            show_menu();
        }
        private void MainSpace_KeyDown(object sender, KeyEventArgs e)
        {
            Pressed_Key = e.KeyCode.ToString();
        }

        private void MainSpace_KeyUp(object sender, KeyEventArgs e)
        {
            Pressed_Key = "";
        }

        private void MainSpace_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(Width, Width * 3 / 4);
        }

        public void show_menu()
        {
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Game.Hide();
            Garage.Hide();
            MenuGame.Show();
            MenuGame.BringToFront();
            MusicManager.change_music("MainMenu");
        }

        public void show_game()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MenuGame.Hide();
            Garage.Hide();
            Game.Show();
            Game.BringToFront();
            Game.init_game();
            MusicManager.change_music("Game");
        }

        public void show_garage()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            Game.Hide();
            MenuGame.Hide();
            Garage.Show();
            Garage.BringToFront();
            MusicManager.change_music("Garage");
            VoiceManager.change_voice("Garage");
        }

        public void init_cars() {
            Cars.Add(new Car());
            Cars[Cars.Count - 1].Name = "Ferrari";
            Cars[Cars.Count - 1].Max_Speed = 50;
            Cars[Cars.Count - 1].Step_Speed = 5;
            Cars[Cars.Count - 1].Back_Speed = 15;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 6;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 6;
            Cars[Cars.Count - 1].Boost_Speed = 50;
            Cars[Cars.Count - 1].Max_Boost_Charge = 50;
            Cars[Cars.Count - 1].Sprite = Properties.Resources.car01;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Name = "Cabrio";
            Cars[Cars.Count - 1].Max_Speed = 45;
            Cars[Cars.Count - 1].Step_Speed = 7;
            Cars[Cars.Count - 1].Back_Speed = 14;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 8;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 8;
            Cars[Cars.Count - 1].Boost_Speed = 55;
            Cars[Cars.Count - 1].Max_Boost_Charge = 55;
            Cars[Cars.Count - 1].Sprite = Properties.Resources.car02;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Name = "Nissan Green";
            Cars[Cars.Count - 1].Max_Speed = 35;
            Cars[Cars.Count - 1].Step_Speed = 9;
            Cars[Cars.Count - 1].Back_Speed = 13;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 10;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 10;
            Cars[Cars.Count - 1].Boost_Speed = 65;
            Cars[Cars.Count - 1].Max_Boost_Charge = 65;
            Cars[Cars.Count - 1].Sprite = Properties.Resources.car03;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Name = "Nissan Yellow";
            Cars[Cars.Count - 1].Max_Speed = 60;
            Cars[Cars.Count - 1].Step_Speed = 3;
            Cars[Cars.Count - 1].Back_Speed = 16;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 4;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 4;
            Cars[Cars.Count - 1].Boost_Speed = 40;
            Cars[Cars.Count - 1].Max_Boost_Charge = 40;
            Cars[Cars.Count - 1].Sprite = Properties.Resources.car04;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Name = "Ford";
            Cars[Cars.Count - 1].Max_Speed = 70;
            Cars[Cars.Count - 1].Step_Speed = 2;
            Cars[Cars.Count - 1].Back_Speed = 17;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 3;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 3;
            Cars[Cars.Count - 1].Boost_Speed = 30;
            Cars[Cars.Count - 1].Max_Boost_Charge = 30;
            Cars[Cars.Count - 1].Sprite = Properties.Resources.car05;
        }

        private void init_sound() {
            MusicManager.Musics.Add("MainMenu", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\MainMenu.wav"));
            MusicManager.Musics.Add("Garage", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Garage.wav"));
            MusicManager.Musics.Add("Game", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Game.wav"));
            MusicManager.Musics.Add("Win", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Win.wav"));
            MusicManager.Musics.Add("GameOver", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\GameOver.wav"));

            VoiceManager.Voices.Add("Winner", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Winner.wav"));
            VoiceManager.Voices.Add("GameOver", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\GameOver.wav"));
            VoiceManager.Voices.Add("Go", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Go.wav"));
            VoiceManager.Voices.Add("Garage", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Garage.wav"));

            SoundManager.sounds.Add(new Sound("Car01_Foward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car01Foward.wav"), true));
            SoundManager.sounds.Add(new Sound("Car02_Foward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car02Foward.wav"), true));
            SoundManager.sounds.Add(new Sound("Car03_Foward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car03Foward.wav"), true));
            SoundManager.sounds.Add(new Sound("Car04_Foward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car04Foward.wav"), true));
            SoundManager.sounds.Add(new Sound("Car05_Foward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car05Foward.wav"), true));
            SoundManager.sounds.Add(new Sound("BoostCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BoostCar.wav"), true));
            SoundManager.sounds.Add(new Sound("BackAndRotate", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BackAndRotate.wav"), true));
            SoundManager.sounds.Add(new Sound("BrokenCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BrokenCar.wav"), false));
            SoundManager.sounds.Add(new Sound("TurnSignalCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\TurnSignalCar.wav"), true));
        }
    }
}
