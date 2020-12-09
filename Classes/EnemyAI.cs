using System;

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
            strategy_boost();
            strategy_speed();
            strategy_rotate();
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
            if (is_on_line() && Car_Enemy.Car.Cover_Distance < Car_Player.Car.Cover_Distance)
            {
                if (Car_Enemy.collision.Top < Car_Player.collision.Top 
                    && Car_Enemy.Top + Car_Enemy.collision.Height * 0.8F >= _leftboardtop)
                    Car_Enemy.rotate_left();
                else if (Car_Enemy.collision.Top + Car_Enemy.collision.Height * 0.8F <= _leftboardtop
                         && Car_Enemy.collision.Top + Car_Enemy.collision.Height * 1.2F >= _rightboardtop)
                    Car_Enemy.rotate_right();

                if (Car_Enemy.collision.Top > Car_Player.collision.Top 
                    && Car_Enemy.collision.Top + Car_Enemy.collision.Height * 1.2F <= _rightboardtop)
                    Car_Enemy.rotate_right();
                else if (Car_Enemy.collision.Top + Car_Enemy.collision.Height * 0.8F <= _leftboardtop 
                         && Car_Enemy.collision.Top + Car_Enemy.collision.Height * 1.2F >= _rightboardtop)
                    Car_Enemy.rotate_left();

            }

            if (!is_on_horizontal() && !is_on_line() && Car_Enemy.Car.Cover_Distance > Car_Player.Car.Cover_Distance)
            {
                if (Car_Enemy.Top + Car_Enemy.Height * rand.Next(1, 5) > Car_Player.Top + Car_Player.Height && Car_Enemy.Top + Car_Enemy.Height * 0.8F > _leftboardtop)
                    Car_Enemy.rotate_left();
                else if (Car_Enemy.Top + Car_Enemy.Height * 0.8F <= _leftboardtop)
                    Car_Enemy.rotate_right();

                if (Car_Enemy.Top + rand.Next(1, 20) < Car_Player.Top && Car_Enemy.Top + Car_Enemy.Height * 1.2F < _rightboardtop)
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
                if (Car_Enemy.Car.Curent_Boost_Charge >= Car_Enemy.Car.Max_Boost_Charge)
                    boost_flag = true;

                if (Car_Enemy.Car.Curent_Boost_Charge <= 0)
                    boost_flag = false;

                Car_Enemy.boost(boost_flag);
               
            }
            else
                Car_Enemy.boost(false);

            // sound animation boost off after overtake
            if (!is_on_line() && Car_Enemy.Car.Cover_Distance > Car_Player.Car.Cover_Distance && boost_flag)
            {
                boost_flag = false;
                Car_Enemy.at_overtake();
            }
        }

        bool is_on_line()
        {
            if ((Car_Enemy.collision.Top >= Car_Player.collision.Top && Car_Enemy.collision.Top <= Car_Player.collision.Top + Car_Player.collision.Height)
             || (Car_Enemy.collision.Top + Car_Enemy.collision.Height >= Car_Player.collision.Top && Car_Enemy.collision.Top + Car_Enemy.collision.Height <= Car_Player.collision.Top + Car_Player.collision.Height))
                return true;
            return false;
        }

        bool is_on_horizontal()
        {
            if ((Car_Enemy.collision.Left >= Car_Player.collision.Left
            && Car_Enemy.collision.Left <= Car_Player.collision.Left + Car_Player.collision.Width)
            || (Car_Enemy.collision.Left + Car_Enemy.collision.Width >= Car_Player.collision.Left
            && Car_Enemy.collision.Left + Car_Enemy.collision.Width <= Car_Player.collision.Left + Car_Player.collision.Width))
                return true;
            return false;
        }
    }
}
