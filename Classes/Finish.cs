using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    class Finish
    {
        public Bitmap Sprite { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Top { get; set; }
        public float Left { get; set; }
        public int Distance { get; set; }
        public bool Win { get; set; }
        public string Result { get; set; }
        private int _widthscrren { get; set; }
        public Finish(int Distance, int WidthScreen, int HeightScreen)
        {
            _widthscrren = WidthScreen;
            this.Distance = Distance;
            Sprite = Properties.Resources.finish_line;
            Width = WidthScreen * 0.1F;
            Height = HeightScreen;
            Top = 0;
            Left = Distance * WidthScreen;
        }

        public void check_win(float Player_Distance, float Enemy_Distance)
        {
            if (!Win && Player_Distance > _widthscrren * Distance)
            {
                Result = "Player";
                Win = true;
            }

            if (!Win && Enemy_Distance > _widthscrren * Distance)
            {
                Result = "Enemy ";
                Win = true;
            }
        }

        public void move(float speed)
        {
            Left += speed * -1; //инвертироать скорость фона
        }
    }
}
