using System;

namespace Gonki_by_Dadadam
{
    public class EnemyAI
    {
        private static readonly Random _rand = new Random();
        public PlayerController CarPlayer { get; set; }
        public EnemyController CarEnemy { get; set; }
        private static float _leftBoardTop { get; set; }
        private static float _rightBoardTop { get; set; }

        private static bool _boostFlag = false;

        public EnemyAI()
        {
            _leftBoardTop = CollisionManager.Collisions.Find(x => x.Name.Contains("Left_Board")).Top + CollisionManager.Collisions.Find(x => x.Name.Contains("Left_Board")).Height;
            _rightBoardTop = CollisionManager.Collisions.Find(x => x.Name.Contains("Right_Board")).Top;
        }

        public void Behavior()
        {
            Strategy_Boost();
            Strategy_Speed();
            Strategy_Rotate();
        }

        private void Strategy_Speed()
        {
            if (Is_On_Line()
             && (CarPlayer.Car.CoverDistance - CarEnemy.Car.CoverDistance < CarPlayer.Width * 2) // дать рандомное значение привязанное к экрану
             && (CarPlayer.Car.CoverDistance - CarEnemy.Car.CoverDistance > 0))
            {
                CarEnemy.Minus_Speed();
                CarEnemy.Boost(false);
            }
            else
                CarEnemy.Plus_Speed();
        }

        private void Strategy_Rotate()
        {
            if (Is_On_Line() && (CarEnemy.Car.CoverDistance < CarPlayer.Car.CoverDistance))
            {
                if ((CarEnemy.CollisionObject.Top < CarPlayer.CollisionObject.Top)
                 && (CarEnemy.Top + CarEnemy.CollisionObject.Height * 0.8F >= _leftBoardTop))
                        CarEnemy.Rotate_Left();
                else if ((CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height * 0.8F <= _leftBoardTop)
                      && (CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height * 1.2F >= _rightBoardTop))
                            CarEnemy.Rotate_Right();

                if ((CarEnemy.CollisionObject.Top > CarPlayer.CollisionObject.Top)
                 && (CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height * 1.2F <= _rightBoardTop))
                        CarEnemy.Rotate_Right();
                else if ((CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height * 0.8F <= _leftBoardTop)
                      && (CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height * 1.2F >= _rightBoardTop))
                            CarEnemy.Rotate_Left();
            }

            if (!Is_On_Horizontal() && !Is_On_Line() && (CarEnemy.Car.CoverDistance > CarPlayer.Car.CoverDistance))
            {
                if ((CarEnemy.Top + CarEnemy.Height * _rand.Next(1, 20) > CarPlayer.Top + CarPlayer.Height)
                 && (CarEnemy.Top + CarEnemy.Height * 0.8F > _leftBoardTop))
                        CarEnemy.Rotate_Left();
                else if (CarEnemy.Top + CarEnemy.Height * 0.8F <= _leftBoardTop)
                            CarEnemy.Rotate_Right();

                if ((CarEnemy.Top + _rand.Next(1, 20) < CarPlayer.Top) 
                 && (CarEnemy.Top + CarEnemy.Height * 1.2F < _rightBoardTop))
                        CarEnemy.Rotate_Right();
                else if (CarEnemy.Top + CarEnemy.Height * 1.2F >= _rightBoardTop)
                            CarEnemy.Rotate_Left();
            }
        }

        private void Strategy_Boost()
        {
            if (!Is_On_Line() && CarEnemy.Car.CoverDistance < CarPlayer.Car.CoverDistance)
            {
                if (CarEnemy.Car.CurentBoostCharge >= CarEnemy.Car.MaxBoostCharge)
                    _boostFlag = true;

                if (CarEnemy.Car.CurentBoostCharge <= 0)
                    _boostFlag = false;

                CarEnemy.Boost(_boostFlag);

            }
            else
                CarEnemy.Boost(false);

            // sound animation boost off after overtake
            if (!Is_On_Line() && (CarEnemy.Car.CoverDistance > CarPlayer.Car.CoverDistance && _boostFlag))
            {
                _boostFlag = false;
                CarEnemy.At_Overtake();
            }
        }

        private bool Is_On_Line()
        {
            if (((CarEnemy.CollisionObject.Top >= CarPlayer.CollisionObject.Top)
              && (CarEnemy.CollisionObject.Top <= CarPlayer.CollisionObject.Top + CarPlayer.CollisionObject.Height))
             || ((CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height >= CarPlayer.CollisionObject.Top) 
              && (CarEnemy.CollisionObject.Top + CarEnemy.CollisionObject.Height <= CarPlayer.CollisionObject.Top + CarPlayer.CollisionObject.Height)))
                return true;
            return false;
        }

        private bool Is_On_Horizontal()
        {
           if (((CarEnemy.CollisionObject.Left >= CarPlayer.CollisionObject.Left)
             && (CarEnemy.CollisionObject.Left <= CarPlayer.CollisionObject.Left + CarPlayer.CollisionObject.Width))
            || ((CarEnemy.CollisionObject.Left + CarEnemy.CollisionObject.Width >= CarPlayer.CollisionObject.Left)
             && (CarEnemy.CollisionObject.Left + CarEnemy.CollisionObject.Width <= CarPlayer.CollisionObject.Left + CarPlayer.CollisionObject.Width)))
                return true;
            return false;
        }
    }
}
