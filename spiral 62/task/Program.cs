// Стало очень стыдно, решил сделать решение задачи №62 заполнения по спирали. Данный код справедлив для квадратных матриц любой размерности

int FillArrayFirst(int[,] array, int coordX, int coordY, int count, out int countNew)   // Метод заполнения первой строки
{
    countNew = count;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        array[coordY, i] = countNew;
        countNew++;
        coordX = i;
    }
    return coordX;
}

int FillArrayDown(int[,] array, int coordX, int coordY, int count, out int countNew) // Метод заполнения вниз
{
    countNew = count;
    for (int j = coordY + 1; j < array.GetLength(1); j++)
    {
        if (array[j, coordX] != 0) break;
        array[j, coordX] = countNew;
        countNew++;
        coordY = j;
    }
    return coordY;
}

int FillArrayLeft(int[,] array, int coordX, int coordY, int count, out int countNew) // Метод заполнения ввлево
{
    countNew = count;
    for (int j = coordY - 1; j >= 0; j--)
    {
        if (array[coordY, j] != 0) break;
        array[coordY, j] = countNew;
        countNew++;
        coordX = j;
    }
    return coordX;
}
int FillArrayTop(int[,] array, int coordX, int coordY, int count, out int countNew) // Метод заполнения вверх
{
    countNew = count;
    for (int j = coordY - 1; j >= 0; j--)
    {
        if (array[j, coordX] != 0) break;
        array[j, coordX] = countNew;
        countNew++;
        coordY = j;
    }
    return coordY;
}

int FillArrayRight(int[,] array, int coordX, int coordY, int count, out int countNew) // Метод заполнения вправо
{
    countNew = count;
    for (int j = coordX + 1; j < array.GetLength(1); j++)
    {
        if (array[coordY, j] != 0) break;
        array[coordY, j] = countNew;
        countNew++;
        coordX = j;
    }
    return coordX;
}

string GetDirectionToFill(int[,] array, bool flagBottom, bool flagTop, bool flagLeft, bool flagRight, int coordX, int coordY)    // Метод определения направления (самое главное)
{
    string flagOut = string.Empty;  // возвращаемая переменная для выборки методов заполнения

    if ((coordY == 0) || (array[coordY - 1, coordX] != 0)) flagTop = false; else flagTop = true;  // если по Y мы на первой строке, 
    // или вышестоящая ячейка массива от текущих координат не равна нулю - то флаг движения вверх ложен, иначе истина

    if ((coordY == array.GetLength(0) - 1) || ((array[coordY + 1, coordX] != 0))) flagBottom = false; else flagBottom = true;
    // если мы находимся на последней строке, или нижестоящая ячейка не равно 0 то флаг движения вниз ложен, иначе истина

    if ((coordX == 0) || ((array[coordY, coordX - 1] != 0))) flagLeft = false; else flagLeft = true;
    // если мы находимся в крайнем левом столбце или левая ячейка от текущих координат не равна 0 то флаг движения влево ложен, иначе истина

    if ((coordX == array.GetLength(1) - 1) || array[coordY, coordX + 1] != 0) flagRight = false; else flagRight = true;
    // если мы находимся в крайнем правом столбце или правая ячейка от текущих координат не равно 0 то флаг движения вправо ложен, иначе истина

    System.Console.WriteLine($"FT: {flagTop}");
    System.Console.WriteLine($"FB: {flagBottom}");
    System.Console.WriteLine($"FL: {flagLeft}");
    System.Console.WriteLine($"FR: {flagRight}");

    if (coordX == 0 && coordY == 0)     // здесь мы выставляем значения вовзращаемого значения для метода "первой строки"
    {
        System.Console.WriteLine("Идем вправо!");
        flagOut = "first";
    }
    else
    {
        // далее следует совокупность условий флагов, при различной комбинации мы получаем верное направление движения для заполнения массива

        if ((flagBottom) && (!flagTop) && (!flagLeft) && (!flagRight))
        {
            System.Console.WriteLine("Идем вниз!");
            flagOut = "down";
        }
        if ((!flagBottom) && (!flagTop) && (flagLeft) && (!flagRight))
        {
            System.Console.WriteLine("Идем влево!");
            flagOut = "left";
        }
        if ((!flagBottom) && (flagTop) && (!flagLeft) && (!flagRight))
        {
            System.Console.WriteLine("Идем вверх!");
            flagOut = "top";
        }
        if ((!flagBottom) && (!flagTop) && (!flagLeft) && (flagRight))
        {
            System.Console.WriteLine("Идем вправо!");
            flagOut = "right";
        }
        if ((!flagBottom) && (!flagTop) && (!flagLeft) && (!flagRight))
        {
            System.Console.WriteLine("КОНЕЦ");
            flagOut = "end";
        }
    }
    return flagOut;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]} ");
        }
        System.Console.WriteLine();
    }

}

// -------------------------- ТЕЛО ПРОГРАММЫ -----------------------

Console.Clear();
bool flagTop = true;
bool flagBottom = true;
bool flagLeft = true;
bool flagRight = true;
string flagOut = string.Empty;

int[,] array = new int[4, 4]; // здесь вручную задается размерность матрицы

int coordX = 0;
int coordY = 0;
int count = 1;  // значения элемента в матрице
int countNew = 0; // инициализация глобальной переменной для типа out


while (flagOut != "end") // до тех пор, пока переменная не примет значения end(т.е. массив будет заполнен(все флаги движения будут FALSE)) выполнять цикл
{
    flagOut = GetDirectionToFill(array, flagBottom, flagTop, flagLeft, flagRight, coordX, coordY);
    if (flagOut == "first")
    {
        coordX = FillArrayFirst(array, coordX, coordY, count, out countNew);
        count = countNew;
    };
    if (flagOut == "down")
    {
        coordY = FillArrayDown(array, coordX, coordY, count, out countNew);
        count = countNew;
    };
    if (flagOut == "left")
    {
        coordX = FillArrayLeft(array, coordX, coordY, count, out countNew);
        count = countNew;
    };
    if (flagOut == "top")
    {
        coordY = FillArrayTop(array, coordX, coordY, count, out countNew);
        count = countNew;
    };
    if (flagOut == "right")
    {
        coordX = FillArrayRight(array, coordX, coordY, count, out countNew);
        count = countNew;
    };
    if (flagOut == "end")
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Результирующий массив: ");
        PrintArray(array);
        break;
    };
    PrintArray(array);
    System.Console.WriteLine($"X: {coordX}");
    System.Console.WriteLine($"Y: {coordY}");
    System.Console.WriteLine($"Текущее значение: {count}");
}