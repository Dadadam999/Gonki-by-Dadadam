using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Gonki_by_Dadadam
{
    public static class VoiceManager
    {
        public static Dictionary<string, Uri> Voices { get; set; } = new Dictionary<string, Uri>();
        private static MediaPlayer _playerVoice { get; set; } = new MediaPlayer();

        public static void Change_Voice(string nameSound)
        {
            foreach (KeyValuePair<string, Uri> sound in Voices)
                if (sound.Key == nameSound)
                {
                    _playerVoice.Open(sound.Value);
                    _playerVoice.Play();
                    break;
                }
        }
    }
}
