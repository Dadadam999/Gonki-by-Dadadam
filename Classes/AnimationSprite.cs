using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class AnimationSprite
    {
        public List<Bitmap> Frame { get; set; }
        public int Zindex { get; set; } = 0;
        public int IndexOf { get; set; } = 0;
        public bool IsLoop { get; set; } = true;
        public bool Visible { get; set; } = false;
        public float Top { get; set; }
        public float Left { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        
        public AnimationSprite(params Bitmap[] Frames) {
            Frame = new List<Bitmap>();
            Frame.AddRange(Frames);
        }

        public Bitmap nextframe() 
        {
            if (IndexOf < Frame.Count - 1)
                IndexOf++;
            else if (IsLoop)
                IndexOf = 0;
               
            return Frame[IndexOf];
        }

        public Bitmap previewframe()
        {
            if (IndexOf >= 0)
                IndexOf--;
            else if (IsLoop)
                IndexOf = Frame.Count - 1;

            return Frame[IndexOf];
        }

        public void move(float Left, float Top)
        {
            this.Left = Left;
            this.Top = Top;
        }

        public void resize(float Width, float Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public AnimationSprite Clone()
        {
            AnimationSprite animation = new AnimationSprite();
            animation.Frame.AddRange(Frame.ToArray());
            animation.Zindex = Zindex;
            animation.IndexOf = IndexOf;
            animation.IsLoop = IsLoop;
            animation.Visible = Visible;
            animation.Top = Top;
            animation.Left = Left;
            animation.Width = Width;
            animation.Height = Height;
            return animation;
        }
    }
}
