using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public  class Collision
    {
        public string Name { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Collision(string Name, float Left, float Top, float Width, float Height)
        {
            this.Name = Name;
            this.Left = Left;
            this.Top = Top;
            this.Width = Width;
            this.Height = Height;
        }

        public void update(float Left, float Top, float Width, float Height)
        {
            this.Left = Left;
            this.Top = Top;
            this.Width = Width;
            this.Height = Height;
        }
    }
}
