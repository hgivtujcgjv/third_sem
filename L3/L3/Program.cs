using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;

Vector A = new Vector(24.0, 25.0, 26.0);
Vector B = new Vector(27.0, 27.0, 27.0);
Vector C =  B * 2.00;
Console.WriteLine(C.x);
class Vector {
    public double x;
    double y;
    double z;
    public Vector(double x1, double y1, double z1) { 
        x = x1;
        y = y1;
        z = z1;
    }
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector operator *(Vector a, Vector b)
    {
        return new Vector(a.x * b.x, a.y * b.y, a.z * b.z);
    }
    public static bool operator >(Vector a, Vector b)
    {
        return a.vecLength() > b.vecLength();
    }

    public static bool operator <(Vector a, Vector b)
    {
        return a.vecLength() < b.vecLength();
    }
    private double vecLength()
    {
        return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
    }
    public static bool operator >=(Vector a, Vector b)
    {
        return a.vecLength() >= b.vecLength();
    }

    public static bool operator <=(Vector a, Vector b)
    {
        return a.vecLength() <= b.vecLength();
    }
    public static Vector operator *(Vector b,double a)
    {
        return new Vector(b.x *a, b.y*a, b.z * a);
    }

}