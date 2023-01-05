// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:  
// 2 4 | 3 4  
// 3 2 | 3 3  
// Результирующая матрица будет:  
// 18 20  
// 15 18  


// Для удобства размерность матрицы - квадратная.


int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2, int[,] resultMatrix)    // метод расчета умножения матрицы на матрицу
{
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(0); k++) // вводим третий цикл для расчетов по формуле из математики
            {
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }

    return resultMatrix;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}

Console.Clear();
// Матрицы мне удобнее было объявить вручную для простоты работы кода.
int[,] matrix1 = {
                    {2,4},
                    {3,2},
                    };
int[,] matrix2 = {
                    {3,4},
                    {3,3},
                    };

int[,] resultMatrix = {
                        {0,0},
                        {0,0}
                        };



System.Console.WriteLine("Матрицу №1");
PrintArray(matrix1);
System.Console.WriteLine("умножаем на матрицу №2");
PrintArray(matrix2);
System.Console.WriteLine("Результат: ");
resultMatrix = MatrixMultiply(matrix1, matrix2, resultMatrix);
PrintArray(resultMatrix);