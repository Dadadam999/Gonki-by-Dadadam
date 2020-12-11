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
            _player.MediaOpened += _player_MediaOpened;
            _player.Volume = 0;
            _player.Open(Path_File);
        }

        private void _player_MediaOpened(object sender, EventArgs e)
        {
            MainSpace.selfref.load();
            Debug.selfref.add_input($"Load {Name}");
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

        public void change_volume(double Volume)
        {
            _player.Volume = Volume;
        }

        public void reset_volume()
        {
            _player.Volume = Volume;
        }
    }
}
