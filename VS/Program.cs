using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nie.Math;

class Program
{
    static System.Random random = new System.Random();
    static float rndFloat(){
        //http://stackoverflow.com/questions/3365337/best-way-to-generate-a-random-float-in-c-sharp
        double mantissa = (random.NextDouble() * 2.0) - 1.0;
        double exponent = Math.Pow(2.0, random.Next(-126, 128));
        return (float)(mantissa * exponent);
    }
    static void TestIVector3<T, T2, T3>(ref T aOut, T2 a, T3 b)
        where T : IVector3D<float>
        where T2 : IConstVector3D<float>
        where T3 : IConstVector3D<float>
    {
        aOut.x = a.x + b.x;
        aOut.y = a.y + b.y;
        aOut.z = a.z + b.z;
    }
    static void Main(string[] args)
    {
        Vector3D r = new Vector3D(0,0,0);
        Vector3D v3D1 = new Vector3D(1, 2, 3);
        Vector3DN v3DN1 = v3D1.normalized;
        TestIVector3(ref r, v3D1, v3DN1);


        Vector2D v0 = new Vector2D(10,20);
        Vector2D v1 = new Vector2D(15,15);
        Vector2D v00 = new Vector2D(0,0);
        Vector2D v11 = new Vector2D(1, 1);

        Vector2D vSelectLow = (v0<v1).Select(v11,v00);
        Console.WriteLine("SelectLow=" + vSelectLow);

        Bool2 b2False = new Bool2(false, false);
        Bool2 b2True  = new Bool2(true , true );
        Bool2 b2Select = (v0 < v1).Select(b2False, b2True);

        Vector2DN v45 = new Vector2D(1, 1).normalized;
        Vector2DN v90 = new Vector2D(0, 1).normalized;
        float angle = v45.AngleBetween(v90).radian;
        Console.WriteLine("AngleBetween v45 and v90=" + angle + " radian");

        Bool2 b0 = v45 < v90;
        Bool2 b1 = v45 < v11;

        Console.ReadLine();
    }

}



