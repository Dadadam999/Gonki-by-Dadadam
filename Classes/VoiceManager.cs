using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Gonki_by_Dadadam
{
    public class VoiceManager
    {
        public static Dictionary<string, Uri> Voices { get; set; } = new Dictionary<string, Uri>();
        private static MediaPlayer _player_voice { get; set; } = new MediaPlayer();
        public static void change_voice(string NameSound)
        {
            foreach (KeyValuePair<string, Uri> sound in Voices)
                if (sound.Key == NameSound)
                {
                    _player_voice.Open( sound.Value);
                    _player_voice.Play();
                    break;
                }
        }
    }
}
