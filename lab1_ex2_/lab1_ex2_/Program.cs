rectangle A = new rectangle(4.0, 5.0);
double expected = 18.0;
double actual = A.Perimetr;
Console.Write(actual);
public class rectangle
{
    double length;
    double width;
    public rectangle(double side1 = 0.0, double side2 = 0.0)
    {
        length = side1;
        width = side2;
    }
    private double CalculateArea()
    {
        return length * width;
    }

    private double CalculatePerimetr()
    {
        return ((length + width) * 2.0);
    }
    public double Area
    {
        get
        {
            return CalculateArea();
        }
    }
    public double Perimetr
    {
        get
        {
            return CalculatePerimetr();
        }
    }
}