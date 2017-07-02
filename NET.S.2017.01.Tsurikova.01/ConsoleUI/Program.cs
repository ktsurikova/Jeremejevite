using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayExtensions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedQ = { 12, 11, 17, 8, 7, 11, 11, 9, 4 };
            int[] unsortedM = { 12, 11, 17, 8, 7, 11, 11, 9, 4 };
            Array.ForEach(unsortedQ, i => { Console.Write("{0} ", i); });
            ArrayExtension.QuickSort(unsortedQ);
            Console.WriteLine("\nQuickSort");
            Array.ForEach(unsortedQ, i => { Console.Write("{0} ", i); });
            ArrayExtension.MergeSort(unsortedM);
            Console.WriteLine("\nMergeSort");
            Array.ForEach(unsortedM, i => { Console.Write("{0} ", i); });

            int [] a = new int[0];
            ArrayExtension.QuickSort(a);
            Console.WriteLine();
            Array.ForEach(a, i => { Console.Write("{0} ", i); });
            ArrayExtension.MergeSort(a);
            Console.WriteLine();
            Array.ForEach(a, i => { Console.Write("{0} ", i); });

            Console.ReadLine();
        }
    }
}
