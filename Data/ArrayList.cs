using System;
using System.Linq;

namespace Data
{
    public class ArrayList
    {
        // Массив
        public int Length { get; private set; }
        private int[] _array;

        //Длинна 
        public ArrayList()
        {
            _array = new int[9];
            Lengt = 0;
        }

        // Фактическая длинна
        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }

        // Методы добавление значения в конец

        private void AddToTheEnd(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            _array[Length] = value;
            Length++;
        }

        // Увеличение длинны массива на 1/3%

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= Length + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);

            _array = newArray;
        }

        //Для сравнения объектов двух массивов (чтобы не воспринимал

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        //запись позволяет выводить листы просто одной линией
        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }

        //добавление значения в начало
        public void AddToTheBeginning (int value)
        { 
           if (_TrueLenght <= Length)
                {
                    IncreaseLenght();
                }

            for (int i = Length-1; i > 1; i--)
            {
                _array[i+1] = _array[i];
            }
            _array[0] = value;
        }

        //добавление значения по индексу
        public void AddByIndex(int value, int index)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }

            for (int i = Length; i > index; i--)
            {
                _array[index] = _array[index-1];
            }
            _array[index] = value;
        }

        //удаление из конца одного элемента
        public void DeleteValueFromTheEnd (int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }

              


            //удаление из начала одного элемента
        }



}
