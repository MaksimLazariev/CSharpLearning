﻿// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
// * Вывести пары чисел: значение - позиция 1, позиция 2

//------------  Тело программы ------------------

// Генерируем массив
int[] array = GenArray(30,0,10);
// Печатаем заданный массив
PrintData("Рандомный массив\n");
Print1DArr(array);


// Печатаем отсортированный массив, чтоб можно было отследить количество пар в массиве
// Столкнулся с тем, что если передаю в метод сортировки Пузырька основной массив, то основной будет отсортирован. 
// Поэтому сначала копирую основной массив во второстепенный

int[] bubbleArray = new int[array.Length];
array.CopyTo(bubbleArray, 0);

PrintData("Массив отсортирован методом пузырька\n");
bubbleArray = BubbleSort(bubbleArray);
Print1DArr(bubbleArray);

// Печатаем пары чисел в виде "Значение: 1позиция 2позиция" 
PairSort(array, 0, 10);

PrintData( "\n\nСумма чисел на нечетных местах равна " + SumOdd(array) );


// ------------------   Методы -----------------------------

// Метод нахождения суммы нечетных чисел
int SumOdd(int[] arr)
{
    int result = 0;
    int i = 1;
    while(i < arr.Length)
    {
        result += arr[i];
        i +=2;
    }
    return result;
}

// Метод печати пар чисел. Используем частично метод сортировки подсчетом. Нужно знать границы значений массива. Считаем для каждого значения количество вхождений в массив, записываем количество во вспомогательный массив (индекс вспог массива = знчение основного массива )
int[] PairSort(int[] arr, int minNum, int maxNum)
{
    int[] countArr = new int[maxNum+1];         // Заводим вспомогательный массив длиной равной максимальному значению заданного массива. По умолчанию элементы int массива равны 0, как и требуется в условиях сортировки. 
    int minIndex; 
    int pairCounter;

    for (int i = 0; i < arr.Length; i++)        // Заполняем вспомогательный массив
    {
        countArr[arr[i]] += 1;                  // Увеличиваем на 1 ячейки под тем же номером в массиве с результатом подсчёта
    }
    
    for (int i = minNum; i < maxNum+1; i++)       // Проходим по вспомогательному массиву
    {
        minIndex = 0;                           // Индекс отслеживает место второго числа в паре
        while (countArr[i] > 1)                 // Проверяем, что количество значений в основном массиве 2 и более (т.е. есть пара)
        {
            pairCounter = 0;                    // Счетчик найденных одинаковых значений
            PrintData("\nЧисло " + i + ":");    // Печатаем значение основного массива ( он же индекс вспомогательного массива)
            for (int j = minIndex+1; j < arr.Length; j++)   // Цикл идет от мин индекса второго числа в паре
            {
                if( i == arr[j])                // Ищем индексы вхождения значений в основной массив
                {
                    PrintData(" " + j);         // Печатаем идекс вхождения
                    pairCounter++;              // Считаем количество одинаковых чисел
                    minIndex = j;               // Сдвигаем индекс последнего найденного значения 
                }
                if(pairCounter == 2) break;     // если одна пара найдена, сбрасываем цикл
            }
            countArr[i]-=2;                     // уменьшаем на 2 содержимое ячейки (потому что одну пару уже нашли)
        }

    }
    return arr;
}

// Метод сортировки пузырьком. Самый максимальный отодвигаем вправо, затем уменьшаем ряд на один, начинаем сначала.
int[] BubbleSort(int[] arr)
{
    int temp=0;
    for (int i = 0; i < arr.Length; i++)
    {
        bool checker = false;          // Переменная для проверки, был ли обмен значениями при проходе второго цикла
        for (int j = 0; j < arr.Length-i-1; j++)
        {
            if(arr[j]>arr[j+1])         // Если элемент больше следующего, делаем обмен значениями  
            {
                temp = arr[j];          // обмен
                arr[j] = arr[j+1];
                arr[j+1]=temp;
                checker = true;         // ставим значение, что был обмен
            }            
        }
        if(!checker) break;             // если не было обменов, то выходим из цикла For, сортировка окончена. 
    }
    return arr;
}

// Метод генерации массива
 int[] GenArray(int len, int minValue, int maxValue)
{
    Random rnd = new Random();
    int[] arr = new int[len];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = new Random().Next(minValue, maxValue + 1);
    }
    return arr;
}

//Метод  печати одномерного массива
void Print1DArr(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        Console.Write(arr[i] + ", ");
    }
    Console.WriteLine(arr[arr.Length - 1]);
}

// Метод вывода данных
void PrintData( string msg)
{
    Console.Write(msg);
}