#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_DASHBOARD_WIDGET || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY || UNITY_WP8 || UNITY_METRO || UNITY_WINRT
#   define NIEMATH_UNITY
#endif

namespace Nie.Math
{
    public struct Vector4D : IVector4D<float>, IConstVector4D<float>
    {
#if NIEMATH_UNITY
        private UnityEngine.Vector4 mBase;

        public static implicit operator UnityEngine.Vector4(Vector4D a){ return a.mBase; }
		public static implicit operator Vector4D(UnityEngine.Vector4 a){ Vector4D v; v.mBase = a; return v; }

        public float x { get { return mBase.x; } set { mBase.x = value; } }
        public float y { get { return mBase.y; } set { mBase.y = value; } }
        public float z { get { return mBase.z; } set { mBase.z = value; } }
        public float w { get { return mBase.w; } set { mBase.w = value; } }
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }

        public Vector4DN normalized { get { return (Vector4DN)(Vector4D)mBase.normalized; } }
        public float length { get { return mBase.magnitude; } set { mBase = mBase * (value / mBase.magnitude); } }
        public float sqrLength { get { return mBase.sqrMagnitude; } }

        private float mX { get { return mBase.x; } set { mBase.x = value; } }
        private float mY { get { return mBase.y; } set { mBase.y = value; } }
        private float mZ { get { return mBase.z; } set { mBase.z = value; } }
        private float mW { get { return mBase.w; } set { mBase.w = value; } }
        
#else
        float mX;
        float mY;
        float mZ;
        float mW;

        public float x { get { return mX; } set { mX = value; } }
        public float y { get { return mY; } set { mY = value; } }
        public float z { get { return mZ; } set { mZ = value; } }
        public float w { get { return mW; } set { mW = value; } }

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Vector4D o = (Vector4D)other;
            return (this == o).allTrue;
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode() ^ mZ.GetHashCode() ^ mW.GetHashCode(); }

        public Vector4DN normalized { get { return new Vector4DN(this / length); } }
        public float length { get { return Op.Sqrt(sqrLength); } set { float r = value / Op.Sqrt(sqrLength); this *= r; } }
        public float sqrLength { get { return Dot(this); } }
#endif

        #region Constructor
        public Vector4D(float x, float y, float z, float w)
        {
#if NIEMATH_UNITY
            mBase = new UnityEngine.Vector4(x,y,z,w);
#else
            mX = x;
            mY = y;
            mZ = z;
            mW = w;
#endif
        }
        public Vector4D(Vector2D aXY, Vector2D aZW)
        {
#if NIEMATH_UNITY
            mBase = new UnityEngine.Vector4(aXY.x, aXY.y, aZW.x, aZW.y);
#else
            mX = aXY.x;
            mY = aXY.y;
            mZ = aZW.x;
            mW = aZW.y;
#endif
        }
        public Vector4D(Vector3D aXYZ, float w)
        {
#if NIEMATH_UNITY
            mBase = new UnityEngine.Vector4(aXYZ.x, aXYZ.y, aXYZ.z, w);
#else
            mX = aXYZ.x;
            mY = aXYZ.y;
            mZ = aXYZ.z;
            mW = w;
#endif
        }
        #endregion

        public Vector2D xy { get { return new Vector2D(mX, mY); } set { mX = value.x; mY = value.y; } }
        public Vector2D xz { get { return new Vector2D(mX, mZ); } set { mX = value.x; mZ = value.y; } }
        public Vector2D xw { get { return new Vector2D(mX, mW); } set { mX = value.x; mW = value.y; } }
        public Vector2D yz { get { return new Vector2D(mY, mZ); } set { mY = value.x; mZ = value.y; } }
        public Vector2D yw { get { return new Vector2D(mY, mW); } set { mY = value.x; mW = value.y; } }
        public Vector2D zw { get { return new Vector2D(mZ, mW); } set { mZ = value.x; mW = value.y; } }

        public Vector2D xx { get { return new Vector2D(mX, mX); } }
        public Vector2D yy { get { return new Vector2D(mY, mY); } }
        public Vector2D zz { get { return new Vector2D(mZ, mZ); } }
        public Vector2D ww { get { return new Vector2D(mW, mW); } }

        public Vector3D xyz { get { return new Vector3D(mX, mY, mZ); } set { mX = value.x; mY = value.y; mZ = value.z; } }
        public Vector3D yzw { get { return new Vector3D(mY, mZ, mW); } set { mY = value.x; mZ = value.y; mW = value.z; } }

        public Vector3D xxx { get { return new Vector3D(mX, mX, mX); } }
        public Vector3D yyy { get { return new Vector3D(mY, mY, mY); } }
        public Vector3D zzz { get { return new Vector3D(mZ, mZ, mZ); } }
        public Vector3D www { get { return new Vector3D(mW, mW, mW); } }

        public Vector4D xxxx { get { return new Vector4D(mX, mX, mX, mX); } }
        public Vector4D yyyy { get { return new Vector4D(mY, mY, mY, mY); } }
        public Vector4D zzzz { get { return new Vector4D(mZ, mZ, mZ, mZ); } }
        public Vector4D wwww { get { return new Vector4D(mW, mW, mW, mW); } }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ", " + w + ")";
        }
        public bool IsNormal() { return Op.IsZeroNear(sqrLength - 1); }


        public float Dot(Vector4D a)
        {
#if NIEMATH_UNITY
            return UnityEngine.Vector4.Dot(mBase, a.mBase); 
#else
            return mX * a.mX + mY * a.mY + mZ * a.mZ + mW * a.mW;
#endif
        }



        #region Operator
        public static Bool4 operator < (Vector4D a, Vector4D b) { return new Bool4(a.x <  b.x, a.y <  b.y, a.z <  b.z, a.w <  b.w); }
        public static Bool4 operator > (Vector4D a, Vector4D b) { return new Bool4(a.x >  b.x, a.y >  b.y, a.z >  b.z, a.w >  b.w); }
        public static Bool4 operator <=(Vector4D a, Vector4D b) { return new Bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
        public static Bool4 operator >=(Vector4D a, Vector4D b) { return new Bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        public static Bool4 operator !=(Vector4D a, Vector4D b) { return new Bool4(a.x != b.x, a.y != b.y, a.z != b.z, a.w != b.w); }
        public static Bool4 operator ==(Vector4D a, Vector4D b) { return new Bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }

        public static Vector4D operator +(Vector4D a, Vector4D b) { return new Vector4D(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        public static Vector4D operator -(Vector4D a, Vector4D b) { return new Vector4D(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        public static Vector4D operator *(Vector4D a, Vector4D b) { return new Vector4D(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        public static Vector4D operator /(Vector4D a, Vector4D b) { return new Vector4D(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        public static Vector4D operator *(Vector4D a, float b) { return new Vector4D(a.x * b, a.y * b, a.z * b, a.w * b); }
        public static Vector4D operator /(Vector4D a, float b) { return new Vector4D(a.x / b, a.y / b, a.z / b, a.w / b); }
        public static Vector4D operator *(float a, Vector4D b) { return new Vector4D(a * b.x, a * b.y, a * b.z, a * b.w); }
        public static Vector4D operator /(float a, Vector4D b) { return new Vector4D(a / b.x, a / b.y, a / b.z, a / b.w); }

        public static Vector4D operator -(Vector4D a) { return new Vector4D(-a.x, -a.y, -a.z, -a.w); }

        public Vector4D Min(Vector4D a) { return (this < a).Select(this, a); }
        public Vector4D Max(Vector4D a) { return (this < a).Select(this, a); }
        public float Min() { return Op.Min(xy.Min(), zw.Min()); }
        public float Max() { return Op.Max(xy.Max(), zw.Max()); }
        public Vector4D Clamp(Vector4D aMin, Vector4D aMax) { return new Vector4D(Op.Clamp(x, aMin.x, aMax.x), Op.Clamp(y, aMin.y, aMax.y), Op.Clamp(z, aMin.z, aMax.z), Op.Clamp(w, aMin.w, aMax.w)); }
        public Vector4D Clamp01() { return new Vector4D(Op.Clamp01(x), Op.Clamp01(y), Op.Clamp01(z), Op.Clamp01(w)); }
        #endregion


    }
}