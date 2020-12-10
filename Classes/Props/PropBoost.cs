using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class PropBoost : AnimationSprite
    {
        public CarController Controller { get; set; }

        public PropBoost(CarController Controller) 
        {
            this.Controller = Controller;
            Group = "Boost";
            Visible = false;
            Zindex = 10;

            for (int i = 1; i <= 38; i++)
               Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "BostFrame" + i + ".gif"));

            AnimationManager.Animations.Add(this);
            
            current_position();
        }

        public void current_position() 
        {
            Width = Controller.Width * 0.8F;
            Height = Controller.Height * 0.7F;
            Left = Controller.Left - Width + Controller.Width * 0.1F;
            Top = Controller.Top + Controller.Width / 2 - Width / 2;
            transform(Left, Top, Width, Height);
        }
    }
}
