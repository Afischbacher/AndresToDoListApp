using AndresToDoListApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndresToDoListApp.Services.Interfaces
{
    public interface IToDoService : IDisposable
    {
        Task<bool> CreateToDoAsync(ToDoViewModel toDoViewModel);

        Task<IEnumerable<ToDoViewModel>> GetToDoItemsAsync();

        Task<bool> UpdateToDoAsync(ToDoViewModel toDoViewModel);

        Task<bool> DeleteToDoAsync(int id);
    }
}
