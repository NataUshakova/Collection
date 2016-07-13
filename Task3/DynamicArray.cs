using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArray : IEnumerable, IEnumerator
    {
        public object[] myArray;

        //конструктор без параметров
        public DynamicArray() { }

        //конструктор с целочисленным параметром
        public DynamicArray(int size)
        {
            myArray = new object[size];
        }
        
        //конструктор по коллекции
        public DynamicArray(IEnumerable<object> collection)
        {
            myArray = new object[collection.Count()];
            myArray = collection.ToArray();
        }

        //метод добавления элемента
        public void Add(object item)
        {
            //если не хватает места
            if (myArray[myArray.Length - 1] != null)
            {
                object[] newArray = new object[myArray.Length];

                //newArray = myArray;
                for (int i = 0; i < myArray.Length; i++)
                {
                    newArray[i] = myArray[i];
                }

                myArray = new object[2 * myArray.Length];

                //myArray = newArray;
                for (int i = 0; i < newArray.Length; i++)
                {
                    myArray[i] = newArray[i];
                }

            }
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == null)
                {
                    myArray[i] = item;
                    break;
                }
            }
        }

        //метод добавления элементов коллекции
        public void AddRange(IEnumerable<object> collection)
        {
            object[] newArray = collection.ToArray();
            int sizeOfCollection = newArray.Length;
            int sizeNullElements = 0;
            object[] endArray;
            int firstNull = myArray.Length;

            //подсчет null элементов в массиве
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == null)
                {
                    sizeNullElements++;
                }
            }
            //если null элементов не хватает
            if (sizeNullElements < sizeOfCollection)
            {
                //увеличиваем размер массива
                endArray = new object[myArray.Length + newArray.Length - sizeNullElements];
            }
            else
            {
                endArray = new object[myArray.Length];
            }

            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == null)
                {
                    firstNull = i;
                    break;
                }
            }
            for (int i = 0; i < firstNull; i++)
            {
                endArray[i] = myArray[i];
            }
            for (int i = firstNull; i < endArray.Length; i++)
            {
                endArray[i] = newArray[i - firstNull];
            }
            myArray = new object[endArray.Length];
            for (int i = 0; i < endArray.Length; i++)
            {
                myArray[i] = endArray[i];
            }
        }

        //метод удаление элемента
        public bool Remove(object o)
        {
            bool indicator = false;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == o)
                {
                    for (int j = i; j < myArray.Length; j++)
                    {
                        myArray[j] = myArray[j + 1];
                    }
                    myArray[myArray.Length - 1] = null;
                    indicator = true;
                }

            }
            return indicator;
        }

        //метод вставки элемента по индексу
        public bool Insert(int index, object o)
        {
            bool indicator = false;
            object[] newArray = new object[myArray.Length + 1];
            try
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    newArray[i] = myArray[i];
                }
                for (int i = newArray.Length - 1; i >= index; i--)
                {
                    newArray[i] = newArray[i - 1];
                }
                newArray[index - 1] = o;
                myArray = new object[newArray.Length];
                for (int i = 0; i < newArray.Length; i++)
                {
                    myArray[i] = newArray[i];
                }
                indicator = true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                indicator = false;
            }
            return indicator;
        }

        public int Length
        {
            get
            {
                int sizeNullElements = 0;
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] == null)
                    {
                        sizeNullElements++;
                    }
                }
                    return myArray.Length - sizeNullElements;
            }
        }

        public int Capacity
        {
            get
            {
                return myArray.Length;
            }
        }

        int index = -1;

        //реализация интерфейса IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        //реализация интерфейса IEnumerator
        public bool MoveNext()
        {
            if (index == myArray.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return myArray[index];
            }
        }

        //индексатор
        public object this[int index]
        {
            set
            {
                try
                {
                    myArray[index] = value;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            get
            {
                try
                {
                    return myArray[index];
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

    }
}
