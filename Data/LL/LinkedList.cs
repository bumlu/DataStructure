using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DataStructure.LL

{
    public class LinkedList
    {

        //длина
        public int Length { get; set; }

        private Node _root;


        public int this[int index]
        {
            get  //получение/доступ по индексу
            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set // замена по индексу или изменение по индексу

            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        //3 конструктора
        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        //добавление значения по индексу

        public void AddByIndex(int index, int value)
        {
            if ((index > Length) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);

                current.Next.Next = tmp;
            }
            Length++;
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            //for (int i = 0; i < Length; i++)
            //{
            //    if(this[i]!=linkedList[i])
            //    {
            //        return false;
            //    }
            //}

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        // вывод для сравнения
        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
        // удаление из конца одного элемента
        public void DeleteValueFromTheEnd()
        {
            if (Length == 0)
            {
                return;
            }
            Node current = _root;
            for (int i = 1; i < Length - 1; i++)
            {
                current = current.Next;
            }
            current.Next = null;
            Length--;

        }
        //удаление из начала одного элемента
        public void DeleteValueFromTheBegining()
        {
            if (Length == 0)
            {
                return;
            }

            Node current = _root.Next;
            _root = current;

            Length--;
        }

        //удаление по индексу одного элемента
        public void DeleteValueByIndex(int index)
        {
            Node current = _root;
            if (index == 0)
            {
                Node tmp = new Node();
                tmp = _root.Next;
                _root = tmp;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
            }
            current.Next = current.Next.Next;
            Length--;
            //нашл циклом предыдущее значение и перезаписали ссылку на следующее
        }

        // вернуть длину
        public int GetLength()
        {
            return Length;
        }

        //индекс по значению 
        public int GetIndexByValue(int value)
        {
            int index = 0;
            Node current = new Node();
            current = _root;

            while (current.Value != value)
            {
                index++;
                current = current.Next;
                if (current.Next == null)
                {
                    throw new NullReferenceException();
                }
            }
            return index;
        }


        //реверс(123 -> 321)

        public void Revers()
        {
            Node current = _root;
            Node Next;
            Node pref = null;

            while (current != null)
            {
                Next = current.Next;
                current.Next = pref;
                pref = current;
                current = Next;
            }
            _root = pref;
        }



        //поиск значения максимального элемента
        public int FindMaxValue()
        {
            Node current = new Node();
            current = _root;
            int max = current.Value;
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            do
            {
                if ((current.Next != null) && (max < current.Next.Value))
                {
                    max = current.Next.Value;

                }
                if (current.Next != null)
                {
                    current = current.Next;
                }
            }
            while (current.Next != null);
            return max;
        }
        //поиск значения минимального элемента

        public int FindMinValue()
        {
            Node current = new Node();
            current = _root;
            int min = current.Value;
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            do
            {
                if ((current.Next != null) && (min > current.Next.Value))
                {
                    min = current.Next.Value;

                }
                if (current.Next != null)
                {
                    current = current.Next;
                }
            }
            while (current.Next != null);
            return min;
        }
        //поиск индекс максимального элемента
        public int FindIndexForMaxValue()
        {
            Node current = new Node();
            current = _root;
            int max = current.Value;
            int index = 0;
            int indexMax = index;

            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            do
            {
                if ((current.Next != null) && (max < current.Next.Value))
                {
                    max = current.Next.Value;
                    index = index + 1;
                }
                if (current.Next != null)
                {
                    current = current.Next;
                    indexMax++;
                }
            }
            while (current.Next != null);

            return index;
        }

        //поиск индекс минимального элемента
        public int FindIndexForMinValue()
        {
            Node current = new Node();
            current = _root;
            int min = current.Value;
            int index = 0;
            int indexMin = index;

            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            do
            {
                if ((current.Next != null) && (min > current.Next.Value))
                {
                    min = current.Next.Value;
                    index = index + 1;
                }
                if (current.Next != null)
                {
                    current = current.Next;
                    indexMin++;
                }
            }
            while (current.Next != null);

            return index;
        }

        //сортировка по возрастанию


        //сортировка по убыванию

        //удаление по значению первого

        public void DeleteValue(int value)
        {
            if (_root == null) return;

            Node current = _root;

            if (_root.Value == value)
            {
                _root = _root.Next;
                Length--;
                return;
            }

            while (current.Next.Value != value)
            {
                current = current.Next;
                if (current.Next == null) return;
            }

            current.Next = current.Next.Next;
            Length--;

        }

        //удаление по значению всех

        public void DeleteAllValues(int value)
        {

            if (_root != null && _root.Value == value)
            {
                _root = _root.Next;

            }
            Node current = _root;
            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    Length--;
                }
                current = current.Next;
                if (current == null) return;
            }

        }


        //добавление массива в конец

        //public void AddArrayToTheEnd(int [] array)
        //{
        //    if (array.Length <= Length)
        //        {
        //            IncreaseLength(array.Length);
        //            Length += argumentArray.Length;
        //        }
        //        for (int i = Length - argumentArray.Length; i < Length; i++)
        //        {
        //            array[i] = argumentArray[i - (Length - argumentArray.Length)];
        //        }
            
           
        //}

        //добавление массива в начало
        public void AddArrayToTheBeggining(int[] array)
        {
           
            LinkedList KK = new LinkedList(array);
            Node currentKK = KK._root;
            if (Length == 0)
            {
                _root = KK._root;
            }
            else
            {
                while (currentKK.Next != null)
                {
                    currentKK = currentKK.Next;
                }
                currentKK.Next = _root;
                _root = KK._root;
            }
            Length += array.Length;
        }

        //добавление массива по индексу

        //удаление из конца N элементов

        public void DeleteFromTheEndByNum (int number)
            {
                if ((number <= Length) && ( number > 0))
                {
                    if ( number == Length )
                    {
                        _root = null;
                        Length = 0;
                    }
                    else if (Length- number == 1)
                    {
                        _root.Next = null;
                        Length = 1;
                    }
                    else
                    {
                        Node current = _root;
                       for (int i = 1; i < Length - number; i++)
                        { 
                            current = current.Next;
                        }

                        current.Next = null;
                        Length -= number;
                    }
                }
                
            }

        //удаление из начала N элементов
        public void DeleteByNumFromTheBeginning(int number)
        {
            if ((number <= Length) && (number > 0))
            {
                if (number == Length)
                {
                    _root = null;
                    Length = 0;
                }
                else
                {
                    Node current = _root.Next;
                    for (int i = 1; i < number; i++)
                    {
                        current = current.Next;
                    }
                    _root = current;
                    Length -= number;

                }
            }
        }

            //удаление по индексу N элементов
            public void DeleteNumbeFromIndex (int index, int number)
            {
            Node current = _root;
            if (index == 0) 
            {
                DeleteByNumFromTheBeginning(number);
            }

            else 
            {

                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                Node currentT = current.Next;
                for (int j = 0; j < number; j++)
                {
                    currentT = currentT.Next;

                }
                current.Next = currentT;
                Length = Length - number;
            }

            }
        }
   }

    

            

          






