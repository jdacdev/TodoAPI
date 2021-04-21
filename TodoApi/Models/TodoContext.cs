using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Name = "Pay water bill" , IsComplete = false},
                new TodoItem { Id = 2, Name = "Call to assitance for internet service", IsComplete = false },
                new TodoItem { Id = 3, Name = "Complete the homework", IsComplete = true },
                new TodoItem { Id = 4, Name = "Buy meet for dinner", IsComplete = false }
                ); 
        }
    }
}