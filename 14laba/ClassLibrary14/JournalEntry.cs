using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary13
{
    public class JournalEntry
    {
        // Автореализуемые свойства
        public string CollectionName { get; set; }      // Название коллекции
        public string ChangeType { get; set; }         // Тип изменения
        public string ChangedObject { get; set; }    // Данные измененного объекта

        // Конструктор для инициализации полей
        public JournalEntry(string collectionName, string changeType, string changedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedObject = changedObject;
        }

        // Перегруженный метод ToString()
        public override string ToString()
        {
            return $"Collection: {CollectionName}, Change: {ChangeType}, Data: {ChangedObject}";
        }
    }
}
