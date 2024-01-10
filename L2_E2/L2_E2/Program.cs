Car car = new Car(30000, 200, 2022, "Toyota");
Plane plane = new Plane(10000000, 600, 2022, "Boeing 747", 40000, 500);
Ship ship = new Ship(5000000, 60, 2022, "MSC", "New York");

car.Print();
Console.WriteLine();

plane.Print();
Console.WriteLine();

ship.Print();
class Vehicle {
    int? cost;
    int? max_speed;
    int? year_realease;
    public Vehicle(int? cost1, int? ms, int? y_r) {
        cost = cost1;
        max_speed = ms;
        year_realease = y_r;
    }
    public virtual void Print() {
        Console.Write($"Стоимость: {cost} , Максимальная скорость: {max_speed} , Год выпуска : {year_realease} ");
    }
}

class Car : Vehicle {
    string? car_mark;
    public Car(int? cost1, int? ms, int? y_r, string? type) : base(cost1, ms, y_r) {
        car_mark = type;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Марка машины : {car_mark}");
    }
}

class Plane : Vehicle
{
    string? plane_mark;
    int? max_h;
    int? max_pass;
    public Plane(int? cost1, int? ms, int? y_r, string? type, int? max_h1, int? max_pass1) : base(cost1, ms, y_r)
    {
        plane_mark = type;
        max_h = max_h1;
        max_pass = max_pass1;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Марка самолета : {plane_mark} , Максимальная высота: {max_h} , максимальное количество пассажиров :{max_pass}");
    }
}

class Ship : Vehicle
{
    string? ship_mark;
    string? ship_name;
    string? port;
    public Ship(int? cost1, int? ms, int? y_r, string? type, string? port1) : base(cost1, ms, y_r)
    {
        ship_mark = type;
        port = port1;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Марка самолета : {ship_mark} , Имя судна: {ship_name} , Порт отправления :{port}");
    }
}