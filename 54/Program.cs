// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:  
// 1 4 7 2  
// 5 9 2 3  
// 8 4 2 4  
// В итоге получается вот такой массив:  
// 7 4 2 1  
// 9 5 3 2  
// 8 4 4 2  

int[,] array = {                // Зададим матрицу вручную
                {1,4,7,2},
                {5,9,2,3},
                {8,4,2,4},
                };

void SortMatrix(int[,] array, int row)  // метод сортировки строки в двумерном массиве
{
    int temp = 0;
    bool flag = true;        // флаг нужен для отработки условия, что строка отсортирована
    while (flag == true)     // сортировка строки в цикле (методом пузырька)
    {
        flag = false;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            if (i < array.GetLength(1) - 1)
            {
                if (array[row, i] < array[row, i + 1])
                {
                    temp = array[row, i];
                    array[row, i] = array[row, i + 1];
                    array[row, i + 1] = temp;
                    flag = true;
                }
            }
            else break;
        }
    }
}

void PrintArray(int[,] array)   // метод печати массива
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

// --------------------  Тело программы

Console.Clear();
for (int i = 0; i < array.GetLength(0); i++)
{
    SortMatrix(array, i);
}

PrintArray(array);