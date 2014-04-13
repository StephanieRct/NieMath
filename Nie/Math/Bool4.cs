namespace Nie.Math
{


    public struct Bool4 : IVector4D<bool>, IConstVector4D<bool>
    {

        #region Constructor
        public Bool4(bool a, bool b, bool c, bool d) { mX = a; mY = b; mZ = c; mW = d; }
        #endregion

        public bool x { get { return mX; } set { mX = value; } }
        public bool y { get { return mY; } set { mY = value; } }
        public bool z { get { return mZ; } set { mZ = value; } }
        public bool w { get { return mW; } set { mW = value; } }

        public bool allTrue  { get { return mX && mY && mZ && mW; } }
        public bool allFalse { get { return !mX && !mY && !mZ && !mW; } }
        public bool anyTrue  { get { return mX || mY || mZ || mW; } }
        public bool anyFalse { get { return !mX || !mY || !mZ || !mW; } }

        #region Operator
        public static Bool4 operator !(Bool4 a) { return new Bool4(!a.mX, !a.mY, !a.mZ, !a.mW); }

        public static Bool4 operator !=(Bool4 a, Bool4 b) { return new Bool4(a.mX != b.mX, a.mY != b.mY, a.mZ != b.mZ, a.mW != b.mW); }
        public static Bool4 operator ==(Bool4 a, Bool4 b) { return new Bool4(a.mX == b.mX, a.mY == b.mY, a.mZ == b.mZ, a.mW == b.mW); }
        public static Bool4 operator | (Bool4 a, Bool4 b) { return new Bool4(a.mX || b.mX, a.mY || b.mY, a.mZ || b.mZ, a.mW || b.mW); }
        public static Bool4 operator & (Bool4 a, Bool4 b) { return new Bool4(a.mX && b.mX, a.mY && b.mY, a.mZ && b.mZ, a.mW && b.mW); }
        public static Bool4 operator ^ (Bool4 a, Bool4 b) { return new Bool4(a.mX ^  b.mX, a.mY ^  b.mY, a.mZ ^  b.mZ, a.mW ^  b.mW); }
        #endregion

        public Vector4D Select(Vector4D aTrue, Vector4D aFalse)
        {
            return new Vector4D(mX ? aTrue.x : aFalse.x, mY ? aTrue.y : aFalse.y, mZ ? aTrue.z : aFalse.z, mW ? aTrue.w : aFalse.w);
        }
        public T Select<T, UT>(T aTrue, IConstVector4D<UT> aFalse) where T : IVector4D<UT>, new()
        {
            T r = new T();
            r.x = mX ? aTrue.x : aFalse.x;
            r.y = mY ? aTrue.y : aFalse.y;
            r.z = mZ ? aTrue.z : aFalse.z;
            r.w = mW ? aTrue.w : aFalse.w;
            return r;
        }
        public void Select<T>(ref IVector4D<T> aOut, IConstVector4D<T> aTrue, IConstVector4D<T> aFalse)
        {
            aOut.x = mX ? aTrue.x : aFalse.x;
            aOut.y = mY ? aTrue.y : aFalse.y;
            aOut.z = mZ ? aTrue.z : aFalse.z;
            aOut.w = mW ? aTrue.w : aFalse.w;
        }

        #region Object

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Bool4 o = (Bool4)other;
            return (this == o).allTrue;
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode() ^ mZ.GetHashCode() ^ mW.GetHashCode(); }
        public override string ToString()
        {
            return "(" + mX + ", " + mY + ", " + mZ + ", " + mW + ")";
        }
        #endregion

        private bool mX;
        private bool mY;
        private bool mZ;
        private bool mW;
    }
}