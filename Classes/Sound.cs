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
        public string Name { get; set; }
        public Uri Path_File { get; set; }

        public Sound(string name, Uri path_file, bool is_loop) 
        {
            Is_Loop = is_loop;
            Name = name;
            Path_File = path_file;
            _player.MediaEnded += new EventHandler(MediaEnded);
        }

        private void MediaEnded(object sender, EventArgs e)
        {
            if (Is_Loop)
            {
                _player.Position = TimeSpan.Zero;
                _player.Play();
            }
        }

        public void play_sound() 
        {
            _player.Open(Path_File);
            _player.Play();
        }

        public void stop_sound()
        {
            _player.Stop();
        }
    }
}
