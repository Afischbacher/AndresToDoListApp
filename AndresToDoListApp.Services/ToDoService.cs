using AndresToDoListApp.DataAccessLayer.Context;
using AndresToDoListApp.Services.Interfaces;
using AndresToDoListApp.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AndresToDoListApp.DataAccessLayer.Entities;
using System.Data.Entity;
using NLog;

namespace AndresToDoListApp.Services
{
    public class ToDoService : IToDoService
    {
        // Private property for the injected database context
        private AndresToDoListContext AndresToDoListContext { get; set; }

        // Sets up the logger for the current service class
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        // Injected the database context into the constructor of the service class
        public ToDoService(AndresToDoListContext andresToDoListContext)
        {
            AndresToDoListContext = andresToDoListContext;
        }

        /// <summary>
        /// Creates a new to do list item asynchronously and returns true if successful 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CreateToDoAsync(ToDoViewModel toDoViewModel)
        {
            try
            {
                // Map the view model to the entity
                var toDo = Mapper.Map<ToDoViewModel, ToDo>(toDoViewModel);
                   
                // Add the entity to the database context
                AndresToDoListContext.ToDos.Add(toDo);

                // Save the changes asynchronously
                await AndresToDoListContext.SaveChangesAsync();

                // Returns the true for the successfully completed operation
                return true;
            }
            catch (Exception exception)
            {
                // Logs the error and throws the exception
                _logger.Error(exception);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a collection of all of the current to do list items asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ToDoViewModel>> GetToDoItemsAsync()
        {
            try
            {
                // Map the view model to the entity and return a collection of the current to do list items
                return Mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoViewModel>>
                    (await AndresToDoListContext.ToDos.ToListAsync());
            }
            catch (Exception exception)
            {
                // Logs the error and throws the exception
                _logger.Error(exception);
                throw;
            }
        }

        /// <summary>
        /// Updates the to do list item asynchronously
        /// </summary>
        /// <param name="toDoViewModel"></param>
        /// <returns></returns>
        public async Task<bool> UpdateToDoAsync(ToDoViewModel toDoViewModel)
        {
            try
            {
                // Maps the view model to the entity
                var toDo = Mapper.Map<ToDoViewModel, ToDo>(toDoViewModel);

                // Retrieves the single to do item based on the id asynchronously
                var toDoToUpdate = await AndresToDoListContext.ToDos.SingleAsync(x => x.Id == toDoViewModel.Id);

                // Updates the to do list item content
                toDoToUpdate.ToDoItem = toDo.ToDoItem;

                // Save the changes asynchronously
                await AndresToDoListContext.SaveChangesAsync();

                // Returns the true for the successfully completed operation
                return true;

            }
            catch (Exception exception)
            {
                // Logs the error and throws the exception
                _logger.Error(exception);
                throw;
            }
        }

        /// <summary>
        /// Deletes a to do list item based on the items id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteToDoAsync(int id)
        {
            try
            {
                // Retrieves the single to do item based on the id asynchronously
                var toDoToDelete = await AndresToDoListContext.ToDos.SingleAsync(x => x.Id == id);

                // Removes the entity from the database context
                AndresToDoListContext.ToDos.Remove(toDoToDelete);

                // Save the changes asynchronously
                await AndresToDoListContext.SaveChangesAsync();

                // Returns the true for the successfully completed operation
                return true;
            }
            catch (Exception exception)
            {
                // Logs the error and throws the exception
                _logger.Error(exception);
                throw;
            }
        }

        public void Dispose()
        {
            // Disposes the service
            AndresToDoListContext?.Dispose();
        }

    }
}
