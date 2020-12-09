using System;
using System.Collections.Generic;
using System.Drawing;
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
        private static Random _rand = new Random();
        private string[] sprite_names = { "RoadDefault", "RoadBuilder", "RoadCross", "RoadBridge", "RoadStation" };
        private AnimationSprite template;
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
            template = new AnimationSprite()
            {
                Name = sprite_names[_rand.Next(0, sprite_names.Length)],
                Group = "Road",
                Zindex = -1,
                Visible = true
            };
            template.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + template.Name + ".png"));
            template.transform(Left, 0, WidthScreen, HeightScreen);
            AnimationManager.Animations.Add(template);
            Road_Parts.Add(template);
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
                if (road.Left - road.Width < WidthScreen * -4)
                {
                    left = road;
                    Debug.selfref.add_input($"!iD = {road.Name} LeftBoard: {road.Left - road.Width} < Width4: {WidthScreen * -4} ");
                }

                if (road.Left + road.Width > WidthScreen * 4)
                {
                    right = road;
                    Debug.selfref.add_input($"!RightBoard: {road.Left + road.Width} > Width4: {WidthScreen * 4} ");
                }
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
