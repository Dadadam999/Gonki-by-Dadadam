using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
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

        public List<Car> TemplateCars = new List<Car>();
        public Car CarPlayerExmp;
               
        public string SpriteFolder = AppDomain.CurrentDomain.BaseDirectory + @"Sprite\";
        public string SoundFolder = AppDomain.CurrentDomain.BaseDirectory + @"Sound\";
        public string VoiceFolder = AppDomain.CurrentDomain.BaseDirectory + @"Voice\";
        public string MusicFolder = AppDomain.CurrentDomain.BaseDirectory + @"Music\";
        public string Pressed_Key = "";

        public static MainSpace selfref { get; set; }

        public Debug db = new Debug();
        public MainSpace()
        {
            InitializeComponent();
            selfref = this;

            db.Show();

            init_cars();
            Debug.selfref.add_input("car_load");
            init_sound();
            Debug.selfref.add_input("sound_load");

            Game = new Game();
            MenuGame = new Menu();
            Garage = new Garage();

            Controls.AddRange(new Control[] { MenuGame, Game, Garage });
            show_menu();
        }

        private void MainSpace_Load(object sender, EventArgs e)
        {
            Debug.selfref.add_input("form_load");
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

        private void create_car(string Id, string Name, 
                                float Max_Speed, float Step_Speed, float Back_Speed, 
                                float Rotate_Left_Speed, float Rotate_Right_Speed, 
                                float Boost_Speed, float Max_Boost_Charge)
        {
            Car template = new Car()
            {
                Id = Id,
                Name = Name,
                Max_Speed = Max_Speed,
                Step_Speed = Step_Speed,
                Back_Speed = Back_Speed,
                Rotate_Left_Speed = Rotate_Left_Speed,
                Rotate_Right_Speed = Rotate_Right_Speed,
                Boost_Speed = Boost_Speed,
                Max_Boost_Charge = Max_Boost_Charge
            };
            template.AnimationDefault = new AnimationSprite(new Bitmap(SpriteFolder + template.Id + ".png"))
            {
                Zindex = 5,
                Name = template.Id,
                Group = template.Id
            };
            template.AnimationBack = new AnimationSprite(new Bitmap(SpriteFolder + template.Id + "Back.png"))
            {
                Zindex = 5,
                Name = template.Id + "Back",
                Group = template.Id
            };
            template.AnimationStop = new AnimationSprite(new Bitmap(SpriteFolder + template.Id + "Stop.png"))
            {
                Zindex = 5,
                Name = template.Id + "Stop",
                Group = template.Id
            };
            template.AnimationRotateLeft = new AnimationSprite(new Bitmap(SpriteFolder + template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + template.Id + "Left.png")
                                                               )
            {
                Zindex = 5,
                Name = template.Id + "Left",
                Group = template.Id
            };
            template.AnimationRotateRight = new AnimationSprite(new Bitmap(SpriteFolder + template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + template.Id + "Right.png")
                                                                )
            {
                Zindex = 5,
                Name = template.Id + "Right",
                Group = template.Id
            };
            template.AnimationBreaking = new AnimationSprite()
            {
                Zindex = 5,
                Name = template.Id + "Breaking",
                Group = template.Id
            };
            for (int i = 1; i < 9; i++)
                template.AnimationBreaking.Frame.Add(new Bitmap(SpriteFolder + template.Id + "Frame" + i + ".gif"));

            TemplateCars.Add(template);
        }

        public void init_cars() {
            create_car("Car01", "Ferrari", 50, 5, 15, 6, 6, 50, 50);
            create_car("Car02", "Cabrio", 45, 7, 14, 8, 8, 55, 55);
            create_car("Car03", "Nissan Green", 35, 9, 13, 10, 10, 65, 65);
            create_car("Car04", "Nissan Yellow", 60, 3, 16, 4, 4, 40, 40);
            create_car("Car05", "Ford", 70, 2, 17, 3, 3, 30, 30); 
        }

        private void init_sound() {
            MusicManager.Musics.Add("MainMenu", new Uri(MusicFolder + "MainMenu.wav"));
            MusicManager.Musics.Add("Garage", new Uri(MusicFolder + "Garage.wav"));
            MusicManager.Musics.Add("Game", new Uri(MusicFolder + "Game.wav"));
            MusicManager.Musics.Add("Win", new Uri(MusicFolder + "Win.wav"));
            MusicManager.Musics.Add("GameOver", new Uri(MusicFolder + "GameOver.wav"));

            VoiceManager.Voices.Add("Winner", new Uri(VoiceFolder + "Winner.wav"));
            VoiceManager.Voices.Add("GameOver", new Uri(VoiceFolder + "GameOver.wav"));
            VoiceManager.Voices.Add("Go", new Uri(VoiceFolder + "Go.wav"));
            VoiceManager.Voices.Add("Garage", new Uri(VoiceFolder + "Garage.wav"));

            SoundManager.sounds.Add(new Sound("Car01_Forward", new Uri(SoundFolder + "Car01Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car02_Forward", new Uri(SoundFolder + "Car02Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car03_Forward", new Uri(SoundFolder + "Car03Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car04_Forward", new Uri(SoundFolder + "Car04Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("Car05_Forward", new Uri(SoundFolder + "Car05Forward.wav"), true, 0.4));
            SoundManager.sounds.Add(new Sound("BoostCar", new Uri(SoundFolder + "BoostCar.wav"), true, 0.5));
            SoundManager.sounds.Add(new Sound("Back", new Uri(SoundFolder + "Back.wav"), true, 0.5));
            SoundManager.sounds.Add(new Sound("TurnSignalCar", new Uri(SoundFolder + "TurnSignalCar.wav"), true, 0.3));

            SoundManager.sounds.Add(new Sound("Car01_ForwardEnemy", new Uri(SoundFolder + "Car01Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car02_ForwardEnemy", new Uri(SoundFolder + "Car02Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car03_ForwardEnemy", new Uri(SoundFolder + "Car03Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car04_ForwardEnemy", new Uri(SoundFolder + "Car04Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("Car05_ForwardEnemy", new Uri(SoundFolder + "Car05Forward.wav"), true, 0.3));
            SoundManager.sounds.Add(new Sound("BoostCarEnemy", new Uri(SoundFolder + "BoostCar.wav"), false, 0.4));
            SoundManager.sounds.Add(new Sound("BackEnemy", new Uri(SoundFolder + "Back.wav"), false, 0.4));
            SoundManager.sounds.Add(new Sound("TurnSignalCarEnemy", new Uri(SoundFolder + "TurnSignalCar.wav"), false, 0.2));
            
            SoundManager.sounds.Add(new Sound("BrokenCar", new Uri(SoundFolder + "BrokenCar.wav"), false, 0.5));
        }
    }
}