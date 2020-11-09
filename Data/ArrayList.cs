using System;

namespace Data
{
    public class ArrayList
    {
        // Массив
        public int Lenght { get; private set; }
        private int[] _array;

        //Длинна 
        public ArrayList()
        {
            _array = new int[9];
            Lenght = 0;
        }

        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }

        public void Add(int value)
        {
            if (_TrueLenght <= Lenght)
            {
                IncreaseLenght();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= Lenght + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);

            _array = newArray;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Lenght; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        // Методы добавление значения в конец


    }
}
