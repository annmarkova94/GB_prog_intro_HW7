// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.     // 0,5 7 - 2 - 0,2     // 1 - 3,3 8 - 9,9     // 8 7,8 - 7,1 9

TextColorGreen();
//.............................
double minNumber = 1;
double maxNumber = 9;
double[,] matrix = GetMatrix();
PrintMatrix(matrix);
//.............................
Console.ResetColor();


double[,] GetMatrix()
{
    Console.Write("Enter number of ROWS for the array: ");
    int nRows = EnterPositiveInteger();
    Console.Write("Enter number of COLUMNS for the array: ");
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
            Console.Write($"{Math.Round(matrix[i,j], 2), 5}");
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
