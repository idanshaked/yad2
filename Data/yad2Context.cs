using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yad2.Models;

namespace yad2.Data
{
    public class yad2Context : DbContext
    {
        public yad2Context(DbContextOptions<yad2Context> options)
            : base(options)
        {
        }

        public DbSet<yad2.Models.User> User { get; set; }

        public DbSet<yad2.Models.Store> Store { get; set; }

        public DbSet<yad2.Models.Tags> Tags { get; set; }

        public DbSet<yad2.Models.Post> Posts { get; set; }

        public DbSet<yad2.Models.Product> Products { get; set; }

    }
}