using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL.Models
{
    public class Context:DbContext
    {
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var developers = new List<Developer>
            {
                  new Developer {
                    Id= 1,
                    Name= "Ali",
                  },
                  new Developer {
                    Id= 2,
                    Name= "Hani",
                  },
                  new Developer {
                    Id= 3,
                    Name= "Rami",
                  },
                  new Developer {
                    Id= 4,
                    Name= "Omar",
                  },
                  new Developer {
                    Id= 5,
                    Name= "Amr",
                  }                  
                };

            var departments = new List<Department>
                {
                 new Department {
                    Id= 1,
                    Name= "AI",
                  },
                 new Department {
                    Id= 2,
                    Name= "CS",
                  },
                 new Department {
                    Id= 3,
                    Name= "DS",
                  },
                 new Department {
                    Id= 4,
                    Name= "PD",
                  },
                 new Department {
                    Id= 5,
                    Name= "OS",
                  }
                };

            var tickets = new List<Ticket>
                {
                  new Ticket {
                    Id= 1,
                    Title= "ticket1",
                    DepartmentId= 1,
                  },
                  new Ticket {
                    Id= 2,
                    Title= "ticket2",
                    DepartmentId= 3,
                  },
                  new Ticket {
                    Id= 3,
                    Title= "ticket3",
                    DepartmentId= 4,
                  },
                  new Ticket {
                    Id= 4,
                    Title= "ticket4",
                    DepartmentId= 2,
                  },
                  new Ticket {
                    Id= 5,
                    Title= "ticket5",
                    DepartmentId= 5,
                  },
                };
            modelBuilder.Entity<Developer>().HasData(developers);
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Ticket>().HasData(tickets);
        }

    }
}
