namespace Nie.Math
{

    /// <summary>
    /// Represent an angle from its Cos value. Can only represent values within [0,180] degree.
    /// Cannot be added/subtracted with other angle.
    /// </summary>
    public struct AngleCos
    {
        #region constant
        public static AngleCos degree0   =  new AngleCos(Scalar.one);
        public static AngleCos degree30  =  new AngleCos(Scalar.cos30);
        public static AngleCos degree45  =  new AngleCos(Scalar.cos45);
        public static AngleCos degree60  =  new AngleCos(Scalar.half);
        public static AngleCos degree90  =  new AngleCos(Scalar.zero);
        public static AngleCos degree120 =  new AngleCos(Scalar.minusHalf);
        public static AngleCos degree135 =  new AngleCos(-Scalar.cos45);
        public static AngleCos degree150 =  new AngleCos(-Scalar.cos30);
        public static AngleCos degree180 =  new AngleCos(Scalar.minusOne);
        #endregion

        #region constructor
        public AngleCos(float a) { mCosA = a; }
        #endregion

        public float value { get{return mCosA;} }
        public AngleRadian radian { get { return new AngleRadian(Op.ACos(mCosA)); } }
        public AngleDegree degree { get { return new AngleDegree(Op.ACos(mCosA) * Scalar.rad2deg); } }
        #region operator
        public static bool operator < (AngleCos a, AngleCos b) { return a.mCosA >  b.mCosA; }
        public static bool operator > (AngleCos a, AngleCos b) { return a.mCosA <  b.mCosA; }
        public static bool operator <=(AngleCos a, AngleCos b) { return a.mCosA >= b.mCosA; }
        public static bool operator >=(AngleCos a, AngleCos b) { return a.mCosA <= b.mCosA; }
        public static bool operator !=(AngleCos a, AngleCos b) { return a.mCosA != b.mCosA; }
        public static bool operator ==(AngleCos a, AngleCos b) { return a.mCosA == b.mCosA; }
        #endregion


        #region Object
        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;
            return this == (AngleCos)other;
        }
        public override int GetHashCode() { return mCosA.GetHashCode(); }
        #endregion


        #region private field
        float mCosA;
        #endregion

    }
}