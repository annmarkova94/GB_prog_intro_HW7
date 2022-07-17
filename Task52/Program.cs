// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

TextColorGreen();
//..................................................
double minNumber = 1;
double maxNumber = 9;
double[,] matrix = GetMatrix(minNumber, maxNumber);
PrintMatrix(matrix);
//..................................................
double[] averageForColumns = GetAverageForEveryColumn(matrix);
PrintArray(averageForColumns);
//..................................................
Console.ResetColor();


//.............Specific method for this task..............//
double[] GetAverageForEveryColumn(double[,] matrix)
{
    double[] arrayOfAverageForEveryColumn = new double[matrix.GetLength(1)];
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        double sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            sum += matrix[i, j];
        arrayOfAverageForEveryColumn[j] = sum / matrix.GetLength(0);
    }
    return arrayOfAverageForEveryColumn;
}

//....................Basic methods......................//
double[,] GetMatrix(double minNumber, double maxNumber)
{
    Console.Write("Enter number of ROWS for a new matrix: ");
    int nRows = EnterPositiveInteger();
    Console.Write("Enter number of COLUMNS for a new matrix: ");
    int nCols = EnterPositiveInteger();
    double[,] matrix = new double[nRows, nCols];
    var rnd = new Random();
    for (int i = 0; i < nRows; i++)
        for (int j = 0; j < nCols; j++)
        {
            matrix[i, j] = rnd.NextDouble() * (maxNumber - minNumber) + minNumber;
        }
    return matrix;
}

void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{Math.Round(matrix[i, j], 2),5}");
        }
        Console.WriteLine();
    }
}

void PrintArray(double[] array)
{
    Console.WriteLine($"Average for every column is [{string.Join(", ", array.Select(x => Math.Round(x, 2)))}]");
}

int EnterPositiveInteger()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number)
           || number < 1)
    {
        TextColorRed();
        Console.Write("This is not a positive integer, try again: ");
        TextColorGreen();
    }
    return number;
}

void TextColorGreen()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
}
void TextColorRed()
{
    Console.ForegroundColor = ConsoleColor.Red;
}