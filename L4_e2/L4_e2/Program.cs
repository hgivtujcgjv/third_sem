using System;
using System.Collections;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Car list1 = new Car("BMW", 2020, 380);
        Car list2 = new Car("Honda", 2023, 370);
        Car list3 = new Car("Lada", 2004, 170);
        Car list4 = new Car("Nissan", 2022, 400);
        Car[] test = { list1, list2, list3, list4 };

        CarComparer sort_speed = new CarComparer();
        sort_speed.sort_type = TypeSorter.prodYear;
        Array.Sort(test, sort_speed);
        foreach (var i in test) {
            i.Print();
        }   
    }
}



class Car 
{
    public string Name;
    public int ProductionYear;
    public int MaxSpeed;
    public Car(string name, int prod, int speed)
    {
        Name = name;
        ProductionYear = prod;
        MaxSpeed = speed;
    }
    public void Print() {
        Console.WriteLine($"Марка : {Name} , Год выпуска : {ProductionYear} , Максимальная скорость {MaxSpeed}") ;
    }
    
}

class CarComparer :  IComparer <Car> {
    public TypeSorter sort_type;
    public int Compare(Car? p1, Car? p2)
    {
        switch (sort_type)
        {
            case TypeSorter.name:
                if (p1 == null | p2 == null)
                {
                    throw new ArgumentException("Переданны параметры с пустым значением");
                }
                return p1.Name.Length - p2.Name.Length;
            case TypeSorter.prodYear:
                if (p1 == null | p2 == null)
                {
                    throw new ArgumentException("Переданны параметры с пустым значением");
                }
                return p1.ProductionYear - p2.ProductionYear;
            default:
                if (p1 == null | p2 == null)
                {
                    throw new ArgumentException("Переданны параметры с пустым значением");
                }
                return p1.MaxSpeed - p2.MaxSpeed;
        }
    }
}
public enum TypeSorter
{
    name,
    prodYear,
    speed
}

