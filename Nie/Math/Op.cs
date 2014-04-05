namespace Nie.Math
{

    public class Op
    {
        public static float Abs(float a) { return System.Math.Abs(a); }
        public static int Sign(float a) { return System.Math.Sign(a); }
        public static float Sqrt(float a) { return (float)System.Math.Sqrt(a); }
        
        public static float ACos(float a) { return (float)System.Math.Acos(a); }
        public static float ASin(float a) { return (float)System.Math.Asin(a); }
        public static float Cos (float a) { return (float)System.Math.Cos (a); }
        public static float Sin (float a) { return (float)System.Math.Sin (a); }


        
        public static bool IsZeroNear(float a){
            return IsNear(a, Scalar.zero);
        }
        public static bool IsNear(float a, float b)
        {
            float ratio = a / b;
            float diff = Op.Abs(ratio - Scalar.one);
            return diff <= 0.001f;
        }
    }
}