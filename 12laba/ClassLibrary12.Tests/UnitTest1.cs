using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary12;
using System;
using System.Linq;

namespace ClassLibrary12.Tests
{ 
    [TestClass]
    public class UnitTest1
    {
        // ������������ ���������� �������� � ���������
        [TestMethod]
        public void TestAdd()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            Assert.AreEqual(1, collection.Count); // ���������, ��� ���������� ��������� ����� ���������� ������ ����� 1
        }

        // ������������ ���������� ���������� ��������� � ���������
        [TestMethod]
        public void TestAddRange()
        {
            var collection = new MyCollection<string>();
            collection.AddRange(new[] { "A", "B", "C" });
            Assert.AreEqual(3, collection.Count); // ���������, ��� ���������� ��������� ����� ���������� ���� ����� 3
        }

        // ������������ �������� ������ �������� �� ���������
        [TestMethod]
        public void TestRemove()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            collection.Add("B");
            var result = collection.Remove("A");
            Assert.IsTrue(result); // ���������, ��� ������� ��� ������� ������
            Assert.AreEqual(1, collection.Count); // ���������, ��� ���������� ��������� �����������
        }

        // ������������ �������� ���������� ��������� �� ���������
        [TestMethod]
        public void TestRemoveRange()
        {
            var collection = new MyCollection<string>();
            collection.AddRange(new[] { "A", "B", "C" });
            collection.RemoveRange(new[] { "A", "C" });
            Assert.AreEqual(1, collection.Count); // ���������, ��� �������� ������ 1 �������
            Assert.IsFalse(collection.Contains("A")); // ���������, ��� "A" ������
            Assert.IsFalse(collection.Contains("C")); // ���������, ��� "C" ������
        }

        // ������������ ������ �������� � ���������
        [TestMethod]
        public void TestContains()
        {
            var collection = new MyCollection<Person>();

            var person1 = new Person { name = "���������� ��������", gender = "�������", age = 30 };
            var person2 = new Person { name = "������ �������", gender = "�������", age = 25 };

            collection.Add(person1);
            collection.Add(person2);

            // ���������, ��� person1 ���������� � ���������
            Assert.IsTrue(collection.Contains(person1));

            // ���������, ��� person3 �� ���������� � ���������
            var person3 = new Person { name = "������� ���������", gender = "�������", age = 20 };
            Assert.IsFalse(collection.Contains(person3));
        }

        // ������������ �������� ���� ��������� �� ���������
        [TestMethod]
        public void TestClear()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            collection.Add("B");
            collection.Clear();
            Assert.AreEqual(0, collection.Count); // ���������, ��� ��������� ����� ����� ������ Clear()
        }
    }
}