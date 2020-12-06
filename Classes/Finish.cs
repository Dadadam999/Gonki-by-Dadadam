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

            Sprite = new AnimationSprite(new Bitmap(MainSpace.selfref.SpriteFolder + "FinishLine.png"))
            {
                Name = "Finish",
                Zindex = 1,
                Visible = true
            };
            Sprite.transform(Distance * WidthScreen, 0, WidthScreen * 0.1F, HeightScreen);
            AnimationManager.Animations.Add(Sprite);

            Win_Anim = new AnimationSprite()
            {
                Name = "WinAnim",
                Zindex = 100,
                Visible = false
            };
            for (int i = 1; i < 33; i++)
                Win_Anim.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "WinFrame" + i + ".gif"));
            Win_Anim.transform(0, 0, WidthScreen, HeightScreen);
            AnimationManager.Animations.Add(Win_Anim);

            Lose_Anim = new AnimationSprite()
            {
                Name = "LoseAnim",
                Zindex = 100,
                Visible = false
            };
            for (int i = 1; i < 9; i++)
                Lose_Anim.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "LoseFrame" + i + ".gif"));
            Lose_Anim.transform(0, 0, WidthScreen, HeightScreen);
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