using Microsoft.Extensions.DependencyInjection;
using MyToDoList.Core.Domain.Repository;
using MyToDoList.Infrastructure.Repository;
using System;

namespace MyToDoList.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IToDoRepository, ToDoRepository>();
            serviceCollection.AddScoped<IPrint, Print>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var print = serviceProvider.GetRequiredService<IPrint>();

            print.StartUI();
        }
    }
}
