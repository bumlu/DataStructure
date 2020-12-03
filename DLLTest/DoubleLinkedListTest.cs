using NUnit.Framework;
using DataStructure.DLL;
using System;


namespace DoubleDoubleLinkedListTest
{
    public class DoubleDoubleLinkedListTest
   {
        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]

        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
    
    [TestCase(new int[] { 1, 2, 3 }, 4, 5)]
    public void AddByIndexTestNegative (int[] array, int index, int value)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        Assert.Throws<IndexOutOfRangeException>(() => a.AddByIndex(index, value));
    }


    [TestCase(new int[] { 1, 2, 3, 4, 2 }, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { }, new int[] { })]
    [TestCase(new int[] { 1 }, new int[] { })]
    public void DeleteValueFromTheEndTest(int[] array, int[] expArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(expArray);
        DoubleLinkedList actual = new DoubleLinkedList(array);
        actual.DeleteValueFromTheEnd();

        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
    [TestCase(new int[] { 0, 2, 3, }, new int[] { 2, 3 })]
    public void DeleteValueFromTheBeginingTest(int[] array, int[] expArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(expArray);
        DoubleLinkedList actual = new DoubleLinkedList(array);
        actual.DeleteValueFromTheBegining();

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
    [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4, })]
    public void DeleteValueByIndexTest(int[] array, int index, int[] exArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        DoubleLinkedList actual = new DoubleLinkedList(array);
        actual.DeleteValueByIndex(index);

        Assert.AreEqual(expected, actual);

    }
    //������� �����
    [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
    [TestCase(new int[] { }, 0)]
    public void GetLengthTest(int[] array, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.GetLength();

        Assert.AreEqual(expected, actual);
    }

    //������ �� �������
    [TestCase(new int[] { 1, 2, 3, 4 }, 3, 4)]
    public void GetByIndexTest(int[] array, int index, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a[index];

        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4 }, 7)]
    public void GetByIndexTestNegative(int[] array, int index)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        Assert.Throws<IndexOutOfRangeException>(() => a[index]++);
    }

    //������ �� �������� 
    [TestCase(new int[] { 1, 2, 3, 4 }, 3, 2)]
    [TestCase(new int[] { 1 }, 1, 0)]
    public void GetIndexByValueTest(int[] array, int value, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.GetIndexByValue(value);

        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4 }, 7)]
    public void GetIndexByValueTestNegative(int[] array, int value)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int index = 0;
        Assert.Throws<NullReferenceException>(() => a.GetIndexByValue(value));
    }

    //��������� �� �������

    [TestCase(new int[] { 1, 2, 3, 4 }, 3, 7, new int[] { 1, 2, 3, 7 })]
    public void EditByIndexTest(int[] array, int index, int value, int[] expArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(expArray);
        DoubleLinkedList actual = new DoubleLinkedList(array);

        actual[index] = value;

        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] { 1, 2, 3, 4 }, 7, 0)]
    public void EditByIndexTestNegative(int[] array, int index, int value)
    {
        DoubleLinkedList actual = new DoubleLinkedList(array);
        Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
    }

    // ������ (123 -> 321)
    [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
    [TestCase(new int[] { 6, 1, 3, 6, 1 }, new int[] { 1, 6, 3, 1, 6 })]
    [TestCase(new int[] { 1 }, new int[] { 1 })]
    public void ReversTest(int[] array, int[] expArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(expArray);
        DoubleLinkedList actual = new DoubleLinkedList(array);
        actual.Revers();

        Assert.AreEqual(expected, actual);
    }


    //����� �������� ������������� ��������

    [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
    [TestCase(new int[] { 1 }, 1)]
    [TestCase(new int[] { 0 }, 0)]
    public void FindMaxValueTest(int[] array, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.FindMaxValue();

        Assert.AreEqual(expected, actual);
    }

    //����� �������� ������������ ��������

    [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
    [TestCase(new int[] { 6, 2, 3, 4 }, 2)]
    [TestCase(new int[] { 1 }, 1)]
    [TestCase(new int[] { 0 }, 0)]
    public void FindMinValueTest(int[] array, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.FindMinValue();

        Assert.AreEqual(expected, actual);
    }

    //����� ������ ������������� ��������
    [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
    [TestCase(new int[] { 6, 2, 3, 4 }, 0)]
    [TestCase(new int[] { 1 }, 0)]
    [TestCase(new int[] { 0 }, 0)]

    public void FindIndexForMaxValueTest(int[] array, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.FindIndexForMaxValue();
        Assert.AreEqual(expected, actual);

    }

    //����� ������ ������������ ��������
    [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
    [TestCase(new int[] { 6, 2, 3, 4 }, 1)]
    [TestCase(new int[] { 1 }, 0)]
    [TestCase(new int[] { 0 }, 0)]

    public void FindIndexForMinValueTest(int[] array, int expected)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        int actual = a.FindIndexForMinValue();
        Assert.AreEqual(expected, actual);
    }

    //���������� �� �����������

    //���������� �� ��������

    //�������� �� �������� �������

    [TestCase(new int[] { 5, 2, 57, 8, 4, 2 }, 5, new int[] { 2, 57, 8, 4, 2 })]
    [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4 }, 0, new int[] { 6, 2, 3, 4 })]
    [TestCase(new int[] { 1 }, 1, new int[] { })]
    [TestCase(new int[] { }, 0, new int[] { })]

    public void DeleteValueTest(int[] array, int value, int[] exArray)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        a.DeleteValue(value);
        Assert.AreEqual(expected, a);
    }

    //�������� �� �������� ����
    [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4, 3 }, 3, new int[] { 6, 2, 4 })]
    [TestCase(new int[] { 1 }, 1, new int[] { })]
    [TestCase(new int[] { 2, 2, 2, 2 }, 2, new int[] { })]

    public void DeleteAllValuesTest(int[] array, int value, int[] exArray)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        a.DeleteAllValues(value);
        Assert.AreEqual(expected, a);
    }

    //���������� ������� � �����

    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4, 3 }, new int[] { 3 }, new int[] { 6, 2, 3, 4, 3, 3 })]
    [TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
    [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2 }, new int[] { 2, 2, 2, 2, 2 })]
    public void AddArrayToTheEndTest(int[] array, int[] arrayAdd, int[] exArray)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        a.AddArrayToTheEnd(arrayAdd);
        Assert.AreEqual(expected, a);
    }

    //���������� ������� � ������

    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 1, 2, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4, 3 }, new int[] { 3 }, new int[] { 3, 6, 2, 3, 4, 3 })]
    [TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
    [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2 }, new int[] { 2, 2, 2, 2, 2 })]
    public void AddArrayToTheBegginingTest(int[] array, int[] arrayAdd, int[] exArray)
    {
        DoubleLinkedList a = new DoubleLinkedList(array);
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        a.AddArrayToTheBeggining(arrayAdd);
        Assert.AreEqual(expected, a);
    }

    //���������� ������� �� �������
    //�������� �� ����� N ���������

    [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4 }, 3, new int[] { 6 })]
    [TestCase(new int[] { 1 }, 1, new int[] { })]
    [TestCase(new int[] { 6, 2, 56, 2 }, 2, new int[] { 6, 2 })]
    public void DeleteFromTheEndByNumTest(int[] array, int number, int[] exArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        DoubleLinkedList a = new DoubleLinkedList(array);
        a.DeleteFromTheEndByNum(number);
        Assert.AreEqual(expected, a);

    }
    //�������� �� ������ N ���������
    [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 1, 2, 3, 4 })]
    [TestCase(new int[] { 6, 2, 3, 4 }, 3, new int[] { 4 })]
    [TestCase(new int[] { 1 }, 1, new int[] { })]
    [TestCase(new int[] { 6, 2, 56, 2 }, 2, new int[] { 56, 2 })]
    public void DeleteByNumFromTheBeginningTest(int[] array, int number, int[] exArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        DoubleLinkedList a = new DoubleLinkedList(array);
        a.DeleteByNumFromTheBeginning(number);
        Assert.AreEqual(expected, a);
    }
    //�������� �� ������� N ���������
    [TestCase(new int[] { 1, 2, 3, 4 }, 1, 3, new int[] { 1 })]
    [TestCase(new int[] { 6, 2, 3, 4, 46, 1, 5 }, 3, 1, new int[] { 6, 2, 3, 46, 1, 5 })]
    [TestCase(new int[] { 1 }, 0, 1, new int[] { })]
    [TestCase(new int[] { 6, 2, 56, 2 }, 2, 0, new int[] { 6, 2, 56, 2 })]
    public void DeleteNumbeFromIndexTest(int[] array, int index, int number, int[] exArray)
    {
        DoubleLinkedList expected = new DoubleLinkedList(exArray);
        DoubleLinkedList a = new DoubleLinkedList(array);
        a.DeleteNumbeFromIndex(index, number);
        Assert.AreEqual(expected, a);
    }
}
}