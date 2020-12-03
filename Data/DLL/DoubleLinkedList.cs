using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DLL
{
    public class DoubleLinkedList
    {

        //длина
        public int Length { get; protected set; }

        private DNode head;
        private DNode tail;

        public int this[int index]
        {
            get  //получение/доступ по индексу
            {
                DNode tmp = head;
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int worseCase = (Length / 2 + 1);
                    if (index < worseCase)
                    {
                        
                        for (int i = 1; i <= index; i++)
                        {
                            tmp = tmp.Next;
                        }

                     }
                    return tmp.Value;
                }
            }


            set // замена по индексу или изменение по индексу

            {
                if ((index < 0) || (index > Length))
                {
                    throw new IndexOutOfRangeException();
                }
                DNode tmp = head;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        //3 конструктора
        public DoubleLinkedList()
        {
            Length = 0;
            head = null;
            tail = null;
        }

       
        public DoubleLinkedList(int value)
        {
            head = new DNode(value);
            Length = 1;
            tail = head;
        }

        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                head = new DNode(array[0]);
                DNode current = head;

                for (int i = 1; i < array.Length; i++)
                {
                    current.Next = new DNode(array[i]);
                    current.Next.Prev = current.Next;
                    current = current.Next;
                }

                tail = current;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                head = null;
                tail = null;
            }
        }

        public void DeleteValueByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, int value)
        {
            if ((index > Length) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                DNode tmp = head;
                head = new DNode(value);
                head.Next = tmp;
                tmp.Next = head;

            }
            else
            {
                DNode current = head;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                DNode tmp = current.Next;
                current.Next = new DNode(value);

                current.Next.Next = tmp;
            }
            Length++;
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public void DeleteValueFromTheEnd()
        {
            if (Length == 0)
            {
                return;
            }
            tail = tail.Prev;
            tail.Next = null;           
            Length--;
        }

        public int GetIndexByValue(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteValueFromTheBegining()
        {

        }

        public void Revers()
        {
            throw new NotImplementedException();
        }

        public int FindMaxValue()
        {
            throw new NotImplementedException();
        }

        public int FindMinValue()
        {
            throw new NotImplementedException();
        }

        public int FindIndexForMaxValue()
        {
            throw new NotImplementedException();
        }

        public int FindIndexForMinValue()
        {
            throw new NotImplementedException();
        }

        public void DeleteValue(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllValues(int value)
        {
            throw new NotImplementedException();
        }

        public void AddArrayToTheEnd(int[] arrayAdd)
        {
            throw new NotImplementedException();
        }

        public void AddArrayToTheBeggining(int[] arrayAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromTheEndByNum(int number)
        {
            throw new NotImplementedException();
        }

        public void DeleteByNumFromTheBeginning(int number)
        {
            throw new NotImplementedException();
        }

        public void DeleteNumbeFromIndex(int index, int number)
        {
            throw new NotImplementedException();
        }
    }
    }



        
    


        

    
   
