MyMatrix test1 = new MyMatrix(2, 2, 10);
int k = 0;
test1.Show();
MyMatrix.Fill(test1);
Console.WriteLine("\nПерезаполненая матрица");
test1.Show();
MyMatrix test2 = new MyMatrix();
Console.WriteLine("\n\nCalled  ChangeSide");
test2.ChangeSide(test1, 4, 4);
test2.ShowPartialy(0, 0, 4, 4);

Console.WriteLine("\n\n\nShow");
test2.Show();
Console.WriteLine("\nВызов индексатора");
Console.WriteLine(test2[0, 0]);
class MyMatrix {
    private int[,] matrix;

    public MyMatrix() { 
        
    }
    public MyMatrix(int i, int j, int range)
    {
        var rand = new Random();
        matrix = new int[i, j];
        for (int k = 0; k < i; ++k)
        {
            for (int c = 0; c < j; ++c)
            {
                matrix[k, c] = rand.Next(range);
            }
        }
    }
    public static MyMatrix Fill(MyMatrix other)
    {
        var rand = new Random();
        int rows = other.matrix.GetUpperBound(0) + 1;    
        int columns = other.matrix.Length / rows;
        for (int k = 0; k < rows; ++k)
        {
            for (int c = 0; c < columns; ++c)
            {
                other.matrix[k, c] = rand.Next(100);
            }
        }
        return other;
    }
    public MyMatrix ChangeSide(MyMatrix other,int rows ,int columns) {
        var rand = new Random();
        this.matrix = new int[rows, columns];
        int minRows = Math.Min(rows, other.matrix.GetLength(0));
        int minCols = Math.Min(columns, other.matrix.GetLength(1));
        int maxRows = Math.Max(rows, other.matrix.GetLength(0));
        int maxCols = Math.Max(columns, other.matrix.GetLength(1));
        for (int i = 0; i < minRows; i++)
            for (int j = 0; j < minCols; j++)
                this.matrix[i, j] = other.matrix[i, j];
        for (int i = 0; i < maxRows; i++)
            for (int j = minCols; j < maxCols; j++)
                this.matrix[i, j] = rand.Next(1000);
        return this;
    }

    public void ShowPartialy(int start_rows, int start_columns, int end_rows, int end_columns)
    {
        int rows = this.matrix.GetUpperBound(0) + 1;
        int columns = this.matrix.Length / rows;
        for (int i = start_rows; i < end_rows; i++)
        {
            int k = 0;
            for (int j = start_columns; j < end_columns; j++)
            {
                ++k;
                Console.Write($"{this.matrix[i, j]}   ");
                if (k == columns) { Console.WriteLine(); }
            }
        }
    }

    public void Show()
    {
        int rows = this.matrix.GetUpperBound(0) + 1;
        int columns = this.matrix.Length / rows;
        for (int i = 0; i < (this.matrix.GetUpperBound(0) + 1); ++i)
        {
            int k = 0;
            for (int j = 0; j < columns; ++j)
            {
                ++k;
                Console.Write($"{this.matrix[i, j]}   ");
                if (k == columns)
                {
                    Console.WriteLine();
                }
            }
        }
    }
    public int this[int index, int index2]
    {
        get
        {
            if (index <= matrix.GetUpperBound(0) + 1 || index2 <= (matrix.Length / (matrix.GetUpperBound(0) + 1)))
            {
                return matrix[index, index2];
            }
            else
            {
                throw new Exception("Длина индексов превышает размер массива");
            }
        }
        set
        {
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

}