namespace Nie.Math{
    /// <summary>
    /// Represent an angle in radian unit.
    /// </summary>
    public struct AngleRadian
    {
        #region Constant
        public static AngleRadian degree0 { get { return new AngleRadian(Scalar.one); } }
        public static AngleRadian degree45 { get { return new AngleRadian(Scalar.piQuater); } }
        public static AngleRadian degree90 { get { return new AngleRadian(Scalar.piHalf); } }
        public static AngleRadian degree180 { get { return new AngleRadian(Scalar.pi); } }
        public static AngleRadian degree360 { get { return new AngleRadian(Scalar.tau); } }
        #endregion

        #region Conversion
        public static implicit operator float(AngleRadian a){ return a.mValue; }
        #endregion

        #region Constructor
        public AngleRadian(float a) { mValue = a; }
        #endregion


        public float value { get { return mValue; } }
        public AngleRadian normalized
        {
            get
            {
                float r = mValue % Scalar.tau;
                if (r < 0) r += Scalar.tau;
                return new AngleRadian(r);
            }
        }
        public AngleRadian abs
        {
            get
            {
                return new AngleRadian(Op.Abs(mValue % Scalar.tau));
            }
        }


        #region Operator
        public static bool operator < (AngleRadian a, AngleRadian b) { return a.mValue <  b.mValue; }
        public static bool operator > (AngleRadian a, AngleRadian b) { return a.mValue >  b.mValue; }
        public static bool operator <=(AngleRadian a, AngleRadian b) { return a.mValue <= b.mValue; }
        public static bool operator >=(AngleRadian a, AngleRadian b) { return a.mValue >= b.mValue; }
        public static bool operator !=(AngleRadian a, AngleRadian b) { return a.mValue != b.mValue; }
        public static bool operator ==(AngleRadian a, AngleRadian b) { return a.mValue == b.mValue; }

        public static AngleRadian operator +(AngleRadian a, AngleRadian b) { return new AngleRadian(a.mValue + b.mValue); }
        public static AngleRadian operator -(AngleRadian a, AngleRadian b) { return new AngleRadian(a.mValue - b.mValue); }
        public static AngleRadian operator *(AngleRadian a, AngleRadian b) { return new AngleRadian(a.mValue * b.mValue); }
        public static AngleRadian operator /(AngleRadian a, AngleRadian b) { return new AngleRadian(a.mValue / b.mValue); }
        #endregion


        #region Object
        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;
            return this == (AngleRadian)other;
        }
        public override int GetHashCode() { return mValue.GetHashCode(); }
        #endregion


        #region Private Field
        float mValue;
        #endregion

    }
}