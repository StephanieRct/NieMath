using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nie.Math;

class Program
{
    static void Main(string[] args)
    {
        Vector2D v0 = new Vector2D(10,20);
        Vector2D v1 = new Vector2D(15,15);
        Vector2D v00 = new Vector2D(0,0);
        Vector2D v11 = new Vector2D(1, 1);

        Vector2D vSelectLow = (v0<v1).Select(v11,v00);
        Console.WriteLine("SelectLow=" + vSelectLow);


        Vector2DN v45 = new Vector2D(1, 1).normalized;
        Vector2DN v90 = new Vector2D(0, 1).normalized;
        float angle = v45.AngleBetween(v90).radian;
        Console.WriteLine("AngleBetween v45 and v90=" + angle + " radian");

        Console.ReadLine();
    }
}
