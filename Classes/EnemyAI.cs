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
        float _leftboardtop, _rightboardtop;

        public EnemyAI()
        {
            _leftboardtop = CollisionManager.Collisions.Find(x => x.Name.Contains("Left_Board")).Top + CollisionManager.Collisions.Find(x => x.Name.Contains("Left_Board")).Height;
            _rightboardtop = CollisionManager.Collisions.Find(x => x.Name.Contains("Right_Board")).Top;
        }

        public void behavior()
        {
            strategy_speed();
            strategy_rotate();
            strategy_boost();
        }

        void strategy_speed()
        {
            if (is_on_line()
             && Car_Player.Car.Cover_Distance - Car_Enemy.Car.Cover_Distance < Car_Player.Width * 2 // дать рандомное значение привязанное к экрану
             && Car_Player.Car.Cover_Distance - Car_Enemy.Car.Cover_Distance > 0)
            {
                Car_Enemy.minus_speed();
                Car_Enemy.boost(false);
            }
            else
                Car_Enemy.plus_speed();
        }

        void strategy_rotate()
        {
            if (is_on_line() && Car_Enemy.Car.Cover_Distance < Car_Player.Car.Cover_Distance) {

                if (Car_Enemy.Top < Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height * 0.8F > _leftboardtop)
                    Car_Enemy.rotate_left();
                else if (Car_Enemy.Top + Car_Enemy.Height * 0.8F <= _leftboardtop && Car_Enemy.Top + Car_Enemy.Height * 1.2F >= _rightboardtop)
                    Car_Enemy.rotate_right();

                if (Car_Enemy.Top > Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height * 1.2F < _rightboardtop)
                    Car_Enemy.rotate_right();
                else if (Car_Enemy.Top + Car_Enemy.Height * 0.8F <= _leftboardtop && Car_Enemy.Top + Car_Enemy.Height * 1.2F >= _rightboardtop)
                    Car_Enemy.rotate_left();
            }

            if (!is_on_horizontal() && !is_on_line() && Car_Enemy.Car.Cover_Distance > Car_Player.Car.Cover_Distance)
            {
                if (Car_Enemy.Top * Car_Enemy.Height * rand.Next(1, 3) > Car_Player.Top * Car_Player.Height && Car_Enemy.Top + Car_Enemy.Height * 0.8F > _leftboardtop)
                    Car_Enemy.rotate_left();
                else if (Car_Enemy.Top + Car_Enemy.Height * 0.8F <= _leftboardtop)
                    Car_Enemy.rotate_right();

                if (Car_Enemy.Top < Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height * 1.2F < _rightboardtop)
                    Car_Enemy.rotate_right();
                else if (Car_Enemy.Top + Car_Enemy.Height * 1.2F >= _rightboardtop)
                    Car_Enemy.rotate_left();
            }
        }
        bool boost_flag = false;
        void strategy_boost()
        {
            if (!is_on_line() && Car_Enemy.Car.Cover_Distance < Car_Player.Car.Cover_Distance)
            {

                if (Car_Enemy.Car.Curent_Boost_Charge >= rand.Next(Convert.ToInt32(Car_Enemy.Car.Max_Boost_Charge / 2), Convert.ToInt32(Car_Enemy.Car.Max_Boost_Charge)) 
                 && rand.Next(1, 100) > 80)
                    boost_flag = true;

                if (Car_Enemy.Car.Curent_Boost_Charge <= 0)
                        boost_flag = false;


                Car_Enemy.boost(boost_flag);
            }
        }

        bool is_on_line()
        {
            if ((Car_Enemy.Top >= Car_Player.Top && Car_Enemy.Top <= Car_Player.Top + Car_Player.Height)
             || (Car_Enemy.Top + Car_Enemy.Height >= Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height <= Car_Player.Top + Car_Player.Height))
                return true;
            return false;
        }

        bool is_on_horizontal()
        {
            if ((Car_Enemy.Left >= Car_Player.Left
            && Car_Enemy.Left <= Car_Player.Left + Car_Player.Width)
            || (Car_Enemy.Left + Car_Enemy.Width >= Car_Player.Left
            && Car_Enemy.Left + Car_Enemy.Width <= Car_Player.Left + Car_Player.Width))
                return true;
            return false;
        }
    }
}
