using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class RoadController
    {
        public List<Road> Road_Parts { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public RoadController(int WidthScreen, int HeightScreen) 
        {
            Road_Parts = new List<Road>();
            Left = 0;
            Top = 0;
            Width = WidthScreen;
            Height = HeightScreen;

            create_boards_collision();

            create_road_parts(0);
            create_road_parts(Width-1);
        }

        public void create_boards_collision()
        {
           CollisionManager.Collisions.Add(new Collision("Left_Board", 0, Width * 0.12F, Width, Height * 0.1F));
           CollisionManager.Collisions.Add(new Collision("Right_Board", 0, Width * 0.52F, Width, Height * 0.1F));
        }


        public void create_road_parts(float Left)
        {
            Road_Parts.Add(new Road());
            Road_Parts[Road_Parts.Count - 1].Name = "Default_Road";
            Road_Parts[Road_Parts.Count - 1].Sprite = Properties.Resources.road;
            Road_Parts[Road_Parts.Count - 1].Width = Width;
            Road_Parts[Road_Parts.Count - 1].Height = Height;
            Road_Parts[Road_Parts.Count - 1].Top = 0;
            Road_Parts[Road_Parts.Count - 1].Left = Left;
        }

        public void move_road_parts(float speed)
        {
            foreach (Road road in Road_Parts)
                road.Left += speed * -1; //инвертироать скорость фона
        }

        public void prolong_road_parts()
        {
            float left = 0, right = 0;

            foreach (Road road in Road_Parts)
            {
                if (road.Left - Width < left)
                    left = road.Left;

                if (road.Left + Width > right)
                    right = road.Left;
            }

            if (left - Width > Width * -2)
                create_road_parts(left - Width + 1); //+1 l для подгонки швов текстур

            if (right + Width < Width * 2)
                create_road_parts(right + Width - 1);
        }

        public void remove_road_parts()
        {
            Road left = null, right = null;

            foreach (Road road in Road_Parts)
            {
                if (road.Left - Width < Width * -4)
                    left = road;

                if (road.Left + Width > Width * 4)
                    right = road;
            }

            if (left != null)
                Road_Parts.Remove(left);

            if (right != null)
                Road_Parts.Remove(right);
        }
    }
}
