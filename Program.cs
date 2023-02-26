using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SharpEducation
{
    internal class Program
    {
        static int chooseTask()
        {
            int chooseTaskNumb = 0;
            bool ind = true;
            while (ind)
            {
                Console.WriteLine("Chose a number of the task (1 or 2)");
                chooseTaskNumb = int.Parse(Console.ReadLine());
                if (chooseTaskNumb < 1 || chooseTaskNumb > 2)
                {
                    Console.WriteLine("Error number of task lets try now ");
                    ind = true;
                }
                else ind = false;
            }
            return chooseTaskNumb;
        }
        static int chooseSizeArray()
        {
            int inputSizeArray;
            Console.WriteLine(" Please, choose a size of array: ");
            Console.WriteLine(" 1: 10x10 \n" + " 2: 50x50\n"
                + " 3: 100x100\n" + " 4: 500x500\n");
            inputSizeArray = int.Parse(Console.ReadLine());
            if (inputSizeArray == 1)
            {
                inputSizeArray = 10;
            }
            else if (inputSizeArray == 2)
            {
                inputSizeArray = 5;
            }
            else if (inputSizeArray == 3)
            {
                inputSizeArray = 100;
            }
            else
            {
                inputSizeArray = 500;
            }
            Console.WriteLine();
            return inputSizeArray;
        }
        //Функція у якій виконується перше завдання, заміна рядка на стовпчики
        static public void reversedRowColMinElem(int[,] myArray, int inputSizeArray)
        {
            int rowMinArray = 0, colMinArray = 0, functionCounter = 0;
            int minValue = myArray[0, 0];
            // Знаходження індексу мінімального елементу масиву
            for (int i = 0; i < inputSizeArray; i++)
            {
                for (int j = 0; j < inputSizeArray; j++)
                {
                    if (myArray[i, j] < minValue) // у разі, якщо значення менше то в змінну буде присвоєне нове, менше значення
                    {
                        minValue = myArray[i, j];
                        rowMinArray = j;          // запам'ятовуввання індексів i, j мінімального елемента
                        colMinArray = i;
                    }
                    functionCounter++;
                }
            }
            Console.WriteLine("\nthis is min value in this array " + minValue);

            for (int i = 0; i < inputSizeArray; i++)
            {
                for (int j = 0; j < inputSizeArray; j++)
                {
                    if (i == rowMinArray|| j == colMinArray)// якщо індекс і дорівнюватиме індексу мінімального елементу то відбувається заміна
                    {
                        int temp = 0;
                        temp = myArray[i, j];
                        myArray[i, j] = myArray[j, i];
                        myArray[j, i] = temp;
                    }
                    functionCounter++;
                }
            }

            for (int i = 0; i < inputSizeArray; i++)
            {
                for (int j = 0; j < inputSizeArray; j++)// Вивід обробленого масиву
                {
                    Console.Write(myArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("functionCounter" + functionCounter);
        }
        static public void changeElementsPos(int[,] myArray, int arrSize)
        {
            int temp = 0, tempCounter = 0, highCounter = 0, highTempCounter = 0, counter = 0;
            int functionCounter = 0;
            int middle = arrSize / 2;
            for (int i = 0; i < arrSize; i++)
            {
                tempCounter = 0;
                highCounter = 0;
                for (int j = 0; j < arrSize; j++)
                {
                    highTempCounter = arrSize - 1 - i - j;// ця змінна використовується для верхнього трикутника
                    counter = i - j;// ця змінна використовується для нижнього трикутник
                    if (i + j <= arrSize - 1 && i <= j)//task 1 перестановка елементів місцями за значенням,
                                                       //за допомогою темпової змінної
                    {
                        if (j < middle)
                        {
                            temp = myArray[i, j];
                            myArray[i, j] = myArray[i, j - highCounter + highTempCounter];
                            myArray[i, j - highCounter + highTempCounter] = temp;
                        }
                        Console.Write(myArray[i, j] + "*\t");
                        if (highTempCounter > middle)
                        {
                            highTempCounter--;
                        }
                        highCounter++;
                    }
                    else if (i + j >= arrSize - 1 && i >= j)//task 2, умова для того щоб розглядався лише нижній трикутник
                    {
                        if (j < middle)
                        {
                            temp = myArray[i, j];
                            myArray[i, j] = myArray[i, j + counter - tempCounter];//перестановка елементів місцями за значенням,за 
                            myArray[i, j + counter - tempCounter] = temp;//допомогою темпової змінної, звужується із кожною ітерацією
                        }
                        Console.Write(myArray[i, j] + "**\t");
                        if (tempCounter < i - middle) tempCounter++;
                    }
                    else // вивід елементу масиву який знаходиться поза межами тих елементів, які зазначено у завданні
                    {
                        Console.Write(myArray[i, j] + "\t");
                    }
                    functionCounter++;// лічильник вількості ітерацій
                }
                Console.WriteLine();
            }
            Console.WriteLine("Function Counter" + functionCounter);
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();// ініціалізація  класу для обрахування часу виконання програми
            Random random = new Random();
            int inputSizeArray, chooseTaskNumb;
            chooseTaskNumb = chooseTask();
            inputSizeArray = chooseSizeArray();
            stopwatch.Start();// викликання методу Start для початку відліку часу виконання 
            int[,] myArray = new int[inputSizeArray, inputSizeArray];// ініціалізація масиву
            
            for (int i = 0; i < inputSizeArray; i++)
            {
                for (int j = 0; j < inputSizeArray; j++)
                {
                    myArray[i, j] = random.Next(100);// заповнення елементів масиву рандомними значеннями
                }
            }

            for (int i = 0; i < inputSizeArray; i++)
            {
                for (int j = 0; j < inputSizeArray; j++)
                {
                    Console.Write(myArray[i, j] + "\t"); // вивід масиву із рандомними значеннями
                }
                Console.WriteLine();
            }

            if (chooseTaskNumb == 1)
            {
                Console.WriteLine();
                reversedRowColMinElem(myArray, inputSizeArray);// завдання 1
            }
            else if (chooseTaskNumb == 2)
            {
                Console.WriteLine();
                changeElementsPos(myArray, inputSizeArray);// завдання 2
            }
            stopwatch.Stop();
            Console.WriteLine("time for working" + stopwatch.ElapsedMilliseconds + "ms");// вивід обрахованого часу на виконання
        } 
    }
}
