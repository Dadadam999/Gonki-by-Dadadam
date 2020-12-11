namespace Gonki_by_Dadadam
{
    public class Collision
    {
        public string Name { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Collision(string name, float left, float top, float width, float height)
        {
            Name = name;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public void Update(float left, float top, float width, float height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
}
