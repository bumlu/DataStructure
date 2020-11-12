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
                if ((index<0 ) || (index>Length))
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
            if (( index > Length) || (index <0))
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
        public void DeleteValueFromTheBegining ()
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
        public void DeleteValueByIndex (int index)
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
        public int GetLength ()
        {
            return Length;
        }

        //индекс по значению 
        public int GetIndexByValue(int value)
        {
            int index = 0;
            Node current = new Node();
            current = _root;

            while ( current.Value != value)
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

        //поиск значения максимального элемента
        public int FindMaxValue()
        {
            Node current = new Node();
            current = _root;
            int max = current.Value;
            do
            {
                if (max < current.Next.Value)
                {
                    max = current.Next.Value;
                   
                }
                current = current.Next;
            }
            while (current.Next != null);
            return max;
        }






    }
}
