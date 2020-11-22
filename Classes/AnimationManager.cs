using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public static class AnimationManager
    {
        public static List<AnimationSprite> Animations { get; set; }

        public static void Init() 
        {
            Animations = new List<AnimationSprite>();
        }

        public static void update_animations() {
            if (Animations.Count > 0)
                foreach (AnimationSprite anim in Animations)
                  if(anim.Visible)
                      anim.nextframe();
        }
    }
}
