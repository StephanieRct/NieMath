namespace Nie.Math{


    public struct Bool2 : IVector2D<bool>
    {

        #region Constructor
        public Bool2(bool a, bool b){ mX = a; mY = b; }
        #endregion

        public bool x { get{ return mX; } set{ mX = value;} }
        public bool y { get{ return mY; } set{ mY = value;} }

        public bool allTrue{ get{ return mX && mY; } }
        public bool allFalse{ get{ return !mX && !mY; } }
        public bool anyTrue{ get{ return mX || mY; } }
        public bool anyFalse{ get{ return !mX || !mY; } }

        #region Operator
        public static Bool2 operator !(Bool2 a) { return new Bool2(!a.mX , !a.mY ); }

        public static Bool2 operator !=(Bool2 a, Bool2 b) { return new Bool2(a.mX != b.mX, a.mY != b.mY); }
        public static Bool2 operator ==(Bool2 a, Bool2 b) { return new Bool2(a.mX == b.mX, a.mY == b.mY); }

        public static Bool2 operator |(Bool2 a, Bool2 b) { return new Bool2(a.mX || b.mX, a.mY || b.mY); }
        public static Bool2 operator &(Bool2 a, Bool2 b) { return new Bool2(a.mX && b.mX, a.mY && b.mY); }
        public static Bool2 operator ^(Bool2 a, Bool2 b) { return new Bool2(a.mX ^ b.mX, a.mY ^ b.mY); }
        #endregion

        public Vector2D Select(Vector2D aTrue, Vector2D aFalse) {
            return new Vector2D(mX ? aTrue.x : aFalse.x, mY ? aTrue.y : aFalse.y);
        }

        #region Object

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Bool2 o = (Bool2)other;
            return (mX == o.mX) && (mY == o.mY);
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode(); }
        public override string ToString()
        {
            return "(" + mX + ", " + mY + ")";
        }
        #endregion

        private bool mX;
        private bool mY;
    }
}