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

        public List<Car> Lst_Car = new List<Car>();
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
            Lst_Car.Add(new Car());
            Lst_Car[Lst_Car.Count - 1].Name = "Ferrari";
            Lst_Car[Lst_Car.Count - 1].Max_Speed = 50;
            Lst_Car[Lst_Car.Count - 1].Step_Speed = 5;
            Lst_Car[Lst_Car.Count - 1].Back_Speed = 15;
            Lst_Car[Lst_Car.Count - 1].Rotate_Left_Speed = 6;
            Lst_Car[Lst_Car.Count - 1].Rotate_Right_Speed = 6;
            Lst_Car[Lst_Car.Count - 1].Boost_Speed = 50;
            Lst_Car[Lst_Car.Count - 1].Max_Boost_Charge = 50;
            Lst_Car[Lst_Car.Count - 1].Sprite = Properties.Resources.car01;

            Lst_Car.Add(new Car());
            Lst_Car[Lst_Car.Count - 1].Name = "Cabrio";
            Lst_Car[Lst_Car.Count - 1].Max_Speed = 45;
            Lst_Car[Lst_Car.Count - 1].Step_Speed = 7;
            Lst_Car[Lst_Car.Count - 1].Back_Speed = 14;
            Lst_Car[Lst_Car.Count - 1].Rotate_Left_Speed = 8;
            Lst_Car[Lst_Car.Count - 1].Rotate_Right_Speed = 8;
            Lst_Car[Lst_Car.Count - 1].Boost_Speed = 55;
            Lst_Car[Lst_Car.Count - 1].Max_Boost_Charge = 55;
            Lst_Car[Lst_Car.Count - 1].Sprite = Properties.Resources.car02;

            Lst_Car.Add(new Car());
            Lst_Car[Lst_Car.Count - 1].Name = "Nissan Green";
            Lst_Car[Lst_Car.Count - 1].Max_Speed = 35;
            Lst_Car[Lst_Car.Count - 1].Step_Speed = 9;
            Lst_Car[Lst_Car.Count - 1].Back_Speed = 13;
            Lst_Car[Lst_Car.Count - 1].Rotate_Left_Speed = 10;
            Lst_Car[Lst_Car.Count - 1].Rotate_Right_Speed = 10;
            Lst_Car[Lst_Car.Count - 1].Boost_Speed = 65;
            Lst_Car[Lst_Car.Count - 1].Max_Boost_Charge = 65;
            Lst_Car[Lst_Car.Count - 1].Sprite = Properties.Resources.car03;

            Lst_Car.Add(new Car());
            Lst_Car[Lst_Car.Count - 1].Name = "Nissan Yellow";
            Lst_Car[Lst_Car.Count - 1].Max_Speed = 60;
            Lst_Car[Lst_Car.Count - 1].Step_Speed = 3;
            Lst_Car[Lst_Car.Count - 1].Back_Speed = 16;
            Lst_Car[Lst_Car.Count - 1].Rotate_Left_Speed = 4;
            Lst_Car[Lst_Car.Count - 1].Rotate_Right_Speed = 4;
            Lst_Car[Lst_Car.Count - 1].Boost_Speed = 40;
            Lst_Car[Lst_Car.Count - 1].Max_Boost_Charge = 40;
            Lst_Car[Lst_Car.Count - 1].Sprite = Properties.Resources.car04;

            Lst_Car.Add(new Car());
            Lst_Car[Lst_Car.Count - 1].Name = "Ford";
            Lst_Car[Lst_Car.Count - 1].Max_Speed = 70;
            Lst_Car[Lst_Car.Count - 1].Step_Speed = 2;
            Lst_Car[Lst_Car.Count - 1].Back_Speed = 17;
            Lst_Car[Lst_Car.Count - 1].Rotate_Left_Speed = 3;
            Lst_Car[Lst_Car.Count - 1].Rotate_Right_Speed = 3;
            Lst_Car[Lst_Car.Count - 1].Boost_Speed = 30;
            Lst_Car[Lst_Car.Count - 1].Max_Boost_Charge = 30;
            Lst_Car[Lst_Car.Count - 1].Sprite = Properties.Resources.car05;
        }

        private void init_sound() {
            MusicManager.Musics.Add("MainMenu", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\MainMenu.wav"));
            MusicManager.Musics.Add("Garage", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Garage.wav"));
            MusicManager.Musics.Add("Game", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Game.wav"));
            MusicManager.Musics.Add("Finish", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Music\Finish.wav"));

            VoiceManager.Voices.Add("Winner", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Winner.wav"));
            VoiceManager.Voices.Add("GameOver", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\GameOver.wav"));
            VoiceManager.Voices.Add("Go", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Go.wav"));
            VoiceManager.Voices.Add("Garage", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Voice\Garage.wav"));
        }
        

        private void MainSpace_Resize(object sender, EventArgs e)
        {
                this.Size = new Size(Width, Width * 3 / 4);
        }
    }
}
