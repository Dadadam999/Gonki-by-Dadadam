using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public static class AnimationManager
    {
        public static List<AnimationSprite> Animations { get; set; } = new List<AnimationSprite>();

        public static void update_animations() {
            if (Animations.Count > 0)
                foreach (AnimationSprite anim in Animations)
                  if(anim.Visible)
                      anim.nextframe();
        }

        public static void set_transform(float Left, float Top, float Width, float Height, params string[] Names) 
        {
            foreach (AnimationSprite anim in Animations)
                if (Names.Contains(anim.Name))
                    anim.transform(Left, Top, Width, Height);
        }

        public static void set_visible(bool Visible, params string[] Names)
        {
            foreach (AnimationSprite anim in Animations)
                if (Names.Contains(anim.Name))
                    anim.Visible = Visible;
        }

        public static void group_transform(float Left, float Top, float Width, float Height, string Group)
        {
            foreach (AnimationSprite anim in Animations)
                if (Group == anim.Group)
                    anim.transform(Left, Top, Width, Height);
        }

        public static void group_visible(bool Visible, string Group)
        {
            foreach (AnimationSprite anim in Animations)
                if (Group == anim.Group)
                    anim.Visible = Visible;
        }
    }
}
