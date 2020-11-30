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
        public Bitmap Sprite { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Top { get; set; }
        public float Left { get; set; }
        public int Distance { get; set; }
        public string Result { get; set; }
        private int _widthscrren { get; set; }
        public AnimationSprite Win_Anim { get; set; }
        public AnimationSprite Lose_Anim { get; set; }
        public Finish(int Distance, int WidthScreen, int HeightScreen)
        {
            _widthscrren = WidthScreen;
            this.Distance = Distance;
            Sprite = Properties.Resources.finish_line;
            Width = WidthScreen * 0.1F;
            Height = HeightScreen;
            Top = 0;
            Left = Distance * WidthScreen;

            Win_Anim = new AnimationSprite(Properties.Resources.winframe01,
                                           Properties.Resources.winframe02,
                                           Properties.Resources.winframe03,
                                           Properties.Resources.winframe04,
                                           Properties.Resources.winframe05,
                                           Properties.Resources.winframe06,
                                           Properties.Resources.winframe07,
                                           Properties.Resources.winframe08,
                                           Properties.Resources.winframe09,
                                           Properties.Resources.winframe10,
                                           Properties.Resources.winframe11,
                                           Properties.Resources.winframe12,
                                           Properties.Resources.winframe13,
                                           Properties.Resources.winframe14,
                                           Properties.Resources.winframe15,
                                           Properties.Resources.winframe16,
                                           Properties.Resources.winframe17,
                                           Properties.Resources.winframe18,
                                           Properties.Resources.winframe19,
                                           Properties.Resources.winframe20,
                                           Properties.Resources.winframe21,
                                           Properties.Resources.winframe22,
                                           Properties.Resources.winframe23,
                                           Properties.Resources.winframe24,
                                           Properties.Resources.winframe25,
                                           Properties.Resources.winframe26,
                                           Properties.Resources.winframe27,
                                           Properties.Resources.winframe28,
                                           Properties.Resources.winframe29,
                                           Properties.Resources.winframe30,
                                           Properties.Resources.winframe31,
                                           Properties.Resources.winframe32
                                           );
            Win_Anim.Left = 0;
            Win_Anim.Top = 0;
            Win_Anim.Width = WidthScreen;
            Win_Anim.Height = HeightScreen;
            Win_Anim.Visible = false;
            AnimationManager.Animations.Add(Win_Anim);

            Lose_Anim = new AnimationSprite(Properties.Resources.loseframe1,
                                            Properties.Resources.loseframe1,
                                            Properties.Resources.loseframe1,
                                            Properties.Resources.loseframe2,
                                            Properties.Resources.loseframe2,
                                            Properties.Resources.loseframe2,
                                            Properties.Resources.loseframe3,
                                            Properties.Resources.loseframe3,
                                            Properties.Resources.loseframe3,
                                            Properties.Resources.loseframe4,
                                            Properties.Resources.loseframe4,
                                            Properties.Resources.loseframe4
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
            Left += speed * -1; //инвертироать скорость фона
        }
    }
}
