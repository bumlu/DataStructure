using NUnit.Framework;
using DataStructure.AL;
using System;


namespace ArrayListTest
{
    public class ArrayListTests
    {

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]

        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, 5)]
        public void AddByIndexTestNegative(int[] array, int index, int value)
        {
            ArrayList a = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => a.AddByIndex(index, value));
        }


        [TestCase(33, new int[3] { 1, 2, 3 }, new int[4] { 1, 2, 3, 33 })]
        [TestCase(33, new int[0] { }, new int[1] { 33 })]
        public void DeleteValueFromTheEndTest(int value, int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.DeleteValueFromTheEnd(value);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(33, new int[] { 1, 2, 3 }, new int[] { 33, 1, 2, 3 })]
        [TestCase(33, new int[] { }, new int[] { 33 })]
        [TestCase(33, new int[3] { 0, 0, 0 }, new int[4] { 33, 0, 0, 0 })]
        public void DeleteValueFromTheBeginingTest(int value, int[] array, int[] expArr)
        {
            ArrayList expected = new ArrayList(expArr);
            ArrayList actual = new ArrayList(array);
            actual.DeleteValueFromTheBegining();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4, })]
        public void DeleteValueByIndexTest(int[] array, int index, int[] exArray)
        {
            ArrayList expected = new ArrayList(exArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteValueByIndex(index);

            Assert.AreEqual(expected, actual);

        }
        //вернуть длину
        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetLength();

            Assert.AreEqual(expected, actual);
        }

        //доступ по индексу
        //[TestCase(new int[] { 1, 2, 3, 4 }, 3, 4)]
        //public void GetByIndexTest(int[] array, int index, int expected)
        //{
        //    ArrayList a = new ArrayList(array);
        //    int actual = a [index];

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestCase(new int[] { 1, 2, 3, 4 }, 7)]
        //public void GetByIndexTestNegative(int[] array, int index)
        //{
        //    ArrayList a = new ArrayList(array);
        //    Assert.Throws<IndexOutOfRangeException>(() => a[index]++);
        //}

        //индекс по значению 
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 2)]
        [TestCase(new int[] { 1 }, 1, 0)]
        public void GetIndexByValueTest(int[] array, int value, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 7)]
        public void GetIndexByValueTestNegative(int[] array, int value)
        {
            ArrayList a = new ArrayList(array);
            int index = 0;
            Assert.Throws<NullReferenceException>(() => a.GetIndexByValue(value));
        }

        //изменение по индексу

        // [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 8, new int[] { 1, 2, 3, 8, 5 })]
        // [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 8, new int[] { 8, 2, 3, 4, 5 })]
        // [TestCase(new int[] { 0 }, 0, 8, new int[] { 8 })]
        //    public void EditByIndexTest(int[] array, int index, int value, int[] expArray)
        //{
        //    ArrayList expected = new ArrayList(expArray);
        //    ArrayList actual = new ArrayList(array);
        //     int a = actual.EditByIndex (index, value);
        //     Assert.AreEqual(expected, actual);
        //}


        // реверс (123 -> 321)
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 6, 1, 3, 6, 1 }, new int[] { 1, 6, 3, 1, 6 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReversTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Revers();

            Assert.AreEqual(expected, actual);
        }


        //поиск значения максимального элемента

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        public void FindMaxValueTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.FindMaxValue();

            Assert.AreEqual(expected, actual);
        }

        //поиск значения минимального элемента

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 6, 2, 3, 4 }, 2)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        public void FindMinValueTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.FindMinValue();

            Assert.AreEqual(expected, actual);
        }

        //поиск индекс максимального элемента
        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 6, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]

        public void FindIndexForMaxValueTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.FindIndexForMaxValue();
            Assert.AreEqual(expected, actual);

        }

        //поиск индекс минимального элемента
        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 6, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]

        public void FindIndexForMinValueTest(int[] array, int expected)
        {
            ArrayList a = new ArrayList(array);
            int actual = a.FindIndexForMinValue();
            Assert.AreEqual(expected, actual);
        }

        //сортировка по возрастанию
        //[TestCase(new int[] { 9, 1, 4 }, new int[] { 1, 4, 9 })]
        //[TestCase(new int[] { }, new int[] { })]
        //[TestCase(new int[] { 9, 1, 0 }, new int[] { 0, 1, 9 })]
        //[TestCase(new int[] { 9, 1, 0, -5 }, new int[] { -5, 0, 1, 9 })]
        //[TestCase(new int[] { 0, 0, 1, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 1 })]
        //public void SortMinToMaxTest(int[] array, int[] expArray)
        //{
        //    ArrayList actual = new ArrayList(array);
        //    ArrayList expected = new ArrayList(expArray);
        //    int a = actual.SortMinToMax ();
        //    Assert.AreEqual(expected, a);
        //}

        //сортировка по убыванию
        //    [TestCase(new int[] { 0, 17, 3 }, new int[] { 17, 3, 0 })]
        //[TestCase(new int[] { 9, 1, 0, -5 }, new int[] { 9, 1, 0, -5 })]
        //[TestCase(new int[] { 9, 1, 0 }, new int[] { 9, 1, 0 })]
        //[TestCase(new int[] { 0, 0, 1, 0, 0, 0 }, new int[] { 1, 0, 0, 0, 0, 0 })]
        //[TestCase(new int[] { }, new int[] { })]
        //    public void SortMaxToMinTest(int[] array, int[] expArray)
        //    {
        //        ArrayList actual = new ArrayList(array);
        //        ArrayList expected = new ArrayList(expArray);
        //        int actual = actual.SortMaxToMin ();
        //        Assert.AreEqual(expected, actual);
    }

    //удаление по значению первого

    //[TestCase(new int[] { 5, 2, 57, 8, 4, 2 }, 5, new int[] { 2, 57, 8, 4, 2 })]
    //[TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 3, 4 })]
    //[TestCase(new int[] { 6, 2, 3, 4 }, 0, new int[] { 6, 2, 3, 4 })]
    //[TestCase(new int[] { 1 }, 1, new int[] { })]
    //[TestCase(new int[] { }, 0, new int[] { })]

    //public void DeleteValueTest(int[] array, int value, int[] exArray)
    //{
    //    ArrayList a = new ArrayList(array);
    //    ArrayList expected = new ArrayList(exArray);
    //    a.DeleteValue(value);
    //    Assert.AreEqual(expected, a);
    //}



    //добавление массива в конец

    //[TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4 })]
    //[TestCase(new int[] { 6, 2, 3, 4, 3 }, new int[] { 3 }, new int[] { 6, 2, 3, 4, 3, 3 })]
    //[TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
    //[TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2 }, new int[] { 2, 2, 2, 2, 2 })]
    //public void AddArrayToTheEndTest(int[] array, int[] arrayAdd, int[] exArray)
    //{
    //    ArrayList a = new ArrayList(array);
    //    ArrayList expected = new ArrayList(exArray);
    //    a.AddArrayToTheEnd(arrayAdd);
    //    Assert.AreEqual(expected, a);
    //}

    //    //добавление массива в начало

    //    [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 1, 1 }, new int[] { 1, 2, 3, 1, 1, 1 })]
    //    [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 0, 0, 0, 1, 2, 3 })]
    //    [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
    //    [TestCase(new int[] { }, new int[] { }, new int[] { })]
    //    public void AddArrayToTheBegginingTest(int[] array, int[] arrayAdd, int[] exArray)
    //{
    //    ArrayList a = new ArrayList(array);
    //    ArrayList expected = new ArrayList(exArray);
    //    a.AddArrayToTheBeggining(arrayAdd);
    //    Assert.AreEqual(expected, a);
    //}

    //добавление массива по индексу
    //удаление из конца N элементов

    //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, new int[] { 1, 2, 3 })]
    //    [TestCase(new int[] { 0, 0, 0 }, 1, new int[] { 0, 0 })]
    //    [TestCase(new int[] { 1 }, 1, new int[] { })]
    //    [TestCase(new int[] { 1 }, 0, new int[] { 1 })]
    //    public void DeleteFromTheEndByNumTest(int[] array, int number, int[] exArray)
    //{
    //    ArrayList expected = new ArrayList(exArray);
    //    ArrayList a = new ArrayList(array);
    //    a.DeleteFromTheEndByNum(number);
    //    Assert.AreEqual(expected, a);

    //}
    //    //удаление из начала N элементов
    //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, new int[] { 4, 5, 6 })]
    //    [TestCase(new int[] { 1 }, 1, new int[] { })]
    //    [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { })]
    //    [TestCase(new int[] { 1 }, 0, new int[] { 1 })]
    //    public void DeleteByNumFromTheBeginningTest(int[] array, int number, int[] exArray)
    //{
    //    ArrayList expected = new ArrayList(exArray);
    //    ArrayList a = new ArrayList(array);
    //    a.DeleteByNumFromTheBeginning(number);
    //    Assert.AreEqual(expected, a);
    //}
    //    //удаление по индексу N элементов
    //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 2, new int[] { 1, 2, 6 })]
    //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 0, new int[] { 4, 5, 6 })]
    //    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 3, new int[] { 1, 2, 3 })]
    //    [TestCase(new int[] { 1 }, 1, 0, new int[] { })]
    //    [TestCase(new int[] { 1 }, 0, 0, new int[] { 1 })]
    //    public void DeleteNumbeFromIndexTest(int[] array, int index, int number, int[] exArray)
    //{
    //    ArrayList expected = new ArrayList(exArray);
    //    ArrayList a = new ArrayList(array);
    //    a.DeleteNumbeFromIndex(index, number);
    //    Assert.AreEqual(expected, a);
}
