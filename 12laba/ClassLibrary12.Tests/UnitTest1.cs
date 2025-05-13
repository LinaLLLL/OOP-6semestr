using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary12;
using System;
using System.Linq;

namespace ClassLibrary12.Tests
{ 
    [TestClass]
    public class UnitTest1
    {
        // Тестирование добавления элемента в коллекцию
        [TestMethod]
        public void TestAdd()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            Assert.AreEqual(1, collection.Count); // Проверяем, что количество элементов после добавления одного равно 1
        }

        // Тестирование добавления нескольких элементов в коллекцию
        [TestMethod]
        public void TestAddRange()
        {
            var collection = new MyCollection<string>();
            collection.AddRange(new[] { "A", "B", "C" });
            Assert.AreEqual(3, collection.Count); // Проверяем, что количество элементов после добавления трех равно 3
        }

        // Тестирование удаления одного элемента из коллекции
        [TestMethod]
        public void TestRemove()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            collection.Add("B");
            var result = collection.Remove("A");
            Assert.IsTrue(result); // Проверяем, что элемент был успешно удален
            Assert.AreEqual(1, collection.Count); // Проверяем, что количество элементов уменьшилось
        }

        // Тестирование удаления нескольких элементов из коллекции
        [TestMethod]
        public void TestRemoveRange()
        {
            var collection = new MyCollection<string>();
            collection.AddRange(new[] { "A", "B", "C" });
            collection.RemoveRange(new[] { "A", "C" });
            Assert.AreEqual(1, collection.Count); // Проверяем, что осталось только 1 элемент
            Assert.IsFalse(collection.Contains("A")); // Проверяем, что "A" удален
            Assert.IsFalse(collection.Contains("C")); // Проверяем, что "C" удален
        }

        // Тестирование поиска элемента в коллекции
        [TestMethod]
        public void TestContains()
        {
            var collection = new MyCollection<Person>();

            var person1 = new Person { name = "Константин Петрович", gender = "Мужчина", age = 30 };
            var person2 = new Person { name = "Марина Иванова", gender = "Женщина", age = 25 };

            collection.Add(person1);
            collection.Add(person2);

            // Проверяем, что person1 существует в коллекции
            Assert.IsTrue(collection.Contains(person1));

            // Проверяем, что person3 не существует в коллекции
            var person3 = new Person { name = "Николай Сергеевич", gender = "Мужчина", age = 20 };
            Assert.IsFalse(collection.Contains(person3));
        }

        // Тестирование удаления всех элементов из коллекции
        [TestMethod]
        public void TestClear()
        {
            var collection = new MyCollection<string>();
            collection.Add("A");
            collection.Add("B");
            collection.Clear();
            Assert.AreEqual(0, collection.Count); // Проверяем, что коллекция пуста после вызова Clear()
        }
    }
}