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
        public Collision CollisionObject { get; set; }

        public abstract void Init_Car(Car car);

        public abstract void Set_Start_Position();
    }
}
