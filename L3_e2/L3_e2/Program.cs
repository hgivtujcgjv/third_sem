using System;
Car car1 = new Car(150, "Мазда", "Бензин");
Car car2 = new Car(160, "Тойота", "Дизель");

ICarEquatable car1AsEquatable = car1;
Console.WriteLine(car1AsEquatable.Equals(car2));
CarsCatalog.ShowList();
interface ICarEquatable
{
    bool Equals(Car other);
}

class Car : ICarEquatable
{
    public int MaxSpeed;
    public string? Engine;
    public string? name;

    public Car(int ms = 0, string? eg = "Undefined", string? fn = "Undefined")
    {
        MaxSpeed = ms;
        Engine = eg;
        name = fn;
        CarsCatalog.AddCar(this);
    }

    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return MaxSpeed == other?.MaxSpeed && Engine == other?.Engine && name == other?.name;
    }

    public override string ToString()
    {
        return name;
    }
}

class CarsCatalog {
    private static List<Car> cars = new List<Car>();
    public static void AddCar(Car car)
    {
        cars.Add(car);
    }
    public static List<Car> GetAllCars()
    {
        return cars;
    }
    public static void ShowList() {
        foreach (var i in cars) {
            Console.WriteLine($"Марка : {i.MaxSpeed} , Двигатель : {i.Engine} , Максимальная скорость : {i.MaxSpeed}");
        }
    }
}