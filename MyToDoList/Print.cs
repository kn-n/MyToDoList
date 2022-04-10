using MyToDoList.Core.Domain.Entity;
using MyToDoList.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDoList.UI
{
    public class Print : IPrint
    {
        private readonly IToDoRepository _todoRepo;

        int i = 0;

        public Print(IToDoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }
        public void StartUI()
        {
            string[] menuItems =
            {
                "Добавить заметку",
                "Удалить заметку"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 3)
            {
                switch (selection)
                 {
                    case 1:
                        AddToDo();
                        break;
                    case 2:
                        DeleteToDo();
                        break;
                    default:
                        Console.WriteLine("Закрытие программы");
                    break;
                 }
                selection = ShowMenu(menuItems);
            }
            
        }

        private void ShowAllToDo()
        {
            var todo = _todoRepo.GetAllToDo();
            if (todo != null)
            {
            Console.WriteLine("Все заметки:");
            foreach (var td in todo)
            {
                Console.WriteLine($"ID: {td.id}\n Заметка: {td.text}\n");
            }
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            ShowAllToDo();
            Console.WriteLine("Выберите действие:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 3)
            {
                Console.WriteLine("Пожалуйста, введите число");
            }

            return selection;
        }

        private void AddToDo()
        {
            Console.WriteLine("Введите текст:");
            var text = Console.ReadLine();

            var newToDo = new ToDo()
            {
                id = i,
                text = text
            };
            i++;

            _todoRepo.CreateToDo(newToDo);
        }

        private void DeleteToDo()
        {
            Console.WriteLine("Введите ID:");
            var id = Console.ReadLine();

            _todoRepo.DeleteToDo(int.Parse(id));
        }

    }
}
