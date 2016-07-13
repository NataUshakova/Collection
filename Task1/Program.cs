using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task1
{


    class Program
    {
        //вывод списка
        static void PrintList(IEnumerable<int> list)
        {
            foreach (var item in list)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("N = ");
            //количество человек
            int N = Int32.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int j = 0; j < N; j++)
            {
                array[j] = j + 1;
            }
            List<int> MyList = new List<int>(array);
            PrintList(MyList);
            bool delete = false;
            while (MyList.Count > 1)
            {
                for (int i = 0; i < MyList.Count; i++)
                {
                    if (delete) MyList.RemoveAt(i--);
                    delete = !delete;
                }
                PrintList(MyList);
            }
            Console.Read();
        }
    }
}
