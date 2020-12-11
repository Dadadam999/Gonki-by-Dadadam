using System.Collections.Generic;
using System.Drawing;

namespace Gonki_by_Dadadam
{
    public class AnimationSprite
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public List<Bitmap> Frame { get; set; }
        public int Zindex { get; set; } = 0;
        public int IndexOf { get; set; } = 0;
        public bool IsLoop { get; set; } = true;
        public bool Visible { get; set; } = false;
        public float Top { get; set; }
        public float Left { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        private AnimationSprite _animation;

        public AnimationSprite(params Bitmap[] frames)
        {
            Frame = new List<Bitmap>();
            if (frames.Length > 0)
                Frame.AddRange(frames);
        }

        public Bitmap Next_Frame()
        {
            if (IndexOf < Frame.Count - 1)
                IndexOf++;
            else if (IsLoop)
                IndexOf = 0;

            return Frame[IndexOf];
        }

        public Bitmap Preview_Frame()
        {
            if (IndexOf >= 0)
                IndexOf--;
            else if (IsLoop)
                IndexOf = Frame.Count - 1;

            return Frame[IndexOf];
        }

        public void Transform(float left, float top, float width, float height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public AnimationSprite Clone()
        {
            _animation = new AnimationSprite()
            {
                Name = Name,
                Group = Group,
                Zindex = Zindex,
                IndexOf = IndexOf,
                IsLoop = IsLoop,
                Visible = Visible,
                Top = Top,
                Left = Left,
                Width = Width,
                Height = Height
            };
            _animation.Frame.AddRange(Frame.ToArray());
            return _animation;
        }
    }
}
