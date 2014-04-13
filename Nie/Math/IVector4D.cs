namespace Nie.Math
{
    public interface IConstVector4D<T>
    {
        T x { get; }
        T y { get; }
        T z { get; }
        T w { get; }
    }
    public interface IVector4D<T>
    {
        T x { get; set; }
        T y { get; set; }
        T z { get; set; }
        T w { get; set; }
    }
}