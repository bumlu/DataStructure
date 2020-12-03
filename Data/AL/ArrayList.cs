using System;
using System.Linq;


namespace DataStructure.AL
{
    public class ArrayList
    {
        // Массив
        public int Length { get; private set; }
        private int[] _array;

        //Длинна 
        public ArrayList(int[] array)
        {
            _array = new int[9];
            Length = 0;
        }


        //Для сравнения объектов двух массивов (чтобы не воспринимал)

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
        public void AddToTheBeginning(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }

            for (int i = Length - 1; i > 1; i--)
            {
                _array[i + 1] = _array[i];
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
                _array[index] = _array[index - 1];
            }
            _array[index] = value;
        }

        //удаление из конца одного элемента
        public void DeleteValueFromTheEnd(int value)
        {
            if (Length == 0)
            {
                throw new Exception("Length=0");
            }
            Length--;
            if (_TrueLenght <= Length)
            {
                DecreaseLenght();
            }
        }
        //удаление из начала одного элемента
        public void DeleteValueFromTheBegining()
        {
            if (Length == 0)
            {
                throw new Exception("Length=0");
            }
            for (int i = 0; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        //удаление по индексу одного элемента
        public void DeleteValueByIndex(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
            }
        }

        // вернуть длину
        public int GetLength()
        {
            int a = Length;
            return a;
        }

        //индекс по значению 
        public int GetIndexByValue(int value)
        {
            int a = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                {
                    a = i + 1;
                }
            }

            return a;
        }

        //реверс  123-321
        public void Revers()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = a;
            }
        }

        //поиск значения максимального элемента
        public int FindMaxValue()
        {
            int max;
            max = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        //поиск значения минимального элемента

        public int FindMinValue()
        {
            int min;
            min = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        //поиск индекс максимального элемента
        public int FindIndexForMaxValue()
        {
            if (Length > 0)
            {
                int maxVal = _array[0];
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] > maxVal)
                    {
                        maxVal = i;
                    }
                }
                return maxVal;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //поиск индекс минимального элемента
        public int FindIndexForMinValue()
        {
            if (Length > 0)
            {
                int minVal = _array[0];
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] < minVal)
                    {
                        minVal = i;
                    }
                }
                return minVal;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        //сортировка по возрастанию
        public void SortMinToMax(int[] array)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int minIndex = _array[i];
                    if (_array[j] > minIndex)
                    {
                        minIndex = _array[j];
                        _array[j] = _array[i];
                        _array[i] = minIndex;
                    }
                }
            }
        }

        //сортировка по убыванию
        public void SortMaxToMin(int[] array)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int minIndex = _array[i];
                    if (_array[j] < minIndex)
                    {
                        minIndex = _array[j];
                        _array[j] = _array[i];
                        _array[i] = minIndex;
                    }
                }
            }
        }

        //удаление по значению первого

        public void DeleteValue(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseLenght();
            }
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                    return;
                }
            }
        }

        //добавление массива в начало

        public void AddArrayToTheBeggining(int[] value)
        {
            if ((Length + value.Length) >= _array.Length)
            {
                IncreaseLenght(value.Length);
            }
            for (int i = 0; i < Length; i++)
            {
                _array[(Length + value.Length) - 1 - i] = _array[Length - 1 - i];
            }
            for (int i = 0; i < value.Length; i++)
            {
                _array[i] = value[i];
            }
            Length += value.Length;
        }


        //добавление массива в начало
        public void AddArrayToTheEnd(int[] value)
        {
            if ((Length + value.Length) >= _array.Length)
            {
                IncreaseLenght(value.Length);
            }

            for (int i = 0; i < value.Length; i++)
            {
                _array[Length + i] = value[i];
            }
            Length += value.Length;
        }


        //добавление массива по индексу



        //удаление из конца N элементов

        public void DeleteFromTheEndByNum(int number)
        {
            for (int i = Length - 1; i >= Length - number; i--)
            {
                _array[i] = 0;
            }
            Length -= number;
        }

        //удаление из начала N элементов
        public void DeleteByNumFromTheBeginning(int number)
        {
            if (number > _array.Length - Length)
            {
                IncreaseLenght(number);
            }
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[number + i];
            }
            Length -= number;
            DecreaseLenght();
        }

        //удаление по индексу N элементов
        public void DeleteNumbeFromIndex(int index, int number)
        {
            if (number > _array.Length - Length)
            {
                IncreaseLenght(number);
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[number + i];
            }
            Length -= number;
            DecreaseLenght();
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

        //  Уменьшение длинны массива на 1/3
        private void DecreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght > 2 * Length + number)
            {
                newLenght = (int)(newLenght * 0.66 + 1);
            }
            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);

            _array = newArray;
        }
    }
    }









        
