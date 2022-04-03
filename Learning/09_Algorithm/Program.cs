using System;

namespace _09_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            const int length = 100;
            const int maxValue = 100;
            int[] arr = InitializeArray(length, maxValue);

            WriteArrayConsole(arr, "До сортировки arr:");

            int[] secondArr = SortBubble(arr);
            int[] thirdArr = SystemSort(arr);

            WriteArrayConsole(arr, "После сортировки arr:");
            WriteArrayConsole(secondArr, "После сортировки второй массив secondArr:");
            WriteArrayConsole(secondArr, "После сортировки третий массив thirdArr:");
            Console.ReadKey();
        }

        static int[] InitializeArray(int length, int maxValue)
        {
            var arr = new int[length];
            var rand = new Random();

            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(maxValue);
            }

            return arr;
        }

        static void WriteArrayConsole(int[] arr, string comment)
        {
            Console.WriteLine(comment);
            Console.WriteLine(String.Join(' ', arr));
        }

        static int[] SortBubble(int[] arr)
        {
            //sort bubble
            //массив всегда передается по ссылке
            //поэтому такой код отредактирует исходный массив arr
            //который передается в параметре
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        if (arr[i] > arr[j])
            //        {
            //            int temp = arr[i];
            //            arr[i] = arr[j];
            //            arr[j] = temp;
            //        }
            //    }
            //}

            //если нужно выполнить сортировку на копии
            // и не изменять исходный массив
            //то делают клон и сортируют его:
            int[] cloneArr = (int[])arr.Clone();
            for (int i = 0; i < cloneArr.Length - 1; i++)
            {
                for (int j = i + 1; j < cloneArr.Length; j++)
                {
                    if (cloneArr[i] > cloneArr[j])
                    {
                        int temp = cloneArr[i];
                        cloneArr[i] = cloneArr[j];
                        cloneArr[j] = temp;
                    }
                }
            }

            return cloneArr;
        }

        static int[] SystemSort(int[] arr)
        {
            int[] copyArr = (int[])arr.Clone();
            Array.Sort(copyArr);

            return copyArr;
        }
    }
}
