using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary13
{
    public class MyCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerator<T>, ICloneable
    {
        public Node<T> head; // первый элемент
        public Node<T> current; // текущий элемент
        public int count; // количество элементов
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
                while (current.Next != null) //проходимся до последнего элемента
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
        //Метод автоматического заполнения
        public void GenerateData(int count) //передаем колличество элементов
        {
            Clear(); // очищаем коллекцию
            for (int i = 0; i < count; i++) 
            {
                T item = Activator.CreateInstance<T>(); //создание элемента T с помощью рефлекции, т.е. во вермя выполнения программы
                if (item is Person person) // проверка item типа person, то сохранить в переменную person
                { 
                    person.RandomInit(); 
                }
                Add(item); //person и item ссылаются на одно значение
            }
        }

        // Удаление по значению
        public bool Remove(T item)
        {
            Node<T> prev = null; // узел перед текущим
            Node<T> current = head; // текущий узел

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    if (prev == null)
                    {
                        head = current.Next; // если узел первый - сдвигаем
                    }
                    else
                    {
                        prev.Next = current.Next; // иначе перепрыгиваем через текущий
                    }

                    count--; // уменьшаем счетчик элементов
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
            foreach (var element in this) // перебор элементов коллекции
            {
                //проверка являются ли element и item типом Person, и сохраняет результат в person и otherPerson
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
            foreach (var item in this) // перебор элементов текущей коллекции
            {
                // проверка реализует ли item интерфейс, приводит item к типу ICloneable и сохраняет значение в cloneableItem
                if (item is ICloneable cloneableItem)
                {
                    clone.Add((T)cloneableItem.Clone()); // добавление в новую коллекцию
                }
                else
                {
                    clone.Add(item);
                }
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
        public int Count => count; // возвращает количество элементов в коллекции
        //public int Count { get { return count; } } - точно то же самое
        public bool IsReadOnly => false; // разрешение на изменение коллекции

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
        // обобщение, для совместимости, чтобы исключить ошибки 
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Реализация IEnumerator<T>
        public T Current
        {
            get
            {
                if (current == null)
                {
                    throw new InvalidOperationException("Перебор еще не начат или уже завершен.");
                }
                return current.Data; // возвращает значение текущего элемента
            }
        }
        // то же самое, но для совместимости со старыми конструкциями, которые работают с IEnumerator без типа
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            // если current = null, то начинаем с head, если !=null то переходим к следующему
            current = current == null ? head : current.Next;
            // если true, перебор продолжается, если false, то конец коллекции
            return current != null;
        }
        // сброс current в 0
        public void Reset() => current = null;
        // освобождение ресурсов
        public void Dispose() { }

        //сортировка
        public void Sort(Comparison<T> comparison)
        {
            var list = new List<T>(this); // копируем элементы в List
            list.Sort(comparison); //сортировка

            Clear(); //очищаем исходнуюю коллекцию
            foreach (var item in list) // заполняем из отсортированного списка
            { 
                Add(item); 
            }
        }

    }
}
