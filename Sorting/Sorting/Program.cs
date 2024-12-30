using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Program
    {
        static void BubbleSort(int[] arr)
        {
            if (arr == null) return;

            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j+1] = temp;
                    }
                }
            }

            PrintArray(arr);
        }

        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                        break;
                    }
                }

                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            PrintArray(arr);
        }

        static void PrintArray(int[] arr)
        {
            foreach(int ele in arr){
                Console.Write(ele + ",");
            }

            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int[] arr = { 3, 1, 5, 2, 0, 4 };

            Console.Write("Unsorted Array: ");

            foreach (var item in arr)
            {
                Console.Write(item + ", ");
            }

            Console.Write("Sorted Array using Bubble Sort: ");
            BubbleSort(arr);

            Console.Write("Sorted Array using Selection Sort: ");
            SelectionSort(arr);


            Console.ReadKey();
        }
    }
}
