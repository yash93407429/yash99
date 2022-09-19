using EGroceryStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.DataAccess
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }
        public DbSet<User> usertable { get; set; }
        
        public DbSet<Order> Order { get; set; }
       
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<Buy> tblEmployees { get; set; }
        public DbSet<Grocery> tblDesignations { get; set; }


    }
}
