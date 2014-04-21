namespace Nie.Math
{

    public class Op
    {
        public static float Abs(float a) { return System.Math.Abs(a); }
        public static int Sign(float a) { return System.Math.Sign(a); }
        public static float Sqrt(float a) { return (float)System.Math.Sqrt(a); }
        public static float Square(float a) { return a*a; }

        public static float ACos(float a) { return (float)System.Math.Acos(a); }
        public static float ASin(float a) { return (float)System.Math.Asin(a); }
        public static float Cos (float a) { return (float)System.Math.Cos (a); }
        public static float Sin (float a) { return (float)System.Math.Sin (a); }

        public static float Min(float a, float b) { return a < b ? a : b; }
        public static float Max(float a, float b) { return a < b ? a : b; }
        public static float Clamp(float v, float aMin, float aMax) { return v < aMin ? aMin : v > aMax ? aMax : v; }
        public static float Clamp01(float v) { return v < 0 ? 0 : v > 1 ? 1 : v; }
        
        public static bool IsZeroNear(float a){
            return IsNear(a, Scalar.zero);
        }
        public static bool IsNear(float a, float b)
        {
            float diff = Op.Abs(a - b);
            return diff <= 0.001f;
        }
    }
}