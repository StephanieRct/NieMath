

namespace Nie.Math
{

    class Debug
    {
        public static void Assert(bool aCondition)
        {
            System.Diagnostics.Debug.Assert(aCondition);
        }
        public static void Assert(bool aCondition, string aMsg)
        {
            System.Diagnostics.Debug.Assert(aCondition, aMsg);
        }
    }
}