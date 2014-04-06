namespace Nie.Math
{


    public struct Bool3 : IVector3D<bool>
    {

        #region Constructor
        public Bool3(bool a, bool b, bool c) { mX = a; mY = b; mZ = c;}
        #endregion

        public bool x { get { return mX; } set { mX = value; } }
        public bool y { get { return mY; } set { mY = value; } }
        public bool z { get { return mZ; } set { mZ = value; } }

        public bool allTrue { get { return mX && mY && mZ; } }
        public bool allFalse { get { return !mX && !mY && !mZ; } }
        public bool anyTrue { get { return mX || mY || mZ; } }
        public bool anyFalse { get { return !mX || !mY || !mZ; } }

        #region Operator
        public static Bool3 operator !(Bool3 a) { return new Bool3(!a.mX, !a.mY, !a.mZ); }

        public static Bool3 operator !=(Bool3 a, Bool3 b) { return new Bool3(a.mX != b.mX, a.mY != b.mY, a.mZ != b.mZ); }
        public static Bool3 operator ==(Bool3 a, Bool3 b) { return new Bool3(a.mX == b.mX, a.mY == b.mY, a.mZ == b.mZ); }
        public static Bool3 operator | (Bool3 a, Bool3 b) { return new Bool3(a.mX || b.mX, a.mY || b.mY, a.mZ || b.mZ); }
        public static Bool3 operator & (Bool3 a, Bool3 b) { return new Bool3(a.mX && b.mX, a.mY && b.mY, a.mZ && b.mZ); }
        public static Bool3 operator ^ (Bool3 a, Bool3 b) { return new Bool3(a.mX ^  b.mX, a.mY ^  b.mY, a.mZ ^  b.mZ); }
        #endregion

        public Vector3D Select(Vector3D aTrue, Vector3D aFalse)
        {
            return new Vector3D(mX ? aTrue.x : aFalse.x, mY ? aTrue.y : aFalse.y, mZ ? aTrue.z : aFalse.z);
        }

        #region Object

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Bool3 o = (Bool3)other;
            return (this == o).allTrue;
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode() ^ mZ.GetHashCode(); }
        public override string ToString()
        {
            return "(" + mX + ", " + mY + ", " + mZ + ")";
        }
        #endregion

        private bool mX;
        private bool mY;
        private bool mZ;
    }
}