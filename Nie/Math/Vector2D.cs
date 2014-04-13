#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_DASHBOARD_WIDGET || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY || UNITY_WP8 || UNITY_METRO || UNITY_WINRT
#   define NIEMATH_UNITY
#endif

namespace Nie.Math
{
    public struct Vector2D : IVector2D<float>, IConstVector2D<float>
    {
#if NIEMATH_UNITY
        public UnityEngine.Vector2 mBase;
        public float x { get { return mBase.x; } set { mBase.x = value; } }
        public float y { get { return mBase.y; } set { mBase.y = value; } }
        public Vector2D(float x, float y)
        {
            mBase = new UnityEngine.Vector2(x, y);
        }
        public Vector2D(UnityEngine.Vector2 a)
        {
            mBase = a;
        }
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }

        public Vector2DN normalized { get { return (Vector2DN)( new Vector2D(mBase.normalized) ); } }
        public float length { get { return mBase.magnitude; } set { mBase = mBase * (value / mBase.magnitude); } }
        public float sqrLength { get { return mBase.sqrMagnitude; } }

        public float Dot(Vector2D aOther) { return UnityEngine.Vector2.Dot(mBase, aOther.mBase); }
#else
        float mX;
        float mY;
        public float x { get { return mX; } set { mX = value; } }
        public float y { get { return mY; } set { mY = value; } }
        public Vector2D(float x, float y)
        {
            mX = x;
            mY = y;
        }


        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Vector2D o = (Vector2D)other;
            return (mX == o.mX) && (mY == o.mY);
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode(); }

        public Vector2DN normalized { get { return (Vector2DN)(this / length); } }
        public float length { get { return Op.Sqrt(sqrLength); } set { float r = value / Op.Sqrt(sqrLength); mX *= r; mY *= r; } }
        public float sqrLength { get { return Dot(this); } }
        public float Dot(Vector2D o) { return mX * o.mX + mY * o.mY; }
#endif


        public Vector2D xx { get { return new Vector2D(x, x); } }
        public Vector2D yy { get { return new Vector2D(y, y); } }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
        public bool IsNormal() { return Op.IsZeroNear(sqrLength - 1); }

        public float Cross(Vector2D a) { return (x * a.y) - (y * a.x); }

        
        #region Operator
        public static Bool2 operator < (Vector2D a, Vector2D b) { return new Bool2(a.x <  b.x, a.y <  b.y); }
        public static Bool2 operator > (Vector2D a, Vector2D b) { return new Bool2(a.x >  b.x, a.y >  b.y); }
        public static Bool2 operator <=(Vector2D a, Vector2D b) { return new Bool2(a.x <= b.x, a.y <= b.y); }
        public static Bool2 operator >=(Vector2D a, Vector2D b) { return new Bool2(a.x >= b.x, a.y >= b.y); }
        public static Bool2 operator !=(Vector2D a, Vector2D b) { return new Bool2(a.x != b.x, a.y != b.y); }
        public static Bool2 operator ==(Vector2D a, Vector2D b) { return new Bool2(a.x == b.x, a.y == b.y); }

        public static Vector2D operator +(Vector2D a, Vector2D b) { return new Vector2D(a.x + b.x, a.y + b.y); }
        public static Vector2D operator -(Vector2D a, Vector2D b) { return new Vector2D(a.x - b.x, a.y - b.y); }
        public static Vector2D operator *(Vector2D a, Vector2D b) { return new Vector2D(a.x * b.x, a.y * b.y); }
        public static Vector2D operator /(Vector2D a, Vector2D b) { return new Vector2D(a.x / b.x, a.y / b.y); }
        public static Vector2D operator *(Vector2D a, float b) { return new Vector2D(a.x * b, a.y * b); }
        public static Vector2D operator /(Vector2D a, float b) { return new Vector2D(a.x / b, a.y / b); }
        public static Vector2D operator *(float a, Vector2D b) { return new Vector2D(a * b.x, a * b.y); }
        public static Vector2D operator /(float a, Vector2D b) { return new Vector2D(a / b.x, a / b.y); }

        public static Vector2D operator -(Vector2D a) { return new Vector2D(-a.x, -a.y); }

        public Vector2D Min(Vector2D a){ return (this < a).Select(this, a); }
        public Vector2D Max(Vector2D a) { return (this < a).Select(this, a); }
        public float Min() { return x < y ? x : y; }
        public float Max() { return x < y ? x : y; }
        public Vector2D Clamp(Vector2D aMin, Vector2D aMax) { return new Vector2D(Op.Clamp(x, aMin.x, aMax.x), Op.Clamp(y, aMin.y, aMax.y)); }
        public Vector2D Clamp01() { return new Vector2D(Op.Clamp01(x), Op.Clamp01(y)); }

        #endregion

        #region Angle
        public Vector2D perpendicularCW { get { return new Vector2D(y, -x); } }
        public Vector2D perpendicularCCW { get { return new Vector2D(-y, x); } }
        public bool IsClockwise(Vector2D aTo) { return Cross(aTo) > 0; }
        public bool IsCounterclockwise(Vector2D aTo) { return Cross(aTo) < 0; }
        public SignCircularDirection CircularDirection(Vector2D aTo) { return new SignCircularDirection(Cross(aTo)); }
        public bool IsWithin90DegreeOf(Vector2D a) { return Dot(a) >= 0; }
        public bool IsPerpendicular(Vector2D a) { return Dot(a) == 0; }
        public bool IsPerpendicularNear(Vector2D a) { return Op.IsZeroNear(Dot(a)); }
        public bool IsParallel(Vector2D aTo) { return Cross(aTo) == 0; }
        public bool IsParallelNear(Vector2D aTo) { return Op.IsZeroNear(Cross(aTo)); }
        public AngleCos AngleBetween(Vector2D a)
        {
            return new AngleCos(normalized.Dot(a.normalized));
        }
        public AngleCos AngleBetween(Vector2DN a)
        {
            return new AngleCos(normalized.Dot(a));
        }
        #endregion
    }
}