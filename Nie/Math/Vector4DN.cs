#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_DASHBOARD_WIDGET || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY || UNITY_WP8 || UNITY_METRO || UNITY_WINRT
#   define NIEMATH_UNITY
#endif

namespace Nie.Math
{
    public struct Vector4DN : IVector4D<float>
    {
        #region Conversion
        public static implicit operator Vector4D(Vector4DN a)
        {
            return a.mBase;
        }
        public static explicit operator Vector4DN(Vector4D a)
        {
            Debug.Assert(a.IsNormal());
            Vector4DN v;
            v.mBase = a;
            return v;
        }
        #endregion
        
        #region IVector4D
        public float x { get { return mBase.x; } set { mBase.x = value; } }
        public float y { get { return mBase.y; } set { mBase.y = value; } }
        public float z { get { return mBase.z; } set { mBase.z = value; } }
        public float w { get { return mBase.w; } set { mBase.w = value; } }
        #endregion
        


        #region Object
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }
        public override string ToString() { return mBase.ToString(); }
        #endregion


        public Vector4DN normalized { get { return this; } }
        public float length { get { return Scalar.one; } }
        public float sqrLength { get { return Scalar.one; } }


        #region Constructor
        public Vector4DN(float x, float y, float z, float w)
        {
            mBase = new Vector4D(x,y,z,w);
            Debug.Assert(mBase.IsNormal());
        }
        public Vector4DN(Vector2D aXY, Vector2D aZW)
        {
            mBase = new Vector4D(aXY, aZW);
            Debug.Assert(mBase.IsNormal());
        }
        public Vector4DN(Vector4D a)
        {
            mBase = a;
            Debug.Assert(mBase.IsNormal());
        }
        #endregion

        public Vector2D xy { get { return mBase.xy; } }
        public Vector2D xz { get { return mBase.xz; } }
        public Vector2D xw { get { return mBase.xw; } }
        public Vector2D yz { get { return mBase.yz; } }
        public Vector2D yw { get { return mBase.yw; } }
        public Vector2D zw { get { return mBase.zw; } }

        public Vector2D xx { get { return mBase.xx; } }
        public Vector2D yy { get { return mBase.yy; } }
        public Vector2D zz { get { return mBase.zz; } }
        public Vector2D ww { get { return mBase.ww; } }

        public Vector3D xyz { get { return mBase.xyz; } }
        public Vector3D yzw { get { return mBase.yzw; } }

        public Vector3D xxx { get { return mBase.xxx; } }
        public Vector3D yyy { get { return mBase.yyy; } }
        public Vector3D zzz { get { return mBase.zzz; } }
        public Vector3D www { get { return mBase.www; } }

        public Vector4D xxxx { get { return mBase.xxxx; } }
        public Vector4D yyyy { get { return mBase.yyyy; } }
        public Vector4D zzzz { get { return mBase.zzzz; } }
        public Vector4D wwww { get { return mBase.wwww; } }

        public bool IsNormal() { return true; }


        public float Dot(Vector4D a)
        {
            return mBase.Dot(a);
        }



        #region Operator
        public static Bool4 operator < (Vector4DN a, Vector4DN b) { return a.mBase <  b.mBase; }
        public static Bool4 operator > (Vector4DN a, Vector4DN b) { return a.mBase >  b.mBase; }
        public static Bool4 operator <=(Vector4DN a, Vector4DN b) { return a.mBase <= b.mBase; }
        public static Bool4 operator >=(Vector4DN a, Vector4DN b) { return a.mBase >= b.mBase; }
        public static Bool4 operator !=(Vector4DN a, Vector4DN b) { return a.mBase != b.mBase; }
        public static Bool4 operator ==(Vector4DN a, Vector4DN b) { return a.mBase == b.mBase; }

        public static Vector4D operator +(Vector4DN a, Vector4DN b) { return a.mBase +  b.mBase; }
        public static Vector4D operator -(Vector4DN a, Vector4DN b) { return a.mBase -  b.mBase; }
        public static Vector4D operator *(Vector4DN a, Vector4DN b) { return a.mBase *  b.mBase; }
        public static Vector4D operator /(Vector4DN a, Vector4DN b) { return a.mBase /  b.mBase; }
        public static Vector4D operator *(Vector4DN a, float b    ) { return a.mBase *  b      ; }
        public static Vector4D operator /(Vector4DN a, float b    ) { return a.mBase /  b      ; }
        public static Vector4D operator *(float a    , Vector4DN b) { return a       *  b.mBase; }
        public static Vector4D operator /(float a    , Vector4DN b) { return a       /  b.mBase; }

        public static Vector4DN operator -(Vector4DN a) { return new Vector4DN(-a.mBase); }

        public Vector4D Min(Vector4DN a) { return mBase.Min(a.mBase); }
        public Vector4D Max(Vector4DN a) { return mBase.Max(a.mBase); }
        public float Min() { return mBase.Min(); }
        public float Max() { return mBase.Max(); }
        #endregion

        
        Vector4D mBase;
    }
}