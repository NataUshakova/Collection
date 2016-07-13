using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class UserInfo
    {
        //метод для заполнения словоря и подсчета слов
        public static Dictionary<string, int> MyDic(string[] arraySplit)
        {
            
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string s in arraySplit)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s] += 1;
                }
                else {
                    dict.Add(s, 1);
                }
            }
            return dict;
        }
    }

    class Program
    {
        private static Dictionary<string, int> dict;
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"..\..\englishText.txt");
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            text = text.ToLower();
            string[] separators = new string[] { " ", ",", "." };
            string[] split = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            dict = UserInfo.MyDic(split);
            foreach (var v in dict)
            {
                Console.WriteLine(v);
            }
            Console.ReadLine();
        }
    }
}