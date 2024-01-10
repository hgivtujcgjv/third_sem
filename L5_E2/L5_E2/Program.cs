
using System;
using System.Collections;
using System.Numerics;

list<string> ets = new list<string>() { "ads","bnbnbnb","ssssss"};
ets.Add("первый элемент");
ets.Add("второй элемент");
ets.Add("третий элемент");
Console.WriteLine(ets[2]);
class list<T> : IEnumerable<T>, IEnumerator<T>
{
    private T[] mass;
    public list() {
        this.mass = new T[0];
    }

    public int Length {
        get { return this.mass.Length; }
    }

    public T Current => throw new NotImplementedException();

    object IEnumerator.Current => throw new NotImplementedException();

    public void Add(T other) {
        T[] extendedList = new T[this.Length + 1];
        if (this.Length > 0)
        {
            Array.Copy(this.mass, extendedList, this.Length);
        }
        extendedList[extendedList.Length - 1] = other;
        this.mass = extendedList;
    }

    public void Add(params T[] items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public T this[int i] {
        get {
            if (i >= 0 && i < this.mass.Length)
            {
                return mass[i];
            }
            throw new IndexOutOfRangeException();
        }
        set {
            if (i >= 0 && i < this.mass.Length)
            {
                this.mass[i] = value;
            }
            throw new IndexOutOfRangeException();
        }
    }

}