using System;
using System.Drawing;

namespace Gonki_by_Dadadam
{
    class Finish
    {
        public int Distance { get; set; }
        public string Result { get; set; }
        private int _widthScreen { get; set; }
        public AnimationSprite Sprite { get; set; }
        public AnimationSprite WinAnim { get; set; }
        public AnimationSprite LoseAnim { get; set; }

        public Finish(int Distance, int WidthScreen, int HeightScreen)
        {
            _widthScreen = WidthScreen;
            this.Distance = Distance;

            Sprite = new AnimationSprite(new Bitmap(MainSpace.SelfRef.SpriteFolder + "FinishLine.png"))
            { Name = "Finish", Zindex = 1, Visible = true };
            Sprite.Transform(Distance * WidthScreen, 0, WidthScreen * 0.1F, HeightScreen);
            AnimationManager.Animations.Add(Sprite);

            WinAnim = new AnimationSprite()
            { Name = "WinAnim", Zindex = 100, Visible = false };
            for (int i = 1; i < 33; i++)
                WinAnim.Frame.Add(new Bitmap(MainSpace.SelfRef.SpriteFolder + "WinFrame" + i + ".gif"));
            WinAnim.Transform(0, 0, WidthScreen, HeightScreen);
            AnimationManager.Animations.Add(WinAnim);

            LoseAnim = new AnimationSprite()
            { Name = "LoseAnim", Zindex = 100, Visible = false };
            for (int i = 1; i < 9; i++)
                LoseAnim.Frame.Add(new Bitmap(MainSpace.SelfRef.SpriteFolder + "LoseFrame" + i + ".gif"));
            LoseAnim.Transform(0, 0, WidthScreen, HeightScreen);
            AnimationManager.Animations.Add(LoseAnim);
        }

        public void Check_Win(float Player_Distance, float Enemy_Distance)
        {
            if (string.IsNullOrEmpty(Result) && (Player_Distance > _widthScreen * Distance))
            {
                Result = "Player";
                WinAnim.Visible = true;
                MusicManager.Change_Music("Win");
                VoiceManager.Change_Voice("Winner");
            }

            if (string.IsNullOrEmpty(Result) && (Enemy_Distance > _widthScreen * Distance))
            {
                Result = "Enemy ";
                LoseAnim.Visible = true;
                MusicManager.Change_Music("GameOver");
                VoiceManager.Change_Voice("GameOver");
            }
        }

        public void Move(float speed)
        {
            Sprite.Left += speed * -1; //инвертироать скорость фона
        }
    }
}