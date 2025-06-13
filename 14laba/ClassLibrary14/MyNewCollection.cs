using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary13
{
    public class MyNewCollection<T>:MyCollection<T>
    {
        public string CollectionName { get; set; }

        public event CollectionHandler<T> CollectionCountChanged;
        public event CollectionHandler<T> CollectionReferenceChanged;
        public MyNewCollection(string name)
        {
            CollectionName = name;
        }
        

        //методы для вызова и проверки есть ли ссылки на методы, чтобы не выходила ошибка null
        public void RaiseCollectionCountChanged(string changeType, object item)
        {
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs<T>(CollectionName, changeType, item));
        }

        public void RaiseCollectionReferenceChanged(string changeType, object item)
        {
            CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs<T>(CollectionName, changeType, item));
        }

        //добавление элемента
        public new void Add(T item)
        {
            base.Add(item);
            RaiseCollectionCountChanged("Добавление", item);
        }
        //удаление элемента
        public new bool Remove(int j)
        {
            if (j < 0 || j >= Count) return false; //проверка находится ли индекс в пределах коллекции

            int i = 0;
            foreach (var item in this)
            {
                if (i == j)
                {
                    base.Remove(item); // удаление из базовой коллекции
                    RaiseCollectionCountChanged("Удаление", item); // вызов события
                    return true;
                }
                i++;
            }
            return false;
        }

        // Обращение к элементу по индексу для изменения
        public T? this[int index]
        {
            get
            {
                int i = 0;
                foreach (var item in this) //перебор коллекции
                {
                    if (i == index) // найден нужный индекс, вернуть значение 
                        return item;
                    i++;
                }
                return default; // не найден, вернуть дефолтное значение
            }
            set
            {
                if (value == null) return; //нельзя присвоить null 
                int i = 0;
                Node<T>? node = head; //?-означает что node может быть null,
                                      //присваивается новому узлу значение head
                while (node != null)
                {
                    if (i == index)
                    {
                        // Добавляем проверку: только если значение изменилось
                        if (!EqualityComparer<T>.Default.Equals(node.Data, value))
                        {
                            node.Data = value;
                            RaiseCollectionReferenceChanged($"Изменён элемент по индексу {index}", node.Data);
                        }
                        break;
                    }
                    i++;
                    node = node.Next;
                }
            }
        }
    }
}
