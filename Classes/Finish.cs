using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    class Finish
    {
        public int Distance { get; set; }
        public string Result { get; set; }
        private int _widthscrren { get; set; }
        public AnimationSprite Sprite { get; set; }
        public AnimationSprite Win_Anim { get; set; }
        public AnimationSprite Lose_Anim { get; set; }
        public Finish(int Distance, int WidthScreen, int HeightScreen)
        {
            _widthscrren = WidthScreen;
            this.Distance = Distance;

            Sprite = new AnimationSprite(Properties.Resources.FinishLine);
            Sprite.Zindex = 1;
            Sprite.Width = WidthScreen * 0.1F;
            Sprite.Height = HeightScreen;
            Sprite.Top = 0;
            Sprite.Left = Distance * WidthScreen;
            Sprite.Visible = true;
            AnimationManager.Animations.Add(Sprite);

            Win_Anim = new AnimationSprite(Properties.Resources.WinFrame1,
                                           Properties.Resources.WinFrame2,
                                           Properties.Resources.WinFrame3,
                                           Properties.Resources.WinFrame4,
                                           Properties.Resources.WinFrame5,
                                           Properties.Resources.WinFrame6,
                                           Properties.Resources.WinFrame7,
                                           Properties.Resources.WinFrame8,
                                           Properties.Resources.WinFrame9,
                                           Properties.Resources.WinFrame10,
                                           Properties.Resources.WinFrame11,
                                           Properties.Resources.WinFrame12,
                                           Properties.Resources.WinFrame13,
                                           Properties.Resources.WinFrame14,
                                           Properties.Resources.WinFrame15,
                                           Properties.Resources.WinFrame16,
                                           Properties.Resources.WinFrame17,
                                           Properties.Resources.WinFrame18,
                                           Properties.Resources.WinFrame19,
                                           Properties.Resources.WinFrame20,
                                           Properties.Resources.WinFrame21,
                                           Properties.Resources.WinFrame22,
                                           Properties.Resources.WinFrame23,
                                           Properties.Resources.WinFrame24,
                                           Properties.Resources.WinFrame25,
                                           Properties.Resources.WinFrame26,
                                           Properties.Resources.WinFrame27,
                                           Properties.Resources.WinFrame28,
                                           Properties.Resources.WinFrame29,
                                           Properties.Resources.WinFrame30,
                                           Properties.Resources.WinFrame31,
                                           Properties.Resources.WinFrame32
                                           );
            Win_Anim.Left = 0;
            Win_Anim.Top = 0;
            Win_Anim.Width = WidthScreen;
            Win_Anim.Height = HeightScreen;
            Win_Anim.Visible = false;
            AnimationManager.Animations.Add(Win_Anim);

            Lose_Anim = new AnimationSprite(Properties.Resources.LoseFrame1,
                                            Properties.Resources.LoseFrame1,
                                            Properties.Resources.LoseFrame1,
                                            Properties.Resources.LoseFrame2,
                                            Properties.Resources.LoseFrame2,
                                            Properties.Resources.LoseFrame2,
                                            Properties.Resources.LoseFrame3,
                                            Properties.Resources.LoseFrame3,
                                            Properties.Resources.LoseFrame3,
                                            Properties.Resources.LoseFrame4,
                                            Properties.Resources.LoseFrame4,
                                            Properties.Resources.LoseFrame4
                                            );
            Lose_Anim.Left = 0;
            Lose_Anim.Top = 0;
            Lose_Anim.Width = WidthScreen;
            Lose_Anim.Height = HeightScreen;
            Lose_Anim.Visible = false;
            AnimationManager.Animations.Add(Lose_Anim);
        }

        public void check_win(float Player_Distance, float Enemy_Distance)
        {
            if (String.IsNullOrEmpty(Result) && Player_Distance > _widthscrren * Distance)
            {
                Result = "Player";
                Win_Anim.Visible = true;
                MusicManager.change_music("Win");
                VoiceManager.change_voice("Winner");
            }

            if (String.IsNullOrEmpty(Result) && Enemy_Distance > _widthscrren * Distance)
            {
                Result = "Enemy ";
                Lose_Anim.Visible = true;
                MusicManager.change_music("GameOver");
                VoiceManager.change_voice("GameOver");
            }
        }

        public void move(float speed)
        {
            Sprite.Left += speed * -1; //инвертироать скорость фона
        }
    }
}
