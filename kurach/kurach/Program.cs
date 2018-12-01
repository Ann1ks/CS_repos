using System;
using System.IO;

namespace kusrach
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 4;
            int[,] array = new int[n,n];
            int[,] secondArray = new int[n, n];
            int sum=0;
            int min;
            double z;

            for (int i=0;i<n;i++)//ввод массива с клавиатуры
            {
                Console.WriteLine($"\t Введите элементы {i} строки:");
                Console.WriteLine("-----------------------------------------");
                for(int j=0;j<n;j++)
                {
                    Console.Write($"\t Введите элемент {j} для {i} строки:");
                    array[i,j] = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < n; i++)//заполнение второго массива
            {
                for (int j = 0; j < n; j++)
                {
                    secondArray[i, j] = (int)Math.Pow(array[i,j],3);
                }
            }

            Console.Clear();//очистка консоли

            Console.WriteLine("-----Первый массив-----\n");

            for (int i = 0; i < n; i++)//вывод массива 
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]}"+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n-----Второй массив-----\n");

            for (int i = 0; i < n; i++)//вывод второго массива 
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{secondArray[i, j]}" + " ");
                }
                Console.WriteLine();
            }

            for(int i = 0; i<n; i+=2)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += secondArray[i, j];
                }
            }
            Console.WriteLine("\n-----------Результат обработки данных второго массива-----------");
            Console.WriteLine($"\nСумма элементов четных строк массива={sum}");

            min = secondArray[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (min>secondArray[i,j])
                        min = secondArray[i, j];
                }
            }
            Console.WriteLine($"Минимальный элемент в матрице:{min}");
            double a = sum;
            //Math.Sqrt(a) - Math.Sqrt(2) / a + 2;
            z = ((a + 2 / Math.Sqrt(2 * a)) - (a / Math.Sqrt(2 * a)+2) + (2/(a- Math.Sqrt(2 * a)))) * (Math.Sqrt(a) - Math.Sqrt(2) / a + 2);
            Console.WriteLine($"Значение выражения = {z}");
            ///////вывод в файл
            
            string fileName = "MyFile.txt";//здесь пишешь путь файла, где хочешь его видеть. Например "E:\Repos\project\имя_файла" этот файл будет в папке проекта->bin->debug
            FileStream aFile = new FileStream(fileName, FileMode.Create);
            StreamWriter file = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);

            file.WriteLine("Первый массив\n");
             
            for (int i = 0; i < n; i++)//вывод массива в файл
            {
                for (int j = 0; j < n; j++)
                {
                    file.Write($"{array[i, j]}" + " ");
                }
                file.WriteLine();
            }

            file.WriteLine("\nВторой массив");

            for (int i = 0; i < n; i++)//вывод второго массива в файл
            {
                for (int j = 0; j < n; j++)
                {
                    file.Write($"{secondArray[i, j]}" + " ");
                }
                file.WriteLine();
            }

            file.WriteLine($"\nСумма элементов четных строк массива={sum}");
            file.WriteLine($"Минимальный элемент в матрице:{min}");
            file.WriteLine($"Значение выражения = {z}");

            file.Close();
        }
    }
}
