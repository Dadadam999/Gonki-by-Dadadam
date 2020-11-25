using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gonki_by_Dadadam
{
    public static class MusicManager
    {
        public static Dictionary<string, Uri> Musics { get; set; } = new Dictionary<string, Uri>();
        private static MediaPlayer _player_music { get; set; } = new MediaPlayer();
        public static void change_music(string NameSound)
        {
            foreach (KeyValuePair<string, Uri> sound in Musics)
                if (sound.Key == NameSound)
                {
                    _player_music.Open(sound.Value);
                    _player_music.Play();
                    break;
                }
        }
    }
}
