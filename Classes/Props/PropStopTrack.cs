using System.Collections.Generic;
using System.Drawing;

namespace Gonki_by_Dadadam
{
    public class PropStopTrack
    {
        private List<AnimationSprite> _tracks { get; set; } = new List<AnimationSprite>();
        public CarController Controller { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        private AnimationSprite _template;

        public PropStopTrack(CarController controller)
        {
            Controller = controller;
        }

        public void Paint()
        {
            _template = new AnimationSprite()
            {
                Name = "TrackStop",
                Group = "TrackStop",
                Zindex = 2,
                Visible = true,
                Width = Controller.Width * 0.2F,
                Height = Controller.Height,
                Left = Controller.Left - Width,
                Top = Controller.Top
            };
            _template.Frame.Add(new Bitmap(MainSpace.SelfRef.SpriteFolder + "RoadTrack.png"));
            _tracks.Add(_template);
            AnimationManager.Animations.Add(_template);
        }

        public void Remove(float widthScreen)
        {
            AnimationSprite left = null;

            foreach (AnimationSprite track in _tracks)
                if (track.Left - widthScreen < widthScreen * -4)
                    left = track;

            if (left != null)
            {
                AnimationManager.Animations.Remove(left);
                _tracks.Remove(left);
            }
        }

        public void Update(float speed)
        {
            foreach (AnimationSprite track in _tracks)
                track.Transform(track.Left += speed, track.Top, track.Width, track.Height);
        }
    }
}
