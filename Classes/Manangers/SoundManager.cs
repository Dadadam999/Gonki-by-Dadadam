using System.Collections.Generic;

namespace Gonki_by_Dadadam
{
    public static class SoundManager
    {
        public static List<Sound> Sounds { get; set; } = new List<Sound>();

        public static void Play_Sound(string Name)
        {
            Sounds.Find(x => x.Name == Name)?.Play_Sound();
        }

        public static void Stop_Sound(string Name)
        {
            Sounds.Find(x => x.Name == Name)?.Stop_Sound();
        }

        public static void Change_Volume_Sound(string Name, double Volume)
        {
            Sounds.Find(x => x.Name == Name)?.Change_Volume(Volume);
        }

        public static void Reset_Volume_Sound(string Name)
        {
            Sounds.Find(x => x.Name == Name)?.Reset_Volume();
        }

        public static void Stop_All_Sound()
        {
            foreach (Sound sound in Sounds)
                sound.Stop_Sound();
        }
    }
}
