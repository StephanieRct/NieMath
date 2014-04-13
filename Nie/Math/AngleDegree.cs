namespace Nie.Math{
    /// <summary>
    /// Represent an angle in degree unit.
    /// </summary>
    public struct AngleDegree
    {
        #region Constant
        public static AngleDegree degree0   = new AngleDegree(0);
        public static AngleDegree degree45  = new AngleDegree(45);
        public static AngleDegree degree90  = new AngleDegree(90);
        public static AngleDegree degree180 = new AngleDegree(180);
        public static AngleDegree degree360 = new AngleDegree(360);
        #endregion

        #region Conversion
        public static implicit operator float(AngleDegree a){ return a.mValue; }
        #endregion

        #region Constructor
        public AngleDegree(float a) { mValue = a; }
        #endregion


        public float value { get { return mValue; } }
        public AngleCos cos { get { return new AngleCos(Op.Cos(mValue * Scalar.deg2rad)); } }
        public AngleRadian radian { get { return new AngleRadian(mValue * Scalar.deg2rad); } }
        public AngleDegree normalized
        {
            get
            {
                float r = mValue % 360;
                if (r < 0) r += 360;
                return new AngleDegree(r);
            }
        }
        public AngleDegree abs
        {
            get
            {
                return new AngleDegree(Op.Abs(mValue % 360));
            }
        }


        #region Operator
        public static bool operator < (AngleDegree a, AngleDegree b) { return a.mValue <  b.mValue; }
        public static bool operator > (AngleDegree a, AngleDegree b) { return a.mValue >  b.mValue; }
        public static bool operator <=(AngleDegree a, AngleDegree b) { return a.mValue <= b.mValue; }
        public static bool operator >=(AngleDegree a, AngleDegree b) { return a.mValue >= b.mValue; }
        public static bool operator !=(AngleDegree a, AngleDegree b) { return a.mValue != b.mValue; }
        public static bool operator ==(AngleDegree a, AngleDegree b) { return a.mValue == b.mValue; }

        public static AngleDegree operator +(AngleDegree a, AngleDegree b) { return new AngleDegree(a.mValue + b.mValue); }
        public static AngleDegree operator -(AngleDegree a, AngleDegree b) { return new AngleDegree(a.mValue - b.mValue); }
        public static AngleDegree operator *(AngleDegree a, AngleDegree b) { return new AngleDegree(a.mValue * b.mValue); }
        public static AngleDegree operator /(AngleDegree a, AngleDegree b) { return new AngleDegree(a.mValue / b.mValue); }
        #endregion


        #region Object
        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;
            return this == (AngleDegree)other;
        }
        public override int GetHashCode() { return mValue.GetHashCode(); }
        #endregion


        #region Private Field
        float mValue;
        #endregion

    }
}