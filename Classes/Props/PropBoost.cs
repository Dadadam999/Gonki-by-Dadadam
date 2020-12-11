using System.Drawing;

namespace Gonki_by_Dadadam
{
    public class PropBoost : AnimationSprite
    {
        public CarController Controller { get; set; }

        public PropBoost(CarController controller)
        {
            Controller = controller;
            Group = "Boost";
            Visible = false;
            Zindex = 10;

            for (int i = 1; i <= 38; i++)
                Frame.Add(new Bitmap(MainSpace.SelfRef.SpriteFolder + "BostFrame" + i + ".gif"));
            AnimationManager.Animations.Add(this);

            Current_Position();
        }

        public void Current_Position()
        {
            Width = Controller.Width * 0.8F;
            Height = Controller.Height * 0.7F;
            Left = Controller.Left - Width + Controller.Width * 0.1F;
            Top = Controller.Top + Controller.Width / 2 - Width / 2;
            Transform(Left, Top, Width, Height);
        }
    }
}
