using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Car _template;

        public string SpriteFolder = AppDomain.CurrentDomain.BaseDirectory + @"Sprite\";
        public string SoundFolder = AppDomain.CurrentDomain.BaseDirectory + @"Sound\";
        public string VoiceFolder = AppDomain.CurrentDomain.BaseDirectory + @"Voice\";
        public string MusicFolder = AppDomain.CurrentDomain.BaseDirectory + @"Music\";

        public string PressedKey = "";
        private int _loadCount = 1;

        public static MainSpace SelfRef { get; set; }

        public MainSpace()
        {
            InitializeComponent();
            SelfRef = this;

            Init_Cars();
            Init_Sound();

            Game = new Game();
            MenuGame = new Menu();
            Garage = new Garage();
            Controls.AddRange(new Control[] { MenuGame, Game, Garage });
            MenuGame.Hide();
            Game.Hide();
            Garage.Hide();
        }

        public void Load_Menu()
        {
            if (_loadCount >= 17) // колличество инициализированных треков 
            {
                Show_Menu();
                PreLoad.Visible = false;
                Controls.Remove(PreLoad);
            }
            else
                _loadCount++;
        }

        private void MainSpace_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyCode.ToString();
        }

        private void MainSpace_KeyUp(object sender, KeyEventArgs e)
        {
            PressedKey = "";
        }

        private void MainSpace_Resize(object sender, EventArgs e)
        {
            Size = new Size(Width, Width * 3 / 4);
        }

        public void Show_Menu()
        {
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Game.Hide();
            Garage.Hide();
            MenuGame.Show();
            MenuGame.BringToFront();
            MusicManager.Change_Music("MainMenu");
        }

        public void Show_Game()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MenuGame.Hide();
            Garage.Hide();
            Game.Show();
            Game.BringToFront();
            Game.Init_Game();
            MusicManager.Change_Music("Game");
        }

        public void Show_Garage()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            Game.Hide();
            MenuGame.Hide();
            Garage.Show();
            Garage.BringToFront();
            MusicManager.Change_Music("Garage");
            VoiceManager.Change_Voice("Garage");
        }

        private void Create_Car(string Id, string Name,
                                float maxSpeed, float stepSpeed, float backSpeed,
                                float rotateLeftSpeed, float rotateRightSpeed,
                                float boostSpeed, float maxBoostCharge)
        {
            _template = new Car()
            {
                Id = Id,
                Name = Name,
                MaxSpeed = maxSpeed,
                StepSpeed = stepSpeed,
                BackSpeed = backSpeed,
                RotateLeftSpeed = rotateLeftSpeed,
                RotateRightSpeed = rotateRightSpeed,
                BoostSpeed = boostSpeed,
                MaxBoostCharge = maxBoostCharge
            };

            _template.AnimationDefault = new AnimationSprite(new Bitmap(SpriteFolder + _template.Id + ".png"))
            { Zindex = 5, Name = _template.Id, Group = _template.Id };

            _template.AnimationBack = new AnimationSprite(new Bitmap(SpriteFolder + _template.Id + "Back.png"))
            { Zindex = 5, Name = _template.Id + "Back", Group = _template.Id };

            _template.AnimationStop = new AnimationSprite(new Bitmap(SpriteFolder + _template.Id + "Stop.png"))
            { Zindex = 5, Name = _template.Id + "Stop", Group = _template.Id };

            _template.AnimationRotateLeft = new AnimationSprite(new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + _template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + _template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                               new Bitmap(SpriteFolder + _template.Id + "Left.png"),
                                                               new Bitmap(SpriteFolder + _template.Id + "Left.png")
                                                               )
            { Zindex = 5, Name = _template.Id + "Left", Group = _template.Id };

            _template.AnimationRotateRight = new AnimationSprite(new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + _template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + _template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + _template.Id + ".png"),
                                                                new Bitmap(SpriteFolder + _template.Id + "Right.png"),
                                                                new Bitmap(SpriteFolder + _template.Id + "Right.png")
                                                                )
            { Zindex = 5, Name = _template.Id + "Right", Group = _template.Id };

            _template.AnimationBreaking = new AnimationSprite()
            { Zindex = 5, Name = _template.Id + "Breaking", Group = _template.Id };

            for (int i = 1; i < 9; i++)
                _template.AnimationBreaking.Frame.Add(new Bitmap(SpriteFolder + _template.Id + "Frame" + i + ".gif"));

            TemplateCars.Add(_template);
        }

        public void Init_Cars()
        {
            Create_Car("Car01", "Ferrari", 50, 5, 15, 6, 6, 50, 50);
            Create_Car("Car02", "Cabrio", 45, 7, 14, 8, 8, 55, 55);
            Create_Car("Car03", "Nissan Green", 35, 9, 13, 10, 10, 65, 65);
            Create_Car("Car04", "Nissan Yellow", 60, 3, 16, 4, 4, 40, 40);
            Create_Car("Car05", "Ford", 70, 2, 17, 3, 3, 30, 30);
        }

        private void Init_Sound()
        {
            SoundManager.Sounds.Add(new Sound("Car01_Forward", new Uri(SoundFolder + "Car01Forward.wav"), true, 0.4));
            SoundManager.Sounds.Add(new Sound("Car02_Forward", new Uri(SoundFolder + "Car02Forward.wav"), true, 0.4));
            SoundManager.Sounds.Add(new Sound("Car03_Forward", new Uri(SoundFolder + "Car03Forward.wav"), true, 0.4));
            SoundManager.Sounds.Add(new Sound("Car04_Forward", new Uri(SoundFolder + "Car04Forward.wav"), true, 0.4));
            SoundManager.Sounds.Add(new Sound("Car05_Forward", new Uri(SoundFolder + "Car05Forward.wav"), true, 0.4));
            SoundManager.Sounds.Add(new Sound("BoostCar", new Uri(SoundFolder + "BoostCar.wav"), true, 0.5));
            SoundManager.Sounds.Add(new Sound("Back", new Uri(SoundFolder + "Back.wav"), true, 0.5));
            SoundManager.Sounds.Add(new Sound("TurnSignalCar", new Uri(SoundFolder + "TurnSignalCar.wav"), true, 0.3));

            SoundManager.Sounds.Add(new Sound("Car01_ForwardEnemy", new Uri(SoundFolder + "Car01Forward.wav"), true, 0.3));
            SoundManager.Sounds.Add(new Sound("Car02_ForwardEnemy", new Uri(SoundFolder + "Car02Forward.wav"), true, 0.3));
            SoundManager.Sounds.Add(new Sound("Car03_ForwardEnemy", new Uri(SoundFolder + "Car03Forward.wav"), true, 0.3));
            SoundManager.Sounds.Add(new Sound("Car04_ForwardEnemy", new Uri(SoundFolder + "Car04Forward.wav"), true, 0.3));
            SoundManager.Sounds.Add(new Sound("Car05_ForwardEnemy", new Uri(SoundFolder + "Car05Forward.wav"), true, 0.3));
            SoundManager.Sounds.Add(new Sound("BoostCarEnemy", new Uri(SoundFolder + "BoostCar.wav"), false, 0.4));
            SoundManager.Sounds.Add(new Sound("BackEnemy", new Uri(SoundFolder + "Back.wav"), false, 0.4));
            SoundManager.Sounds.Add(new Sound("TurnSignalCarEnemy", new Uri(SoundFolder + "TurnSignalCar.wav"), false, 0.2));

            SoundManager.Sounds.Add(new Sound("BrokenCar", new Uri(SoundFolder + "BrokenCar.wav"), false, 0.5));

            MusicManager.Musics.Add("MainMenu", new Uri(MusicFolder + "MainMenu.wav"));
            MusicManager.Musics.Add("Garage", new Uri(MusicFolder + "Garage.wav"));
            MusicManager.Musics.Add("Game", new Uri(MusicFolder + "Game.wav"));
            MusicManager.Musics.Add("Win", new Uri(MusicFolder + "Win.wav"));
            MusicManager.Musics.Add("GameOver", new Uri(MusicFolder + "GameOver.wav"));

            VoiceManager.Voices.Add("Winner", new Uri(VoiceFolder + "Winner.wav"));
            VoiceManager.Voices.Add("GameOver", new Uri(VoiceFolder + "GameOver.wav"));
            VoiceManager.Voices.Add("Go", new Uri(VoiceFolder + "Go.wav"));
            VoiceManager.Voices.Add("Garage", new Uri(VoiceFolder + "Garage.wav"));
        }
    }
}