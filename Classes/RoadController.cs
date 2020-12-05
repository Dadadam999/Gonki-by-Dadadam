using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class RoadController
    {
        public List<AnimationSprite> Road_Parts { get; set; } = new List<AnimationSprite>();
        public float WidthScreen { get; set; }
        public float HeightScreen { get; set; }

        public RoadController(int WidthScreen, int HeightScreen) 
        {
            this.WidthScreen = WidthScreen;
            this.HeightScreen = HeightScreen;

            create_boards_collision();

            create_road_parts(0);
            create_road_parts(WidthScreen - 1);
        }

        public void create_boards_collision()
        {
           CollisionManager.Collisions.Add(new Collision("Left_Board", 0, WidthScreen * 0.12F, WidthScreen, HeightScreen * 0.1F));
           CollisionManager.Collisions.Add(new Collision("Right_Board", 0, WidthScreen * 0.52F, WidthScreen, HeightScreen * 0.1F));
        }


        public void create_road_parts(float Left)
        {
            Road_Parts.Add(new AnimationSprite());
            Road_Parts[Road_Parts.Count - 1] = new AnimationSprite(Properties.Resources.RoadDefault);
            Road_Parts[Road_Parts.Count - 1].Zindex = -1;
            Road_Parts[Road_Parts.Count - 1].Visible = true;
            Road_Parts[Road_Parts.Count - 1].Width = WidthScreen;
            Road_Parts[Road_Parts.Count - 1].Height = HeightScreen;
            Road_Parts[Road_Parts.Count - 1].Top = 0;
            Road_Parts[Road_Parts.Count - 1].Left = Left;
            AnimationManager.Animations.Add(Road_Parts[Road_Parts.Count - 1]);
        }

        public void move_road_parts(float speed)
        {
            foreach (AnimationSprite road in Road_Parts)
                road.Left += speed * -1; //инвертироать скорость фона
        }

        public void prolong_road_parts()
        {
            float left = 0, right = 0;

            foreach (AnimationSprite road in Road_Parts)
            {
                if (road.Left - WidthScreen < left)
                    left = road.Left;

                if (road.Left + WidthScreen > right)
                    right = road.Left;
            }

            if (left - WidthScreen > WidthScreen * -2)
                create_road_parts(left - WidthScreen + 1); //+1 l для подгонки швов текстур

            if (right + WidthScreen < WidthScreen * 2)
                create_road_parts(right + WidthScreen - 1);
        }

        public void remove_road_parts()
        {
            AnimationSprite left = null, right = null;

            foreach (AnimationSprite road in Road_Parts)
            {
                if (road.Left - WidthScreen < WidthScreen * -4)
                    left = road;

                if (road.Left + WidthScreen > WidthScreen * 4)
                    right = road;
            }

            if (left != null)
            {
                AnimationManager.Animations.Remove(left);
                Road_Parts.Remove(left);
            }

            if (right != null)
            {
                AnimationManager.Animations.Remove(right);
                Road_Parts.Remove(right);
            }
        }
    }
}
