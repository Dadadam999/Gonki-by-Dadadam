using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gonki_by_Dadadam
{
    public class Sound
    {
        private MediaPlayer _player { get; set; } = new MediaPlayer();
        public bool Is_Loop { get; set; }
        public bool Is_Playing { get; set; } = false;
        public string Name { get; set; }
        public Uri Path_File { get; set; }
        public double Volume { get; set; } = 0.5; // min - max, 0 - 1.0

        public Sound(string name, Uri path_file, bool is_loop, double volume) 
        {
            Is_Loop = is_loop;
            Name = name;
            Volume = volume;
            Path_File = path_file;
            _player.MediaEnded += new EventHandler(MediaEnded);
            _player.Open(Path_File);
        }

        public void play_sound() 
        {
            if (!Is_Playing)
            {
                _player.Play();
                _player.Volume = Volume;
                Is_Playing = true;
            }
        }

        private void MediaEnded(object sender, EventArgs e)
        {
            if (Is_Loop)
                _player.Position = TimeSpan.Zero;
            else
                stop_sound();
        }

        public void stop_sound()
        {
            Is_Playing = false;
            _player.Stop();
        }
    }
}
