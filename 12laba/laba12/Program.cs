using System;

namespace ClassLibrary12
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyCollection<Person>();

            while (true)
            {
                Console.WriteLine("\n===== МЕНЮ =====");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Добавить несколько элементов");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("4. Удалить несколько элементов");
                Console.WriteLine("5. Поиск элемента");
                Console.WriteLine("6. Показать все элементы");
                Console.WriteLine("7. Глубокое клонирование");
                Console.WriteLine("8. Поверхностное копирование");
                Console.WriteLine("9. Очистить коллекцию");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("1. Добавить элемент вручную");
                        Console.WriteLine("2. Добавить элемент с помощью ДСЧ");
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                list.Add(CreatePerson());
                                break;
                            case "2":
                                Student s1 = new Student();
                                s1.RandomInit();
                                list.Add(s1);
                                break;
                            default:
                                Console.WriteLine("Неверный выбор. Повторите.");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("1. Добавить несколько элементов вручную");
                        Console.WriteLine("2. Добавить несколько элементов с помощью ДСЧ");
                        string choice3 = Console.ReadLine();
                        switch (choice3)
                        {
                            case "1":
                                Console.Write("Сколько элементов добавить? ");
                                if (int.TryParse(Console.ReadLine(), out int n))
                                {
                                    for (int j = 0; j < n; j++)
                                        list.Add(CreatePerson());
                                }
                                break;
                            case "2":
                                Console.Write("Сколько элементов добавить? ");
                                if (int.TryParse(Console.ReadLine(), out int n1))
                                {
                                    for (int j = 0; j < n1; j++)
                                    {
                                        Person p = new Person();
                                        p.RandomInit();
                                        list.Add(p);
                                    }
                                        
                                }
                                break;
                            default:
                                Console.WriteLine("Неверный выбор. Повторите.");
                                break;
                        }
                        break;                     

                    case "3":
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Список пуст.");
                            break;
                        }

                        Console.WriteLine("Список элементов:");
                        int index = 0;
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{index++}: {item}");
                        }

                        Console.Write("Введите номер элемента для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 0 && selectedIndex < list.Count)
                        {
                            var elementToRemove = list.ElementAt(selectedIndex);
                            if (list.Remove(elementToRemove))
                                Console.WriteLine("Элемент удалён.");
                            else
                                Console.WriteLine("Не удалось удалить элемент.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер.");
                        }
                        break;

                    case "4":
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Список пуст.");
                            break;
                        }

                        Console.WriteLine("Список элементов:");
                        int i = 0;
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{i++}: {item}");
                        }

                        Console.WriteLine("Введите номера элементов для удаления (через пробел):");
                        string input = Console.ReadLine();
                        var indices = input.Split(' ') // разбивает строку на массив элементов
                                           .Select(s => int.TryParse(s, out int num) ? num : -1) // каждый элемент преврящает в число
                                           .Where(n => n >= 0 && n < list.Count) // отфильтровывает элементы который не выходят за пределы коллекции
                                           .Distinct() // удаляет повторы элементов
                                           .OrderByDescending(n => n) // сотрирует по убывания
                                           .ToList(); // преобразует в List 

                        if (indices.Count == 0)
                        {
                            Console.WriteLine("Нет корректных номеров для удаления.");
                            break;
                        }

                        foreach (int indexToRemove in indices)
                        {
                            var itemToRemove = list.ElementAt(indexToRemove); // ElementAt берет элемент из коллекции по индексу в скобках
                            list.Remove(itemToRemove); // удаляет элемент заданного индекса
                        }

                        Console.WriteLine("Удаление завершено.");
                        break;

                    case "5":
                        Console.WriteLine("Поиск элемента:");
                        Console.WriteLine(list.Contains(CreatePerson()) ? "Найден" : "Не найден");
                        break;

                    case "6":
                        Console.WriteLine("Все элементы:");
                        foreach (var person in list)
                            Console.WriteLine(person);
                        break;

                    case "7":
                        var deep = (MyCollection<Person>)list.Clone();
                        Console.WriteLine("Клонированная (глубоко) коллекция:");
                        foreach (var p in deep)
                            Console.WriteLine(p);
                        break;

                    case "8":
                        var shallow = list.ShallowCopy();
                        Console.WriteLine("Копия (поверхностная) коллекции:");
                        foreach (var p in shallow)
                            Console.WriteLine(p);
                        break;

                    case "9":
                        list.Clear();
                        Console.WriteLine("Коллекция очищена.");
                        break;

                    case "0":
                        Console.WriteLine("Выход из программы...");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Повторите.");
                        break;
                }
            }

            static Person CreatePerson()
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите пол (Мужчина/Женщина): ");
                string gender = Console.ReadLine();

                Console.Write("Введите возраст: ");
                int age = int.Parse(Console.ReadLine());

                return new Person {name = name, gender = gender, age = age };
            }


        }

    }
}