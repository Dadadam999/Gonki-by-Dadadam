using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public static class CollisionManager
    {
        public delegate void InteractCollision(string name1, string name2);
        public static event InteractCollision Interact;

        public static List<Collision> Collisions { get; set; } = new List<Collision>();
        public static bool Work { get; set; } = false;

        private static Rectangle _rectangle1 = new Rectangle();
        private static Rectangle _rectangle2 = new Rectangle();

        public static void Check()
        {
            if (Collisions.Count > 0 && Work)
                foreach (Collision collision1 in Collisions)
                    foreach (Collision collision2 in Collisions)
                    {
                        _rectangle1.X = Convert.ToInt32(collision1.Left);
                        _rectangle1.Y = Convert.ToInt32(collision1.Top);
                        _rectangle1.Width = Convert.ToInt32(collision1.Width);
                        _rectangle1.Height = Convert.ToInt32(collision1.Height);

                        _rectangle2.X = Convert.ToInt32(collision2.Left);
                        _rectangle2.Y = Convert.ToInt32(collision2.Top);
                        _rectangle2.Width = Convert.ToInt32(collision2.Width);
                        _rectangle2.Height = Convert.ToInt32(collision2.Height);

                        if (_rectangle1.IntersectsWith(_rectangle2) && !collision1.Equals(collision2))
                            Interact?.Invoke(collision1.Name, collision2.Name);
                    }
        }
    }
}