using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary13
{
    public class Journal
    {
        // Список для хранения записей журнала
        private List<JournalEntry> entries = new List<JournalEntry>();

        // Метод, который будет вызываться при изменении коллекции
        public void OnCollectionChanged<T>(object source, CollectionHandlerEventArgs<T> args)
        {
            //args.ChangedObject-объект с которым произошло изменение(коллекция)
            //?-проверка на null, ??-возвращает "null" если слева null
            //itemData-строковое представление объекта
            string itemData = args.ChangedObject?.ToString() ?? "null";
            //добавление в список изменений новой записи типа JournalEntry, с данными измененного объекта
            entries.Add(new JournalEntry(args.CollectionName, args.ChangeType, itemData));
        }
        public void OnCollectionReferenceChanged<T>(object source, CollectionHandlerEventArgs<T> args)
        {
            string itemData = args.ChangedObject?.ToString() ?? "null";
            entries.Add(new JournalEntry(args.CollectionName, args.ChangeType, itemData));
        }


        // Метод для добавления новой записи в журнал
        public void AddEntry(string collectionName, string changeType, string changedObject)
        {
            entries.Add(new JournalEntry(collectionName, changeType, changedObject));
        }

        // Метод для вывода всех записей журнала
        public void PrintAllEntries()
        {
            Console.WriteLine("Journal entries:");
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        // Свойство для получения всех записей (только для чтения)
        public IReadOnlyList<JournalEntry> Entries => entries.AsReadOnly();
    }

}
