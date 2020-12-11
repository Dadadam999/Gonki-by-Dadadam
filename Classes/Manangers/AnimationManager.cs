using System.Collections.Generic;
using System.Linq;

namespace Gonki_by_Dadadam
{
    public static class AnimationManager
    {
        public static List<AnimationSprite> Animations { get; set; } = new List<AnimationSprite>();

        public static void Update_Animations()
        {
            if (Animations.Count > 0)
                foreach (AnimationSprite anim in Animations)
                    if (anim.Visible)
                        anim.Next_Frame();
        }

        public static void Set_Transform(float left, float top, float width, float height, params string[] names)
        {
            foreach (AnimationSprite anim in Animations)
                if (names.Contains(anim.Name))
                    anim.Transform(left, top, width, height);
        }

        public static void Set_Visible(bool visible, params string[] names)
        {
            foreach (AnimationSprite anim in Animations)
                if (names.Contains(anim.Name))
                    anim.Visible = visible;
        }

        public static void Group_Transform(float left, float top, float width, float height, string group)
        {
            foreach (AnimationSprite anim in Animations)
                if (group == anim.Group)
                    anim.Transform(left, top, width, height);
        }

        public static void Group_Visible(bool visible, string group)
        {
            foreach (AnimationSprite anim in Animations)
                if (group == anim.Group)
                    anim.Visible = visible;
        }
    }
}
