namespace Nie.Math{

    public interface IConstVector2D<T>
    {
        T x { get; }
        T y { get; }
    }
    public interface IVector2D<T>
    {
        T x { get; set; }
        T y { get; set; }
    }
}