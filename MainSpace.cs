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


        public Debug db = new Debug();
        public MainSpace()
        {
            InitializeComponent();
            selfref = this;

            db.Show();

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
            Cars[Cars.Count - 1].Id = "Car01";
            Cars[Cars.Count - 1].Name = "Ferrari";
            Cars[Cars.Count - 1].Max_Speed = 50;
            Cars[Cars.Count - 1].Step_Speed = 5;
            Cars[Cars.Count - 1].Back_Speed = 15;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 6;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 6;
            Cars[Cars.Count - 1].Boost_Speed = 50;
            Cars[Cars.Count - 1].Max_Boost_Charge = 50;
            Cars[Cars.Count - 1].AnimationDefault = new AnimationSprite(Properties.Resources.Car01);
            Cars[Cars.Count - 1].AnimationDefault.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBack = new AnimationSprite(Properties.Resources.Car01Back);
            Cars[Cars.Count - 1].AnimationBack.Zindex = 5;
            Cars[Cars.Count - 1].AnimationStop = new AnimationSprite(Properties.Resources.Car01Stop);
            Cars[Cars.Count - 1].AnimationStop.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateLeft = new AnimationSprite(Properties.Resources.Car01,
                                                                           Properties.Resources.Car01,
                                                                           Properties.Resources.Car01Left,
                                                                           Properties.Resources.Car01Left,
                                                                           Properties.Resources.Car01,
                                                                           Properties.Resources.Car01,
                                                                           Properties.Resources.Car01Left,
                                                                           Properties.Resources.Car01Left
                                                                           );
            Cars[Cars.Count - 1].AnimationRotateLeft.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateRight = new AnimationSprite(Properties.Resources.Car01,
                                                                            Properties.Resources.Car01,
                                                                            Properties.Resources.Car01Right,
                                                                            Properties.Resources.Car01Right,
                                                                            Properties.Resources.Car01,
                                                                            Properties.Resources.Car01,
                                                                            Properties.Resources.Car01Right,
                                                                            Properties.Resources.Car01Right
                                                                            );
            Cars[Cars.Count - 1].AnimationRotateRight.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBreaking = new AnimationSprite(Properties.Resources.Car01,
                                                                            Properties.Resources.Car01Frame1,
                                                                            Properties.Resources.Car01Frame2,
                                                                            Properties.Resources.Car01Frame3,
                                                                            Properties.Resources.Car01Frame4,
                                                                            Properties.Resources.Car01Frame5,
                                                                            Properties.Resources.Car01Frame6,
                                                                            Properties.Resources.Car01Frame7,
                                                                            Properties.Resources.Car01Frame8,
                                                                            Properties.Resources.Car01Frame9
                                                                            );
            Cars[Cars.Count - 1].AnimationBreaking.Zindex = 5;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Id = "Car02";
            Cars[Cars.Count - 1].Name = "Cabrio";
            Cars[Cars.Count - 1].Max_Speed = 45;
            Cars[Cars.Count - 1].Step_Speed = 7;
            Cars[Cars.Count - 1].Back_Speed = 14;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 8;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 8;
            Cars[Cars.Count - 1].Boost_Speed = 55;
            Cars[Cars.Count - 1].Max_Boost_Charge = 55;
            Cars[Cars.Count - 1].AnimationDefault = new AnimationSprite(Properties.Resources.Car02);
            Cars[Cars.Count - 1].AnimationDefault.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBack = new AnimationSprite(Properties.Resources.Car02Back);
            Cars[Cars.Count - 1].AnimationBack.Zindex = 5;
            Cars[Cars.Count - 1].AnimationStop = new AnimationSprite(Properties.Resources.Car02Stop);
            Cars[Cars.Count - 1].AnimationStop.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateLeft = new AnimationSprite(Properties.Resources.Car02,
                                                                           Properties.Resources.Car02,
                                                                           Properties.Resources.Car02Left,
                                                                           Properties.Resources.Car02Left,
                                                                           Properties.Resources.Car02,
                                                                           Properties.Resources.Car02,
                                                                           Properties.Resources.Car02Left,
                                                                           Properties.Resources.Car02Left
                                                                           );
            Cars[Cars.Count - 1].AnimationRotateLeft.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateRight = new AnimationSprite(Properties.Resources.Car02,
                                                                            Properties.Resources.Car02,
                                                                            Properties.Resources.Car02Right,
                                                                            Properties.Resources.Car02Right,
                                                                            Properties.Resources.Car02,
                                                                            Properties.Resources.Car02,
                                                                            Properties.Resources.Car02Right,
                                                                            Properties.Resources.Car02Right
                                                                            );
            Cars[Cars.Count - 1].AnimationRotateRight.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBreaking = new AnimationSprite(Properties.Resources.Car02,
                                                                            Properties.Resources.Car02Frame1,
                                                                            Properties.Resources.Car02Frame2,
                                                                            Properties.Resources.Car02Frame3,
                                                                            Properties.Resources.Car02Frame4,
                                                                            Properties.Resources.Car02Frame5,
                                                                            Properties.Resources.Car02Frame6,
                                                                            Properties.Resources.Car02Frame7,
                                                                            Properties.Resources.Car02Frame8,
                                                                            Properties.Resources.Car02Frame9
                                                                            );
            Cars[Cars.Count - 1].AnimationBreaking.Zindex = 5;


            Cars.Add(new Car());
            Cars[Cars.Count - 1].Id = "Car03";
            Cars[Cars.Count - 1].Name = "Nissan Green";
            Cars[Cars.Count - 1].Max_Speed = 35;
            Cars[Cars.Count - 1].Step_Speed = 9;
            Cars[Cars.Count - 1].Back_Speed = 13;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 10;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 10;
            Cars[Cars.Count - 1].Boost_Speed = 65;
            Cars[Cars.Count - 1].Max_Boost_Charge = 65;
            Cars[Cars.Count - 1].AnimationDefault = new AnimationSprite(Properties.Resources.Car03);
            Cars[Cars.Count - 1].AnimationDefault.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBack = new AnimationSprite(Properties.Resources.Car03Back);
            Cars[Cars.Count - 1].AnimationBack.Zindex = 5;
            Cars[Cars.Count - 1].AnimationStop = new AnimationSprite(Properties.Resources.Car03Stop);
            Cars[Cars.Count - 1].AnimationStop.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateLeft = new AnimationSprite(Properties.Resources.Car03,
                                                                           Properties.Resources.Car03,
                                                                           Properties.Resources.Car03Left,
                                                                           Properties.Resources.Car03Left,
                                                                           Properties.Resources.Car03,
                                                                           Properties.Resources.Car03,
                                                                           Properties.Resources.Car03Left,
                                                                           Properties.Resources.Car03Left
                                                                           );
            Cars[Cars.Count - 1].AnimationRotateLeft.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateRight = new AnimationSprite(Properties.Resources.Car03,
                                                                            Properties.Resources.Car03,
                                                                            Properties.Resources.Car03Right,
                                                                            Properties.Resources.Car03Right,
                                                                            Properties.Resources.Car03,
                                                                            Properties.Resources.Car03,
                                                                            Properties.Resources.Car03Right,
                                                                            Properties.Resources.Car03Right
                                                                            );
            Cars[Cars.Count - 1].AnimationRotateRight.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBreaking = new AnimationSprite(Properties.Resources.Car03,
                                                                            Properties.Resources.Car03Frame1,
                                                                            Properties.Resources.Car03Frame2,
                                                                            Properties.Resources.Car03Frame3,
                                                                            Properties.Resources.Car03Frame4,
                                                                            Properties.Resources.Car03Frame5,
                                                                            Properties.Resources.Car03Frame6,
                                                                            Properties.Resources.Car03Frame7,
                                                                            Properties.Resources.Car03Frame8,
                                                                            Properties.Resources.Car03Frame9
                                                                            );
            Cars[Cars.Count - 1].AnimationBreaking.Zindex = 5;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Id = "Car04";
            Cars[Cars.Count - 1].Name = "Nissan Yellow";
            Cars[Cars.Count - 1].Max_Speed = 60;
            Cars[Cars.Count - 1].Step_Speed = 3;
            Cars[Cars.Count - 1].Back_Speed = 16;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 4;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 4;
            Cars[Cars.Count - 1].Boost_Speed = 40;
            Cars[Cars.Count - 1].Max_Boost_Charge = 40; 
            Cars[Cars.Count - 1].AnimationDefault = new AnimationSprite(Properties.Resources.Car04);
            Cars[Cars.Count - 1].AnimationDefault.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBack = new AnimationSprite(Properties.Resources.Car04Back);
            Cars[Cars.Count - 1].AnimationBack.Zindex = 5;
            Cars[Cars.Count - 1].AnimationStop = new AnimationSprite(Properties.Resources.Car04Stop);
            Cars[Cars.Count - 1].AnimationStop.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateLeft = new AnimationSprite(Properties.Resources.Car04,
                                                                           Properties.Resources.Car04,
                                                                           Properties.Resources.Car04Left,
                                                                           Properties.Resources.Car04Left,
                                                                           Properties.Resources.Car04,
                                                                           Properties.Resources.Car04,
                                                                           Properties.Resources.Car04Left,
                                                                           Properties.Resources.Car04Left
                                                                           );
            Cars[Cars.Count - 1].AnimationRotateLeft.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateRight = new AnimationSprite(Properties.Resources.Car04,
                                                                            Properties.Resources.Car04,
                                                                            Properties.Resources.Car04Right,
                                                                            Properties.Resources.Car04Right,
                                                                            Properties.Resources.Car04,
                                                                            Properties.Resources.Car04,
                                                                            Properties.Resources.Car04Right,
                                                                            Properties.Resources.Car04Right
                                                                            );
            Cars[Cars.Count - 1].AnimationRotateRight.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBreaking = new AnimationSprite(Properties.Resources.Car04,
                                                                            Properties.Resources.Car04Frame1,
                                                                            Properties.Resources.Car04Frame2,
                                                                            Properties.Resources.Car04Frame3,
                                                                            Properties.Resources.Car04Frame4,
                                                                            Properties.Resources.Car04Frame5,
                                                                            Properties.Resources.Car04Frame6,
                                                                            Properties.Resources.Car04Frame7,
                                                                            Properties.Resources.Car04Frame8,
                                                                            Properties.Resources.Car04Frame9
                                                                            );
            Cars[Cars.Count - 1].AnimationBreaking.Zindex = 5;

            Cars.Add(new Car());
            Cars[Cars.Count - 1].Id = "Car05";
            Cars[Cars.Count - 1].Name = "Ford";
            Cars[Cars.Count - 1].Max_Speed = 70;
            Cars[Cars.Count - 1].Step_Speed = 2;
            Cars[Cars.Count - 1].Back_Speed = 17;
            Cars[Cars.Count - 1].Rotate_Left_Speed = 3;
            Cars[Cars.Count - 1].Rotate_Right_Speed = 3;
            Cars[Cars.Count - 1].Boost_Speed = 30;
            Cars[Cars.Count - 1].Max_Boost_Charge = 30;

            Cars[Cars.Count - 1].AnimationDefault = new AnimationSprite(Properties.Resources.Car05);
            Cars[Cars.Count - 1].AnimationDefault.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBack = new AnimationSprite(Properties.Resources.Car05Back);
            Cars[Cars.Count - 1].AnimationBack.Zindex = 5;
            Cars[Cars.Count - 1].AnimationStop = new AnimationSprite(Properties.Resources.Car05Stop);
            Cars[Cars.Count - 1].AnimationStop.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateLeft = new AnimationSprite(Properties.Resources.Car05,
                                                                           Properties.Resources.Car05,
                                                                           Properties.Resources.Car05Left,
                                                                           Properties.Resources.Car05Left,
                                                                           Properties.Resources.Car05,
                                                                           Properties.Resources.Car05,
                                                                           Properties.Resources.Car05Left,
                                                                           Properties.Resources.Car05Left
                                                                           );
            Cars[Cars.Count - 1].AnimationRotateLeft.Zindex = 5;
            Cars[Cars.Count - 1].AnimationRotateRight = new AnimationSprite(Properties.Resources.Car05,
                                                                            Properties.Resources.Car05,
                                                                            Properties.Resources.Car05Right,
                                                                            Properties.Resources.Car05Right,
                                                                            Properties.Resources.Car05,
                                                                            Properties.Resources.Car05,
                                                                            Properties.Resources.Car05Right,
                                                                            Properties.Resources.Car05Right
                                                                            );
            Cars[Cars.Count - 1].AnimationRotateRight.Zindex = 5;
            Cars[Cars.Count - 1].AnimationBreaking = new AnimationSprite(Properties.Resources.Car05,
                                                                            Properties.Resources.Car05Frame1,
                                                                            Properties.Resources.Car05Frame2,
                                                                            Properties.Resources.Car05Frame3,
                                                                            Properties.Resources.Car05Frame4,
                                                                            Properties.Resources.Car05Frame5,
                                                                            Properties.Resources.Car05Frame6,
                                                                            Properties.Resources.Car05Frame7,
                                                                            Properties.Resources.Car05Frame8,
                                                                            Properties.Resources.Car05Frame9
                                                                            );
            Cars[Cars.Count - 1].AnimationBreaking.Zindex = 5;
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

            SoundManager.sounds.Add(new Sound("Car01_Forward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car01Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car02_Forward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car02Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car03_Forward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car03Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car04_Forward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car04Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car05_Forward", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car05Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("BoostCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BoostCar.wav"), true, 0.5));
            SoundManager.sounds.Add(new Sound("Back", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Back.wav"), true, 0.5));
            SoundManager.sounds.Add(new Sound("TurnSignalCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\TurnSignalCar.wav"), true, 0.3));

            SoundManager.sounds.Add(new Sound("Car01_ForwardEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car01Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car02_ForwardEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car02Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car03_ForwardEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car03Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car04_ForwardEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car04Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car05_ForwardEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Car05Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("BoostCarEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BoostCar.wav"), false, 0.4));
            SoundManager.sounds.Add(new Sound("BackEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\Back.wav"), false, 0.4));
            SoundManager.sounds.Add(new Sound("TurnSignalCarEnemy", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\TurnSignalCar.wav"), false, 0.2));
            
            SoundManager.sounds.Add(new Sound("BrokenCar", new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Sound\BrokenCar.wav"), false, 0.5));

        }
    }
}
