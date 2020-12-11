using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Gonki_by_Dadadam
{
    public class RoadController
    {
        public List<AnimationSprite> RoadParts { get; set; } = new List<AnimationSprite>();
        public float WidthScreen { get; set; }
        public float HeightScreen { get; set; }

        private static readonly Random _rand = new Random();
        private readonly string[] _spriteNames = { "RoadDefault", "RoadBuilder", "RoadCross", "RoadBridge", "RoadStation" };
        private AnimationSprite _template;

        public RoadController(int widthScreen, int heightScreen)
        {
            WidthScreen = widthScreen;
            HeightScreen = heightScreen;

            Create_Boards_Collision();
            Create_Road_Parts(0);
            Create_Road_Parts(WidthScreen * 1 - 1);
        }

        public void Create_Boards_Collision()
        {
            CollisionManager.Collisions.Add(new Collision("Left_Board", 0, WidthScreen * 0.12F, WidthScreen, HeightScreen * 0.1F));
            CollisionManager.Collisions.Add(new Collision("Right_Board", 0, WidthScreen * 0.52F, WidthScreen, HeightScreen * 0.1F));
        }

        public void Create_Road_Parts(float Left)
        {
            _template = new AnimationSprite()
            {
                Name = _spriteNames[_rand.Next(0, _spriteNames.Length)],
                Group = "Road",
                Zindex = -1,
                Visible = true
            };
            _template.Frame.Add(new Bitmap(MainSpace.SelfRef.SpriteFolder + _template.Name + ".png"));
            _template.Transform(Left, 0, WidthScreen, HeightScreen);
            AnimationManager.Animations.Add(_template);
            RoadParts.Add(_template);
        }

        public void Move_Road_Parts(float speed)
        {
            foreach (AnimationSprite road in RoadParts)
                road.Left += speed * -1; //инвертироать скорость фона
        }

        float add_left, add_right;
        public void Prolong_Road_Parts()
        {
            add_left = RoadParts.Max(x => x.Left);
            add_right = RoadParts.Min(x => x.Left);

            if (add_left + WidthScreen < WidthScreen * 2)
                Create_Road_Parts(add_left + WidthScreen - 1); //+1 для подгонки швов текстур

            if (add_right - WidthScreen > WidthScreen * -2)
                Create_Road_Parts(add_right - WidthScreen + 1);
        }

        public void Remove_Road_Parts()
        {
            AnimationSprite left = null, right = null;

            foreach (AnimationSprite road in RoadParts)
            {
                if (road.Left + WidthScreen > WidthScreen * 4)
                    left = road;

                if (road.Left - WidthScreen < WidthScreen * -4)
                    right = road;
            }

            if (left != null)
            {
                AnimationManager.Animations.Remove(left);
                RoadParts.Remove(left);
            }

            if (right != null)
            {
                AnimationManager.Animations.Remove(right);
                RoadParts.Remove(right);
            }
        }
    }
}