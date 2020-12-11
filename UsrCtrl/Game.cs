using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public partial class Game : UserControl
    {
        private static readonly Random _rand = new Random();
        private bool _playGame = false;

        private RoadController _road;
        private EnemyController _carEnemy;
        private PlayerController _carPlayer;
        private EnemyAI _enemyAi;
        private Finish _finish;
        private PropController _propController;
        private PostProcessing _postProcessing;

        public Game()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Size = new Size(Width, Width * 3 / 4);
        }

        public void Init_Game()
        {
            CollisionManager.Collisions.Clear();
            CollisionManager.Work = true;
            CollisionManager.Interact += new CollisionManager.InteractCollision(Collision_Handler);

            AnimationManager.Animations.Clear();

            _road = new RoadController(Width, Height);

            _carPlayer = new PlayerController(Width, Height);
            _carPlayer.Init_Car(MainSpace.SelfRef.CarPlayerExmp.Clone());
            _carPlayer.State += new PlayerController.StateMachine(Player_State_Machine);

            _carEnemy = new EnemyController(Width, Height);
            _carEnemy.Init_Car(MainSpace.SelfRef.TemplateCars[_rand.Next(0, MainSpace.SelfRef.TemplateCars.Count - 1)].Clone());
            _carEnemy.State += new EnemyController.StateMachine(Enemy_State_Machine);

            _enemyAi = new EnemyAI { CarEnemy = _carEnemy, CarPlayer = _carPlayer };

            _finish = new Finish(_rand.Next(100, 300), Width, Height);

            _propController = new PropController(_carPlayer, _carEnemy);

            _postProcessing = new PostProcessing(Width, Height);

            Focus();
            Start_Resize();

            Game_Loop.Start();
        }

        void Start_Resize()
        {
            Pause_Label.Left = Width / 2 - Pause_Label.Width / 2;
            Pause_Label.Top = Height / 5 * 4;

            EndGame_Label.Left = Width / 2 - EndGame_Label.Width / 2;
            EndGame_Label.Top = Height - EndGame_Label.Height * 2;

            _carPlayer.Set_Start_Position();
            _carEnemy.Set_Start_Position();
        }

        private void Game_Loop_Tick(object sender, EventArgs e)
        {
            string pressed_key = MainSpace.SelfRef.PressedKey;
            if (!_playGame && (pressed_key == "R"))
            {
                Breaking_Text.Text = "";
                Speed_Info.Visible = true;
                Instruction.Visible = true;
                Pause_Label.Visible = false;
                _playGame = true;
                VoiceManager.Change_Voice("Go");
            }

            if (pressed_key == "Escape")
            {
                Game_Loop.Stop();
                Speed_Info.Visible = false;
                Instruction.Visible = false;
                Pause_Label.Visible = true;
                EndGame_Label.Visible = false;
                _playGame = false;
                SoundManager.Stop_All_Sound();
                MainSpace.SelfRef.Show_Menu();
            }

            if (_playGame)
            {
                _carPlayer.Key_Event(pressed_key);
                _carPlayer.Update();

                _enemyAi.Behavior();
                _carEnemy.Move_Enemy(_carPlayer.Car.CurrentSpeed);
                _carEnemy.Update();

                _propController.Update(Width);

                _road.Remove_Road_Parts();
                _road.Prolong_Road_Parts();
                _road.Move_Road_Parts(_carPlayer.Car.CurrentSpeed);

                _finish.Check_Win(_carPlayer.Car.CoverDistance, _carEnemy.Car.CoverDistance);
                _finish.Move(_carPlayer.Car.CurrentSpeed);


                CollisionManager.Check();

                AnimationManager.Update_Animations();

                Speed_Info.Text = $"Скорость: {_carPlayer.Car.CurrentSpeed} \nНитро: {_carPlayer.Car.CurentBoostCharge}";

                if (!string.IsNullOrEmpty(_finish.Result) && (EndGame_Label.Visible == false))
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
                    gr.DrawImage(anim.Next_Frame(), anim.Left, anim.Top, anim.Width, anim.Height);
            }
        }

        private void Player_State_Machine(string State)
        {
            if (State == "")
            {
                SoundManager.Stop_Sound("TurnSignalCar");
                SoundManager.Stop_Sound("BoostCar");
                SoundManager.Stop_Sound("Back");
                AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(true, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(false, "PropBoostPlayer");
            }

            if (State == "Move")
            {
                SoundManager.Play_Sound(_carPlayer.Car.Id + "_Forward");
            }

            if (State == "Stop")
            {
                SoundManager.Stop_Sound(_carPlayer.Car.Id + "_Forward");
            }

            if (State == "Back")
            {
                SoundManager.Play_Sound("Back");

                if (_carPlayer.Car.CurrentSpeed > 0)
                {
                    AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                    AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Stop");
                    _propController.PropStopPlayer.Paint();
                }
                else
                {
                    AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                    AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Back");
                }
            }

            if (State == "Left")
            {
                SoundManager.Play_Sound("TurnSignalCar");
                AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Left");
                _propController.PropStopPlayer.Paint();
            }

            if (State == "Right")
            {
                SoundManager.Play_Sound("TurnSignalCar");
                AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Right");
                _propController.PropStopPlayer.Paint();
            }

            if (State == "Boost")
            {
                if (_carPlayer.Car.CurentBoostCharge <= 0)
                {
                    SoundManager.Stop_Sound("BoostCar");
                    AnimationManager.Set_Visible(false, "PropBoostPlayer");
                }
                else
                {
                    SoundManager.Play_Sound("BoostCar");
                    AnimationManager.Set_Visible(true, "PropBoostPlayer");
                }
            }
        }

        private void Enemy_State_Machine(string State)
        {
            if (!_carEnemy.Is_Out_Screen())
            {
                SoundManager.Reset_Volume_Sound(_carEnemy.Car.Id + "_ForwardEnemy");
                SoundManager.Reset_Volume_Sound("BackEnemy");
                SoundManager.Reset_Volume_Sound("TurnSignalCarEnemy");
                SoundManager.Reset_Volume_Sound("BoostCarEnemy");
            }
            else
            {
                SoundManager.Change_Volume_Sound(_carEnemy.Car.Id + "_ForwardEnemy", 0);
                SoundManager.Change_Volume_Sound("BackEnemy", 0);
                SoundManager.Change_Volume_Sound("TurnSignalCarEnemy", 0);
                SoundManager.Change_Volume_Sound("BoostCarEnemy", 0);
            }

            if (State == "PlusSpeed")
            {
                AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                AnimationManager.Set_Visible(true, _carEnemy.Car.Id);
            }

            if (State == "Forward")
                SoundManager.Play_Sound(_carEnemy.Car.Id + "_ForwardEnemy");

            if (State == "Stop" || _carEnemy.Is_Out_Screen())
                SoundManager.Stop_Sound(_carEnemy.Car.Id + "_ForwardEnemy");


            if (State == "Back")
            {
                SoundManager.Play_Sound("BackEnemy");

                if (_carEnemy.Car.CurrentSpeed > 0)
                {
                    AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                    AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Stop");
                    _propController.PropStopEnemy.Paint();
                }
                else
                {
                    AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                    AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Back");
                }
            }

            if (State == "Left")
            {
                SoundManager.Play_Sound("TurnSignalCarEnemy");
                AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Left");
                _propController.PropStopEnemy.Paint();
            }

            if (State == "Right")
            {
                SoundManager.Play_Sound("TurnSignalCarEnemy");
                AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Right");
                _propController.PropStopEnemy.Paint();
            }

            if (State == "Boost")
            {
                AnimationManager.Set_Visible(true, "PropBoostEnemy");
                SoundManager.Play_Sound("BoostCarEnemy");
            }

            if (State == "UnBoost")
            {
                AnimationManager.Set_Visible(false, "PropBoostEnemy");
                SoundManager.Stop_Sound("BoostCarEnemy");
            }

            if (State == "AtOvertake")
            {
                SoundManager.Stop_Sound("BoostCarEnemy");
                AnimationManager.Set_Visible(false, "PropBoostEnemy");
            }
        }

        private void Collision_Handler(string Name1, string Name2)
        {
            if ((Name1 == "Player_Car") && (Name2 == "Enemy_Car"))
            {
                _playGame = false;
                SoundManager.Stop_All_Sound();
                CollisionManager.Work = false;
                Breaking_Text.Text = "Crash car";
                _finish.LoseAnim.Visible = true;
                _carPlayer.Freeze = true;
                _carEnemy.Freeze = true;
                EndGame_Label.Visible = true;

                MusicManager.Change_Music("GameOver");
                VoiceManager.Change_Voice("GameOver");
                SoundManager.Play_Sound("BrokenCar");

                AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Breaking");
                AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Breaking");
                AnimationManager.Set_Visible(false, "PropBoostPlayer");
                AnimationManager.Set_Visible(false, "PropBoostEnemy");
            }

            if ((Name1 == "Player_Car") && ((Name2 == "Left_Board") || (Name2 == "Right_Board")))
            {
                _playGame = false;
                SoundManager.Stop_All_Sound();
                CollisionManager.Work = false;
                Breaking_Text.Text = "Crash Player on border";
                _finish.LoseAnim.Visible = true;
                _carPlayer.Freeze = true;
                EndGame_Label.Visible = true;

                MusicManager.Change_Music("GameOver");
                VoiceManager.Change_Voice("GameOver");
                SoundManager.Play_Sound("BrokenCar");

                AnimationManager.Group_Visible(false, _carPlayer.Car.Id);
                AnimationManager.Set_Visible(true, _carPlayer.Car.Id + "Breaking");
            }

            if ((Name1 == "Enemy_Car") && ((Name2 == "Left_Board") || (Name2 == "Right_Board")))
            {
                _playGame = false;
                SoundManager.Stop_All_Sound();
                CollisionManager.Work = false;
                Breaking_Text.Text = "Crash Enemy on border";
                _finish.WinAnim.Visible = true;
                _carEnemy.Freeze = true;
                EndGame_Label.Visible = true;

                MusicManager.Change_Music("Win");
                VoiceManager.Change_Voice("Winner");
                SoundManager.Play_Sound("BrokenCar");

                AnimationManager.Group_Visible(false, _carEnemy.Car.Id);
                AnimationManager.Set_Visible(true, _carEnemy.Car.Id + "Breaking");
            }
        }
    }
}