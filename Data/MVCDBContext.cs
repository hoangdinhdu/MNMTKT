using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo.Models;

    public class MVCDBContext : DbContext
    {
        public MVCDBContext (DbContextOptions<MVCDBContext> options)
            : base(options)
        {
        }

        public DbSet<Demo.Models.Person> Person { get; set; }

        public DbSet<Demo.Models.Student> Student { get; set; }

        public DbSet<Demo.Models.Category> Category { get; set; }

        public DbSet<Demo.Models.Product> Product { get; set; }
    }
