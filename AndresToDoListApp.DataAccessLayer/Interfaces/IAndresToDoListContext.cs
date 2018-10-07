using AndresToDoListApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndresToDoListApp.DataAccessLayer.Interfaces
{
    public interface IAndresToDoListContext 
    {
        DbSet<ToDo> ToDos { get; set; }
    }
}
