using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public abstract class CarController
    {

        public Car Car { get; set; }
        public float Left { get; set; } = 0;
        public float Top { get; set; } = 0;
        public float Width { get; set; } = 0;
        public float Height { get; set; } = 0;

        public bool Freeze { get; set; } = false;
        public Collision collision { get; set; }

        public abstract void init_car(Car car);

        public abstract void set_start_position();
    }
}
