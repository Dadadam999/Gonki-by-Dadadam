using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gonki_by_Dadadam
{
    public class PropStopTrack
    {
        private List<AnimationSprite> _tracks { get; set; } = new List<AnimationSprite>();

        public CarController Controller { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public PropStopTrack(CarController Controller)
        {
            this.Controller = Controller;
        }

        public void paint()
        {
            AnimationSprite template = new AnimationSprite()
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
            template.Frame.Add(new Bitmap(MainSpace.selfref.SpriteFolder + "RoadTrack.png"));
            _tracks.Add(template);
            AnimationManager.Animations.Add(template);
        }

        public void remove(float WidthScreen)
        {
            AnimationSprite left = null;

            foreach (AnimationSprite track in _tracks)
                if (track.Left - WidthScreen < WidthScreen * -4)
                    left = track;

            if (left != null)
            {
                AnimationManager.Animations.Remove(left);
                _tracks.Remove(left);
            }
        }

        public void update(float speed)
        {
            foreach (AnimationSprite track in _tracks)
                track.transform(track.Left += speed, track.Top, track.Width, track.Height);
        }
    }
}
