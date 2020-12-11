using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Gonki_by_Dadadam
{
    public static class MusicManager
    {
        public static Dictionary<string, Uri> Musics { get; set; } = new Dictionary<string, Uri>();
        private static MediaPlayer _playerMusic { get; set; } = new MediaPlayer();

        public static void Change_Music(string nameSound)
        {
            foreach (KeyValuePair<string, Uri> sound in Musics)
                if (sound.Key == nameSound)
                {
                    _playerMusic.Open(sound.Value);
                    _playerMusic.Play();
                    break;
                }
        }
    }
}
