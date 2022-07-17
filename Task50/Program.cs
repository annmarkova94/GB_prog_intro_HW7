// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет. Например, задан массив:
// 4 7 2 // 5 9 2 3 // 8 4 2 4    // 1, 7->такого числа в массиве нет

TextColorGreen();
//..................................................
double minNumber = 1;
double maxNumber = 9;
double[,] matrix = GetMatrix(minNumber, maxNumber);
PrintMatrix(matrix);

Console.Write("Enter ROW position: ");
int indexI = EnterPositiveInteger();
Console.Write("Enter COLUMN position: ");
int indexJ = EnterPositiveInteger();
PrintElementOnPosition(matrix, indexI, indexJ);
//..................................................
Console.ResetColor();

//.............Specific method for this task..............//
void PrintElementOnPosition(double[,] matrix, int indexI, int indexJ)
{
    int nRows = matrix.GetLength(0);
    int nCols = matrix.GetLength(1);
    if (indexI < 0 || indexI >= nRows
        || indexJ < 0 || indexJ >= nRows)
    {
        Console.WriteLine("Row and/or column is out of range");
    }
    else
        Console.WriteLine($"There is number {Math.Round(matrix[indexI, indexJ], 2)} on position [{indexI}, {indexJ}]");
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