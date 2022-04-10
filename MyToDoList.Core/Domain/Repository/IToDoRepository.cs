using System;
using System.Collections.Generic;
using System.Text;
using MyToDoList.Core.Domain.Entity;

namespace MyToDoList.Core.Domain.Repository
{
    public interface IToDoRepository
    {
        public ToDo CreateToDo(ToDo todo);

        public ToDo DeleteToDo(int id);

        public ToDo GetToDoById(int id);

        public List<ToDo> GetAllToDo();
    }
}
