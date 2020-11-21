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
        public int IndexOf { get; set; }
        public bool IsLoop { get; set; }

        public AnimationSprite(params Bitmap[] Frames) {
            Frame = new List<Bitmap>();
            Frame.AddRange(Frames);
            IsLoop = true;
            IndexOf = 0;
        }

        public Bitmap nextframe() 
        {
            if (IndexOf < Frame.Count)
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
    }
}
