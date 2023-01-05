// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.  
// Например, на выходе получается вот такой массив:  
// 01 02 03 04  
// 12 13 14 05  
// 11 16 15 06  
// 10 09 08 07 



// Простите - безумный треш с заполнением!! Сплошные костыли. Далее в комментах попробую разъяснить.
// Можете не засчитывать задачу - она решена, но ужасным способом, самому стыдно!

int[,] array = new int[4, 4];
int rows = array.GetLength(1);
int columns = array.GetLength(0);
rows = 0;
int count = 1;

int FillRowsArray(int[,] array, int rows, int columns, int count)  // метод заполнения последовательно строки
{
    for (int i = rows; i < columns; i++)
    {
        array[rows, i] = count;
        count++;
    }
    return count;
}
int FillRowsArrayReverse(int[,] array, int rows, int columns, int count) // метод заполнения строки в обратную сторону
{
    for (int i = columns - 1; i >= rows - 1; i--)
    {
        if (rows != columns - 1) array[columns, i] = count;
        else { array[columns - 1, i] = count; }
        count++;
    }
    return count;
}

int FillColumnsArray(int[,] array, int rows, int columns, int count)  // метод заполнения столбца вниз
{
    for (int i = rows; i < columns + 1; i++)
    {
        array[i, columns] = count;
        count++;
    }
    return count;
}
int FillColumnsArrayReverse(int[,] array, int rows, int columns, int count) // метод заполнения столбца вверх
{
    for (int i = columns - 1; i >= rows; i--)
    {
        array[i, rows - 1] = count;
        count++;
    }
    return count;
}

void PrintArray(int[,] array)    // вывод массива
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

// Тело программы

count = FillRowsArray(array, rows, columns, count);
PrintArray(array);
rows++; //1   
columns--; //3
count = FillColumnsArray(array, rows, columns, count);
count = FillRowsArrayReverse(array, rows, columns, count);
count = FillColumnsArrayReverse(array, rows, columns, count);
count = FillRowsArray(array, rows, columns, count);
rows++;
count = FillRowsArrayReverse(array, rows, columns, count);


Console.Clear();
PrintArray(array);

// Признаю - программа решена на костылях. 