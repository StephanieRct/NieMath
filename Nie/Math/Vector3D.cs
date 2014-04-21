#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_DASHBOARD_WIDGET || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY || UNITY_WP8 || UNITY_METRO || UNITY_WINRT
#   define NIEMATH_UNITY
#endif

namespace Nie.Math
{
    public struct Vector3D : IVector3D<float>, IConstVector3D<float>
    {
#if NIEMATH_UNITY
        private UnityEngine.Vector3 mBase;

        public static implicit operator UnityEngine.Vector3(Vector3D a){ return a.mBase; }
		public static implicit operator Vector3D(UnityEngine.Vector3 a){ Vector3D v; v.mBase = a; return v; }

        public float x { get { return mBase.x; } set { mBase.x = value; } }
        public float y { get { return mBase.y; } set { mBase.y = value; } }
        public float z { get { return mBase.z; } set { mBase.z = value; } }
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }

        public Vector3DN normalized { get { return (Vector3DN)(Vector3D)mBase.normalized; } }
        public float length { get { return mBase.magnitude; } set { mBase = mBase * (value / mBase.magnitude); } }
        public float sqrLength { get { return mBase.sqrMagnitude; } }

        private float mX { get { return mBase.x; } set { mBase.x = value; } }
        private float mY { get { return mBase.y; } set { mBase.y = value; } }
        private float mZ { get { return mBase.z; } set { mBase.z = value; } }
        
#else
        float mX;
        float mY;
        float mZ;

        public float x { get { return mX; } set { mX = value; } }
        public float y { get { return mY; } set { mY = value; } }
        public float z { get { return mZ; } set { mZ = value; } }

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            Vector3D o = (Vector3D)other;
            return (this == o).allTrue;
        }

        public override int GetHashCode() { return mX.GetHashCode() ^ mY.GetHashCode() ^ mZ.GetHashCode(); }

        public Vector3DN normalized { get { return new Vector3DN(this / length); } }
        public float length { get { return Op.Sqrt(sqrLength); } set { float r = value / Op.Sqrt(sqrLength); this *= r; } }
        public float sqrLength { get { return Dot(this); } }
#endif
        
        #region Constructor
        public Vector3D(float x, float y, float z)
        {
#if NIEMATH_UNITY
            mBase = new UnityEngine.Vector3(x,y,z);
#else
            mX = x;
            mY = y;
            mZ = z;
#endif
        }
        public Vector3D(Vector2D aXY, float z)
        {
#if NIEMATH_UNITY
            mBase = new UnityEngine.Vector3(aXY.x, aXY.y, z);
#else
            mX = aXY.x;
            mY = aXY.y;
            mZ = z;
#endif
        }
        #endregion

        public Vector2D xy { get { return new Vector2D(mX, mY); } set { mX = value.x; mY = value.y; } }
        public Vector2D yz { get { return new Vector2D(mY, mZ); } set { mY = value.x; mZ = value.y; } }
        public Vector2D xz { get { return new Vector2D(mX, mZ); } set { mX = value.x; mZ = value.y; } }

        public Vector2D xx { get { return new Vector2D(mX, mX); } }
        public Vector2D yy { get { return new Vector2D(mY, mY); } }
        public Vector2D zz { get { return new Vector2D(mZ, mZ); } }
        public Vector3D xxx { get { return new Vector3D(mX, mX, mX); } }
        public Vector3D yyy { get { return new Vector3D(mY, mY, mY); } }
        public Vector3D zzz { get { return new Vector3D(mZ, mZ, mZ); } }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
        public bool IsNormal() { return Op.IsZeroNear(sqrLength - 1); }


        public float Dot(Vector3D a) {
#if NIEMATH_UNITY
            return UnityEngine.Vector3.Dot(mBase, a.mBase); 
#else
            return mX * a.mX + mY * a.mY + mZ * a.mZ;
#endif
            }

        /// <summary>
        /// Perform a Right-Handed Cross Product. Note that Unity3D Vector3.Cross performs a Left-Handed Cross Product.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>A vector3D perpendicular to both a and this vector</returns>
        public Vector3D Cross(Vector3D a) { 
#if NIEMATH_UNITY
            return (Vector3D)(UnityEngine.Vector3.Cross(a.mBase, mBase));
#else
            return new Vector3D(y * a.z - z * a.y, z * a.x - x * a.z, x * a.y - y * a.x); 
#endif
        }

        /// <summary>
        /// Perform a Triple Product. http://en.wikipedia.org/wiki/Triple_product 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Signed volume of the parallelepiped defined by the 3 vectors (this, b, c). Positive if vector order is Right-Handed, negative if Left-Handed</returns>
        public float Triple(Vector3D b, Vector3D c) { return Dot( b.Cross(c) ); }


        #region Operator
        public static Bool3 operator < (Vector3D a, Vector3D b) { return new Bool3(a.x <  b.x, a.y <  b.y, a.z <  b.z); }
        public static Bool3 operator > (Vector3D a, Vector3D b) { return new Bool3(a.x >  b.x, a.y >  b.y, a.z >  b.z); }
        public static Bool3 operator <=(Vector3D a, Vector3D b) { return new Bool3(a.x <= b.x, a.y <= b.y, a.z <= b.z); }
        public static Bool3 operator >=(Vector3D a, Vector3D b) { return new Bool3(a.x >= b.x, a.y >= b.y, a.z >= b.z); }
        public static Bool3 operator !=(Vector3D a, Vector3D b) { return new Bool3(a.x != b.x, a.y != b.y, a.z != b.z); }
        public static Bool3 operator ==(Vector3D a, Vector3D b) { return new Bool3(a.x == b.x, a.y == b.y, a.z == b.z); }

        public static Vector3D operator +(Vector3D a, Vector3D b) { return new Vector3D(a.x + b.x, a.y + b.y, a.z + b.z); }
        public static Vector3D operator -(Vector3D a, Vector3D b) { return new Vector3D(a.x - b.x, a.y - b.y, a.z - b.z); }
        public static Vector3D operator *(Vector3D a, Vector3D b) { return new Vector3D(a.x * b.x, a.y * b.y, a.z * b.z); }
        public static Vector3D operator /(Vector3D a, Vector3D b) { return new Vector3D(a.x / b.x, a.y / b.y, a.z / b.z); }
        public static Vector3D operator *(Vector3D a, float b) { return new Vector3D(a.x * b, a.y * b, a.z * b); }
        public static Vector3D operator /(Vector3D a, float b) { return new Vector3D(a.x / b, a.y / b, a.z / b); }
        public static Vector3D operator *(float a, Vector3D b) { return new Vector3D(a * b.x, a * b.y, a * b.z); }
        public static Vector3D operator /(float a, Vector3D b) { return new Vector3D(a / b.x, a / b.y, a / b.z); }

        public static Vector3D operator -(Vector3D a) { return new Vector3D(-a.x, -a.y, -a.z); }

        public Vector3D Min(Vector3D a) { return (this < a).Select(this, a); }
        public Vector3D Max(Vector3D a) { return (this > a).Select(this, a); }
        public float Min() { return x < y ? (x<z?x:z) : (y<z?y:z); }
        public float Max() { return x > y ? (x > z ? x : z) : (y > z ? y : z); }
        public Vector3D Clamp(Vector3D aMin, Vector3D aMax) { return new Vector3D(Op.Clamp(x, aMin.x, aMax.x), Op.Clamp(y, aMin.y, aMax.y), Op.Clamp(z, aMin.z, aMax.z)); }
        public Vector3D Clamp01() { return new Vector3D(Op.Clamp01(x), Op.Clamp01(y), Op.Clamp01(z)); }
        #endregion


        #region Angle
        public bool IsWithin90DegreeOf(Vector3D a) { return Dot(a) >= 0; }
        public bool IsPerpendicular(Vector3D a) { return Dot(a) == 0; }
        public bool IsPerpendicularNear(Vector3D a) { return Op.IsZeroNear(Dot(a)); }
        public bool IsParallel(Vector3D aTo) { return Op.Abs(Dot(aTo)) == 1; }
        public bool IsParallelNear(Vector3D aTo) { return Op.IsZeroNear(Op.Abs(Dot(aTo)-1)); }
        public AngleCos AngleBetween(Vector3D a)
        {
            return new AngleCos(normalized.Dot(a.normalized));
        }
        public AngleCos AngleBetween(Vector3DN a)
        {
            return new AngleCos(normalized.Dot(a));
        }
        #endregion
    }
}