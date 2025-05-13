using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary12
{
    public class MyCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerator<T>, ICloneable
    {
        private Node<T> head; // первый элемент
        private Node<T> current; // текущий элемент
        private int count; // количество элементов
        private int capacity; // емкость коллекции


        // Конструкторы
        public MyCollection()
        {
            head = null;
            count = 0;
            capacity = 0;
        }
        public MyCollection(int capacity)
        {
            head = null;
            count = 0;
            this.capacity = capacity;
        }
        // конструктор копирования
        public MyCollection(MyCollection<T> other)
        {
            foreach (var item in other)
                Add(item);
        }

        // Метод добавления одного элемента
        public void Add(T item)
        {
            var node = new Node<T>(item);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = node;
            }
            count++;
        }
        // Метод для добавления нескольких элементов
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);  // Используем метод Add для каждого элемента
            }
        }

        // Удаление по значению
        public bool Remove(T item)
        {
            Node<T> prev = null;
            Node<T> current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    if (prev == null)
                        head = current.Next;
                    else
                        prev.Next = current.Next;

                    count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }
        // Метод для удаления нескольких элементов
        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Remove(item);  // Для каждого элемента вызываем Remove
            }
        }

        // Поиск
        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element is Person person && item is Person otherPerson)
                {
                    // Сравниваем по Name, Gender и Age
                    if (person.name == otherPerson.name && person.gender == otherPerson.gender && person.age == otherPerson.age)
                        return true;
                }
            }
            return false;
        }

        // Глубокое клонирование
        public object Clone()
        {
            var clone = new MyCollection<T>();
            foreach (var item in this)
            {
                if (item is ICloneable cloneableItem)
                    clone.Add((T)cloneableItem.Clone());
                else
                    clone.Add(item);
            }
            return clone;
        }

        // Поверхностное копирование
        public MyCollection<T> ShallowCopy()
        {
            return new MyCollection<T>(this);
        }

        // Удаление всей коллекции
        public void Clear()
        {
            head = null;
            count = 0;
        }

        // Реализация ICollection<T>
        public int Count => count;
        public bool IsReadOnly => false;

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        // Реализация IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            current = null; // Сброс current перед началом перебора
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Реализация IEnumerator<T>
        public T Current
        {
            get
            {
                if (current == null)
                    throw new InvalidOperationException("Перебор еще не начат или уже завершен.");
                return current.Data;
            }
        }
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            current = current == null ? head : current.Next;
            return current != null;
        }

        public void Reset() => current = null;
        public void Dispose() { }
    }
}
