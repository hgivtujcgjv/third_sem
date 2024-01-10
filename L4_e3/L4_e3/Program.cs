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
        foreach (var i in test)
        {
            i.Print();
        }
        Catalog catalog = new Catalog(test);

        Console.WriteLine("Прямой проход:");
        foreach (var car in catalog)
        {
            car.Print();
        }
         
        
        Console.WriteLine("\nОбратный проход:");
        foreach (Car car in catalog.GetEnumeratorReverse())
        {
            car.Print();
        }

        Console.WriteLine("\nПроход с поиском года выпуска:");
        foreach (Car car in catalog.GetProdYear(2022))
        {
            car.Print();
        }

        Console.WriteLine("\nПроход с поиском по скорости:");
        foreach (Car car in catalog.GetMS(370))
        {
            car.Print();
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
    public void Print()
    {
        Console.WriteLine($"Марка : {Name} , Год выпуска : {ProductionYear} , Максимальная скорость {MaxSpeed}");
    }

}

class CarComparer : IComparer<Car>
{
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

class Catalog : IEnumerable<Car>
{
    private Car[] catalog;
    int position = -1;
    public Catalog(Car[] massive) { this.catalog = massive; }
    public IEnumerator<Car> GetEnumerator()
    {
        return new CatalogEnum(catalog);
    }
    public IEnumerable<Car> GetEnumeratorReverse()
    {
        for (int i = catalog.Length - 1; i >= 0; --i)
        {
            yield return catalog[i];
        }
    }
    public IEnumerable<Car> GetProdYear(int year)
    {
        foreach (var i in catalog)
        {
            if (i.ProductionYear == year)
            {
                yield return i;
            }
        }
    }

    public IEnumerable<Car> GetMS(int speed)
    {
        foreach (var i in catalog)
        {
            if (i.MaxSpeed == speed)
            {
                yield return i;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

class CatalogEnum : IEnumerator<Car>
{
    public Car[] catalog;

    int position = -1;

    public CatalogEnum(Car[] list)
    {
        catalog = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < catalog.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    public void Dispose()
    {
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Car Current
    {
        get
        {
            try
            {
                return catalog[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}


public enum TypeSorter
{
    name,
    prodYear,
    speed
}

