using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public  class Collision
    {
        public Car Car { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Collision()
        {
            Left = 0;
            Top = 0;
            Width = 0;
            Height = 0;
        }
    }
}
