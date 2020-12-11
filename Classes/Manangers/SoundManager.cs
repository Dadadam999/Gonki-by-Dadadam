using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gonki_by_Dadadam
{
    public static class SoundManager
    {
        public static List<Sound> sounds { get; set; } = new List<Sound>();

        public static void play_sound(string Name) 
        {
            sounds.Find(x => x.Name == Name)?.play_sound();
        }

        public static void stop_sound(string Name)
        {
            sounds.Find(x => x.Name == Name)?.stop_sound();
        }

        public static void change_volume_sound(string Name, double Volume)
        {
            sounds.Find(x => x.Name == Name)?.change_volume(Volume);
        }

        public static void reset_volume_sound(string Name)
        {
            sounds.Find(x => x.Name == Name)?.reset_volume();
        }


        public static void stop_all_sound() 
        {
            foreach (Sound sound in sounds)
                sound.stop_sound();
        }
    }
}
