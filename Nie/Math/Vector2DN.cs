

namespace Nie.Math
{
    /// <summary>
    /// Statically normalized 2D vector. Always have a length of 1.
    /// </summary>
    public struct Vector2DN : IConstVector2D<float>
    {
        #region Conversion
        public static implicit operator Vector2D(Vector2DN a)
        {
            return a.mBase;
        }
        public static explicit operator Vector2DN(Vector2D a)
        {
            Debug.Assert(a.IsNormal());
            Vector2DN v;
            v.mBase = a;
            return v;
        }
        #endregion

        #region IConstVector2D
        public float x { get { return mBase.x; } }
        public float y { get { return mBase.y; } }
        #endregion

        #region Constructor
        public Vector2DN(float x, float y) { mBase = new Vector2D(x, y); Debug.Assert(mBase.IsNormal()); }
        public Vector2DN(Vector2D a)
        {
            mBase = a;
            Debug.Assert(mBase.IsNormal());
        }
        #endregion

        #region Object
        public override bool Equals(object other) { return mBase.Equals(other); }
        public override int GetHashCode() { return mBase.GetHashCode(); }
        public override string ToString() { return mBase.ToString(); }
        #endregion


        public Vector2DN normalized { get { return this; } }
        public float length { get { return Scalar.one; } }
        public float sqrLength { get { return Scalar.one; } }
        public bool IsNormal() { return true; }



        public float Dot(Vector2D a) { return mBase.Dot(a); }
        public float Cross(Vector2D a) { return mBase.Cross(a); }



        #region Operator
        public static Bool2 operator <(Vector2DN a, Vector2DN b) { return a.mBase < b.mBase; }
        public static Bool2 operator >(Vector2DN a, Vector2DN b) { return a.mBase > b.mBase; }
        public static Bool2 operator <=(Vector2DN a, Vector2DN b) { return a.mBase <= b.mBase; }
        public static Bool2 operator >=(Vector2DN a, Vector2DN b) { return a.mBase >= b.mBase; }
        public static Bool2 operator !=(Vector2DN a, Vector2DN b) { return a.mBase != b.mBase; }
        public static Bool2 operator ==(Vector2DN a, Vector2DN b) { return a.mBase == b.mBase; }

        public static Vector2D operator +(Vector2DN a, Vector2DN b) { return a.mBase + b.mBase; }
        public static Vector2D operator -(Vector2DN a, Vector2DN b) { return a.mBase - b.mBase; }
        public static Vector2D operator *(Vector2DN a, Vector2DN b) { return a.mBase * b.mBase; }
        public static Vector2D operator /(Vector2DN a, Vector2DN b) { return a.mBase / b.mBase; }
        public static Vector2D operator *(Vector2DN a, float b) { return a.mBase * b; }
        public static Vector2D operator /(Vector2DN a, float b) { return a.mBase / b; }
        public static Vector2D operator *(float a, Vector2DN b) { return a * b.mBase; }
        public static Vector2D operator /(float a, Vector2DN b) { return a / b.mBase; }

        public static Vector2DN operator -(Vector2DN a) { return new Vector2DN(-a.mBase); }

        public Vector2D Min(Vector2DN a) { return mBase.Min(a.mBase); }
        public Vector2D Max(Vector2DN a) { return mBase.Max(a.mBase); }
        public float Min() { return mBase.Min(); }
        public float Max() { return mBase.Max(); }
        #endregion


        #region Angle
        public Vector2DN perpendicularCW { get { return new Vector2DN(y, -x); } }
        public Vector2DN perpendicularCCW { get { return new Vector2DN(-y, x); } }
        public bool IsClockwise(Vector2D a) { return mBase.IsClockwise(a); }
        public bool IsCounterclockwise(Vector2D a) { return mBase.IsCounterclockwise(a); }
        public SignCircularDirection CircularDirection(Vector2D a) { return mBase.CircularDirection(a); }
        public bool IsWithin90DegreeOf(Vector2D a) { return mBase.IsWithin90DegreeOf(a); }
        public bool IsPerpendicular(Vector2D a) { return mBase.IsPerpendicular(a); }
        public bool IsPerpendicularNear(Vector2D a) { return mBase.IsPerpendicularNear(a); }
        public bool IsParallel(Vector2D a) { return mBase.IsParallel(a); }
        public bool IsParallelNear(Vector2D a) { return mBase.IsParallelNear(a); }
        public AngleCos AngleBetween(Vector2D a) { return new AngleCos(Dot(a.normalized)); }
        public AngleCos AngleBetween(Vector2DN a) { return new AngleCos(Dot(a)); }
        #endregion

        Vector2D mBase;
    }
}