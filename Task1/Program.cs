using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexMin = 0, indexMax = 0;
            double min = 0, max = 0;
            double[,] arrayA = new double [20, 15];
            FormationArray(arrayA);
            OutputArray(ref arrayA);
            SumElemArray(ref min, ref max, ref indexMin, ref indexMax, arrayA);
            OutputResult(min, max, indexMin, indexMax);
            Console.ReadKey();

        }

        // формирование исходного массива
        static void FormationArray(double[,] arrayA)
        {
            double temp;
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 15; j++)
                {
                    temp = Math.Log(1.0 + j);
                    if ( temp == 0 || temp == 1)
                        arrayA[i, j] = 0;
                    else
                        arrayA[i, j] = (i + j) / temp;
                }
        }

        // вывод сформированного массива
        static void OutputArray(ref double[,] arrayA)
        {
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 15; j++)
                    Console.Write("{0: 0.00000}", arrayA[i, j]);
                Console.WriteLine("\n");
            }
        }

        // сумма элементов каждой строки массива, поиск наибольшего и наименьшего числа
        static void SumElemArray(ref double min, ref double max, ref int indexMin, ref int indexMax, double[,] arrayA)
        {
            double[] lines = new double[20];
            double sumElem = 0;
           

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 15; j++)
                    sumElem += arrayA[i, j];
                lines[i] = sumElem;
                sumElem = 0;
            }

            min = lines[0];
            max = lines[0];

            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (min < lines[i + 1])
                {
                    min = lines[i];
                    indexMin = i;
                }
                else if (max > lines[i + 1])
                {
                    max = lines[i + 1];
                    indexMax = i + 1;
                }
            }
        }

        // вывод полученного результата
        static void OutputResult(double min, double max, int indexMin, int indexMax)
        {
            Console.WriteLine("Наименьшая сумма: строка {0}  ее сумма = {1}", indexMin + 1, min);
            Console.WriteLine("Наибольшая сумма: строка {0}  ее сумма = {1}", indexMax + 1, max);

        }

    }
}
