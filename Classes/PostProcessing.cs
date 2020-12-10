using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class PostProcessing
    {
        public AnimationSprite PPLight { get; set; }
        public AnimationSprite PPeclipse { get; set; }
        public PostProcessing(float WidthScreen, float HeightScreen)
        {
            PPLight = new AnimationSprite()
            {
                Name = "PPLight",
                Group = "PostProcessing",
                Zindex = 201,
                Visible = true,
                Width = WidthScreen,
                Height = HeightScreen,
                Left = 0,
                Top = 0
            };
            PPLight.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "PPLight.png"));
            AnimationManager.Animations.Add(PPLight);

            PPeclipse = new AnimationSprite()
            {
                Name = "PPLight",
                Group = "PostProcessing",
                Zindex = 200,
                Visible = true,
                Width = WidthScreen,
                Height = HeightScreen,
                Left = 0,
                Top = 0
            };
            PPeclipse.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "PPeclipse.png"));
            AnimationManager.Animations.Add(PPeclipse);
        }
    }
}
