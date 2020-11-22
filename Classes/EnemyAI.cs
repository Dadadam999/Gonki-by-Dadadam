using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gonki_by_Dadadam
{
    public class EnemyAI
    {
        static Random rand = new Random();
        public PlayerController Car_Player { get; set; }
        public EnemyController Car_Enemy { get; set; }

        public void behavior() {
            strategy_speed();
        }

        void strategy_overtake()
        {
            
        }

        void strategy_speed()
        {
            if (is_on_line()
             && Car_Player.Car.Cover_Distance - Car_Enemy.Car.Cover_Distance < 200 // дать рандомное значение привязанное к экрану
             && Car_Player.Car.Cover_Distance - Car_Enemy.Car.Cover_Distance > 0)
                Car_Enemy.minus_speed();
            else
                Car_Enemy.plus_speed();
        }

        void strategy_rotate()
        {

        }

        void strategy_boost()
        {

        }

        void strategy_position()
        {

        }

        bool is_on_line()
        {
            if ((Car_Enemy.Top >= Car_Player.Top && Car_Enemy.Top <= Car_Player.Top + Car_Player.Height)
             || (Car_Enemy.Top + Car_Enemy.Height >= Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height <= Car_Player.Top + Car_Player.Height))
                return true;
            return false;
        }
    }
}
