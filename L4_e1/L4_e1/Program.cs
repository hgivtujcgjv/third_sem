using System;
using System.Numerics;
using System.Reflection;

int c = Int32.Parse(Console.ReadLine());
MyMatrix test = new MyMatrix(4, 4,c);
for (int i = 0; i < 4; ++i) {
    for (int j = 0; j < 4; ++j) {
        Console.Write($"{ test[i, j]}   ");
    }
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
MyMatrix test2 = new MyMatrix(4, 4,c);
for (int i = 0; i < 4; ++i)
{
    for (int j = 0; j < 4; ++j)
    {
        Console.Write($"{test2[i, j]}   ");
    }
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
MyMatrix result = test * 10;
for (int i = 0; i < 4; ++i)
{
    for (int j = 0; j < 4; ++j)
    {
        Console.Write($"{result[i, j]}   ");
    }
    Console.WriteLine();
}

class MyMatrix {
    int[,]? matrix;
    int rows;
    int coloumns;
    public MyMatrix(int i, int j,string nul)
    {
        int k = 0;
        matrix = new int[i, j];
        while (k < i)
        {
            for (int c = 0; c < j; ++c)
            {
                matrix[k, c] = 0;
            }
            k++;
        }
        rows = matrix.GetUpperBound(0) + 1;
        coloumns = matrix.Length / rows;
    }
    public MyMatrix(int i, int j,int max_rand) {
        int k = 0;
        var rand = new Random();
        matrix = new int[i, j];
        while (k < i) {
            for (int c = 0; c < j; ++c)
            {
                matrix[k, c] = rand.Next(max_rand);
            }
            k++;
        }
        rows = matrix.GetUpperBound(0) + 1;
        coloumns = matrix.Length/rows;
    }

    public int this[int index,int index2]
    {
        get {
            if (index <= matrix.GetUpperBound(0) + 1 || index2 <= (matrix.Length / (matrix.GetUpperBound(0) + 1)))
            {
                return matrix[index, index2];
            }
            else {
                throw new Exception("Длина индексов превышает размер массива");
            }
        }
        set {
            if (index <= matrix.GetUpperBound(0) + 1 || index2 <= (matrix.Length / (matrix.GetUpperBound(0) + 1)))
            {
                matrix[index, index2] = value;
            }
            else
            {
                throw new Exception("Длина индексов превышает размер массива");
            }
        }
    }
    public static MyMatrix operator +(MyMatrix other,MyMatrix other2) {
        if (other.rows == other2.rows || other.coloumns == other2.coloumns)
        {
            MyMatrix result = new MyMatrix(other.rows,other.coloumns,"0");
            for (int i = 0; i < other.rows; ++i) {
                for (int j = 0; j < other2.coloumns; ++j) {
                    result.matrix[i, j] = other.matrix[i, j] + other2.matrix[i, j];
                }
            }
            return result;
        }
        else
        {
            throw new Exception("Длина индексы массивов не совпадают ");
        }
    }
    public static MyMatrix operator -(MyMatrix other, MyMatrix other2)
    {
        if (other.rows == other2.rows || other.coloumns == other2.coloumns)
        {
            MyMatrix result = new MyMatrix(other.rows, other.coloumns, "0");
            for (int i = 0; i < other.rows; ++i)
            {
                for (int j = 0; j < other2.coloumns; ++j)
                {
                    result.matrix[i, j] = other.matrix[i, j] - other2.matrix[i, j];
                }
            }
            return result;
        }
        else
        {
            throw new Exception("Длина индексы массивов не совпадают ");
        }
    }
    public static MyMatrix operator *(MyMatrix other, MyMatrix other2)
    {
        if (other.rows == other2.rows || other.coloumns == other2.coloumns)
        {
            MyMatrix result = new MyMatrix(other.rows, other2.coloumns,"0");
            for (int i = 0; i < other.rows; ++i)
            {
                for (int j = 0; j < other2.coloumns; ++j)
                {
                    result.matrix[i, j] = other.matrix[i, j] * other2.matrix[i, j];
                }
            }
            return result;
        }
        else
        {
            throw new Exception("Длина индексы массивов не совпадают ");
        }
    }
    public static MyMatrix operator *(MyMatrix other,int scalar)
    {
            for (int i = 0; i < other.rows; ++i)
            {
                for (int j = 0; j < other.coloumns; ++j)
                {
                    other.matrix[i, j] = other.matrix[i, j] *scalar;
                }
            }
            return other;
    }
    public static MyMatrix operator /(MyMatrix other, int scalar)
    {
        for (int i = 0; i < other.rows; ++i)
        {
            for (int j = 0; j < other.coloumns; ++j)
            {
                other.matrix[i, j] = other.matrix[i, j] / scalar;
            }
        }
        return other;
    }
}
