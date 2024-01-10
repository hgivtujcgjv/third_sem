
using System;
using System.Xml.Linq;

Car car1 = new Car ( 150,"Мазда","Бензин");
Car car2 = new Car (160,"Тойота","Дизель");
Console.WriteLine (car1.Equals(car2));
interface aaa{
    bool Equals(object other) {
        if (other == null || GetType() != other.GetType())
            return false;
        return Equals((Car)other);
    }
}
class Car: aaa {
    int MaxSpeed;
    string? Engine;
    string? name;
    public Car(int ms = 0, string? eg = "Undefind", string? fn = "Undefind") { 
        MaxSpeed = ms;
        Engine = eg;
        name = fn;
    }
    public bool Equals(Car other)
    {
        return Equals(other);
    }
    public override string ToString()
    {
        return name;
    }

}
