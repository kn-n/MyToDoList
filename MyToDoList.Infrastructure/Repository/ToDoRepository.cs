using System;
using System.Collections.Generic;
using System.Text;
using MyToDoList.Core.Domain.Entity;
using MyToDoList.Core.Domain.Repository;

namespace MyToDoList.Infrastructure.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private static List<ToDo> _todo = new List<ToDo>();

        public ToDo CreateToDo(ToDo todo)
        {
            _todo.Add(todo);
            return todo;
        }

        public ToDo DeleteToDo(int id)
        {
            var todoDelete = this.GetToDoById(id);
            if (todoDelete != null)
            {
                _todo.Remove(todoDelete);
                return todoDelete;
            }
            return null;
        }

        public List<ToDo> GetAllToDo()
        {
            return _todo;
        }

        public ToDo GetToDoById(int id)
        {
            foreach (var todo in _todo)
            {
                if (todo.id == id) return todo;
            }
            return null;
        }
    }
}
