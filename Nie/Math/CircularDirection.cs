namespace Nie.Math{

    /// <summary>
    /// Represent the direction of rotation in an Cartesian coordinate system
    /// </summary>
    public enum EnumCircularDirection
    {
        Counterclockwise = -1,
        Undefined = 0,
        Clockwise = 1,
    }
    public struct SignCircularDirection{
        public SignCircularDirection(float a){ mValue = a;}

        public bool isClockwise { get{ return mValue > 0;} }
        public bool isCounterclockwise { get{ return mValue < 0;} }
        public bool isUndefined { get{ return mValue == 0;} }

        public EnumCircularDirection enumCD { get { return (EnumCircularDirection)Op.Sign(mValue); } }
        private float mValue;
    }

}