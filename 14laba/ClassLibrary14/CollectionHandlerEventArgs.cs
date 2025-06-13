namespace ClassLibrary13
{
    public delegate void CollectionHandler<T>(object source, CollectionHandlerEventArgs<T> args);
    public class CollectionHandlerEventArgs<T> : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object ChangedObject { get; set; }

        public CollectionHandlerEventArgs(string name, string type, object obj)
        {
            CollectionName = name;
            ChangeType = type;
            ChangedObject = obj;
        }

        public override string ToString()
        {
            return $"Коллекция: {CollectionName}, Изменение: {ChangeType}, Объект: {ChangedObject}";
        }
    }
}