namespace Gonki_by_Dadadam
{
    public class Car
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float MaxSpeed { get; set; }
        public float CurrentSpeed { get; set; }
        public float StepSpeed { get; set; }
        public float BackSpeed { get; set; }
        public float BoostSpeed { get; set; }
        public float MaxBoostCharge { get; set; }
        public float CurentBoostCharge { get; set; }
        public float RotateRightSpeed { get; set; }
        public float RotateLeftSpeed { get; set; }
        public float CoverDistance { get; set; }
        public AnimationSprite AnimationDefault { get; set; }
        public AnimationSprite AnimationBack { get; set; }
        public AnimationSprite AnimationStop { get; set; }
        public AnimationSprite AnimationRotateRight { get; set; }
        public AnimationSprite AnimationRotateLeft { get; set; }
        public AnimationSprite AnimationBreaking { get; set; }

        private Car _car;

        public Car()
        {
            CurrentSpeed = 0;
            CoverDistance = 0;
            CurentBoostCharge = 0;
        }

        public Car Clone()
        {
            _car = new Car
            {
                Id = Id,
                Name = Name,
                MaxSpeed = MaxSpeed,
                CurrentSpeed = CurrentSpeed,
                StepSpeed = StepSpeed,
                BackSpeed = BackSpeed,
                BoostSpeed = BoostSpeed,
                MaxBoostCharge = MaxBoostCharge,
                CurentBoostCharge = CurentBoostCharge,
                RotateRightSpeed = RotateRightSpeed,
                RotateLeftSpeed = RotateLeftSpeed,
                CoverDistance = CoverDistance,
                AnimationDefault = AnimationDefault.Clone(),
                AnimationBack = AnimationBack.Clone(),
                AnimationRotateRight = AnimationRotateRight.Clone(),
                AnimationRotateLeft = AnimationRotateLeft.Clone(),
                AnimationBreaking = AnimationBreaking.Clone(),
                AnimationStop = AnimationStop.Clone()
            };
            return _car;
        }

        public void Reset()
        {
            CurrentSpeed = 0;
            CoverDistance = 0;
            CurentBoostCharge = 0;
        }
    }
}
