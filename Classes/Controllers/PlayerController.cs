using System;

namespace Gonki_by_Dadadam
{
    public class PlayerController : CarController
    {
        public delegate void StateMachine(string state);
        public event StateMachine State;

        private float _widthScreen { get; set; }
        private float _heightScreen { get; set; }

        public PlayerController(int WidthScreen, int HeightScreen)
        {
            _widthScreen = WidthScreen;
            _heightScreen = HeightScreen;

            CollisionObject = new Collision("Player_Car", Left, Top, Width, Height);
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
            Top = _heightScreen / 3;
            Width = _widthScreen / 7;
            Height = _heightScreen / 9;
            AnimationManager.Group_Transform(Left, Top, Width, Height, Car.Id);
        }

        public void Key_Event(string pressedKey)
        {
            if (String.IsNullOrEmpty(pressedKey))
                State?.Invoke("");

            if (Car.CurrentSpeed == 0)
                State?.Invoke("Stop");
            else
                State?.Invoke("Move");

            if ((pressedKey == "W") && (Car.CurrentSpeed <= Car.MaxSpeed))
            {
                Car.CurrentSpeed += Car.StepSpeed;
            }

            if ((pressedKey == "S") && (Car.CurrentSpeed >= Car.BackSpeed * -1))
            {
                Car.CurrentSpeed -= Car.StepSpeed;
                State?.Invoke("Back");
            }

            if ((pressedKey == "A") && (Car.CurrentSpeed != 0))
            {
                Top -= Car.RotateLeftSpeed;
                State?.Invoke("Left");
            }

            if ((pressedKey == "D") && (Car.CurrentSpeed != 0))
            {
                Top += Car.RotateRightSpeed;
                State?.Invoke("Right");
            }

            if ((pressedKey != "ShiftKey") && (Car.CurentBoostCharge <= Car.MaxBoostCharge))
                Car.CurentBoostCharge++;

            if ((pressedKey == "ShiftKey") && (Car.CurentBoostCharge > 0) && (Car.CurrentSpeed > 0))
            {
                Car.CurentBoostCharge--;
                if (Car.CurrentSpeed < Car.MaxSpeed + Car.BoostSpeed)
                    Car.CurrentSpeed += Car.BoostSpeed;

                if (Car.CurentBoostCharge <= 0)
                    Car.CurrentSpeed = Car.MaxSpeed;

                State?.Invoke("Boost");
            }
            if (pressedKey != "ShiftKey" && Car.CurrentSpeed >= Car.MaxSpeed)
                Car.CurrentSpeed = Car.MaxSpeed;
        }

        public void Update()
        {
            Car.CoverDistance += Car.CurrentSpeed;

            if (Car.CurrentSpeed != 0 &&
                Car.CurrentSpeed > Car.BackSpeed * -1 &&
                Car.CurrentSpeed < Car.MaxSpeed)
                Left = _widthScreen / 3 + Car.CurrentSpeed; // Width / 3 - стартовая позиция

            if (Freeze)
                Car.CurrentSpeed = 0;

            AnimationManager.Group_Transform(Left, Top, Width, Height, Car.Id);

            CollisionObject.Update(Left + Width * 0.08F, Top + Height * 0.08F, Width - Width * 0.18F, Height - Height * 0.18F);
        }
    }
}