using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public static class CollisionManager
    {
        public delegate void InteractCollision(string Name1, string Name2);
        public static event InteractCollision Interact;
        public static List<Collision> Collisions = new List<Collision>();
        static Rectangle rectangle1 = new Rectangle();
        static Rectangle rectangle2 = new Rectangle();

        public static void check()
        {
            if (Collisions.Count > 0)
                foreach (Collision collision1 in Collisions)
                    foreach (Collision collision2 in Collisions)
                    {
                        rectangle1.X = Convert.ToInt32(collision1.Left);
                        rectangle1.Y = Convert.ToInt32(collision1.Top);
                        rectangle1.Width = Convert.ToInt32(collision1.Width);
                        rectangle1.Height = Convert.ToInt32(collision1.Height);

                        rectangle2.X = Convert.ToInt32(collision2.Left);
                        rectangle2.Y = Convert.ToInt32(collision2.Top);
                        rectangle2.Width = Convert.ToInt32(collision2.Width);
                        rectangle2.Height = Convert.ToInt32(collision2.Height);

                        if (rectangle1.IntersectsWith(rectangle2) && !collision1.Equals(collision2))
                            Interact?.Invoke(collision1.Name, collision2.Name);
                    }
        }
    }
}
