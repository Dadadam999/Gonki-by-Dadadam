namespace Gonki_by_Dadadam
{
    public class EnemyController : CarController
    {
        public delegate void StateMachine(string state);
        public event StateMachine State;

        private readonly float _widthScreen;
        private readonly float _heightScreen;

        public EnemyController(int WidthScreen, int HeightScreen)
        {
            _widthScreen = WidthScreen;
            _heightScreen = HeightScreen;

            CollisionObject = new Collision("Enemy_Car", Left, Top, Width, Height);
            CollisionManager.Collisions.Add(CollisionObject);
        }

        public override void Init_Car(Car car)
        {
            Car = car;
            Car.AnimationDefault.Visible = true;
            AnimationManager.Animations.Add(Car.AnimationDefault);
            AnimationManager.Animations.Add(Car.AnimationBack);
            AnimationManager.Animations.Add(Car.AnimationStop);
            AnimationManager.Animations.Add(Car.AnimationRotateLeft);
            AnimationManager.Animations.Add(Car.AnimationRotateRight);
            AnimationManager.Animations.Add(Car.AnimationBreaking);
        }

        public override void Set_Start_Position()
        {
            Left = _widthScreen / 3;
            Top = _heightScreen / 9 * 5;

            Width = _widthScreen / 7;
            Height = _heightScreen / 9;

            AnimationManager.Group_Transform(Left, Top, Width, Height, Car.Id);
        }

        public void Plus_Speed()
        {
            if (Car.CurrentSpeed >= Car.MaxSpeed * -1)
            {
                Car.CurrentSpeed -= Car.StepSpeed;
                State?.Invoke("PlusSpeed");
            }
        }

        public void Minus_Speed()
        {
            if (Car.CurrentSpeed <= Car.BackSpeed)
            {
                Car.CurrentSpeed += Car.StepSpeed;
                State?.Invoke("Back");
            }
        }

        public void Rotate_Left()
        {
            Top -= Car.RotateLeftSpeed;
            State?.Invoke("Left");
        }

        public void Rotate_Right()
        {
            Top += Car.RotateRightSpeed;
            State?.Invoke("Right");
        }

        public void Boost(bool turn)
        {
            if (!turn && Car.CurentBoostCharge <= Car.MaxBoostCharge)
                Car.CurentBoostCharge++;

            if (turn && Car.CurrentSpeed < 0)
            {
                Car.CurentBoostCharge--;

                if (Car.CurrentSpeed > (Car.MaxSpeed + Car.BoostSpeed) * -1)
                    Car.CurrentSpeed -= Car.BoostSpeed;

                if (Car.CurentBoostCharge <= 0)
                {
                    Car.CurrentSpeed = Car.MaxSpeed * -1;
                    State?.Invoke("UnBoost");
                }
                else
                    State?.Invoke("Boost");
            }

            if (!turn && Car.CurrentSpeed < Car.MaxSpeed * -1)
                Car.CurrentSpeed = Car.MaxSpeed * -1;
        }

        public void Move_Enemy(float currentPlayerSpeed)
        {
            if (Car.CurrentSpeed < Car.MaxSpeed)
                Left -= currentPlayerSpeed + Car.CurrentSpeed;
        }

        public void At_Overtake()
        {
            State?.Invoke("AtOvertake");
        }

        public bool Is_Out_Screen()
        {
            return Left + Width < 0 || Left > _widthScreen;
        }

        public void Update()
        {
            if (Car.CurrentSpeed == 0)
                State?.Invoke("Stop");
            else
                State?.Invoke("Forward");

            Car.CoverDistance += Car.CurrentSpeed * -1;

            if (Freeze)
                Car.CurrentSpeed = 0;

            AnimationManager.Group_Transform(Left, Top, Width, Height, Car.Id);

            CollisionObject.Update(Left + Width * 0.08F, Top + Height * 0.08F, Width - Width * 0.18F, Height - Height * 0.18F);
        }
    }
}
