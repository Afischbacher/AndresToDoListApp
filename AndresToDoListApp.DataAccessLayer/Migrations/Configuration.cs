using AndresToDoListApp.DataAccessLayer.Context;
using AndresToDoListApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndresToDoListApp.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AndresToDoListContext>
    {
        /// <inheritdoc />
        /// <summary>
        /// Configuring the migrations behaviour in Entity Framework
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// A seed method for a layer of base data for the to do list
        /// </summary>
        /// <param name="andresToDoListContext"></param>
        protected override void Seed(AndresToDoListContext andresToDoListContext)
        {
            if (andresToDoListContext.ToDos.Any()) return;

            var toDo = new ToDo
            {
                Id = 1,
                ToDoItem = "Feed my dog"
            };

            andresToDoListContext.ToDos.AddOrUpdate(toDo);

        }

    }
}
