using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dinArr = new DynamicArray(10);
            for (int i =0; i<dinArr.Capacity-2; i++)
            {
                dinArr[i] = "Элемент" + (i+1);
            }
            Console.WriteLine("Емкость = {0}", dinArr.Capacity);
            Console.WriteLine("Длина = {0}", dinArr.Length);

            for (int i = 0; i < dinArr.Capacity ; i++)
            {
                Console.WriteLine(dinArr[i]);
            }

            dinArr.Add("новый элемент");
            for (int i = 0; i < dinArr.Capacity; i++)
            {
                Console.WriteLine(dinArr[i]);
            }
            
            Console.ReadLine();

        }
    }
}
