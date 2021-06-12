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
        public yad2Context (DbContextOptions<yad2Context> options)
            : base(options)
        {
        }

        public DbSet<yad2.Models.User> User { get; set; }
        public DbSet<yad2.Models.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Init base class
            base.OnModelCreating(modelBuilder);


            // Set relationsships between our DB tables
           /* modelBuilder.Entity<Models.User>()
                .HasMany(b => b.Posts)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Product>()
                .HasOne(p => p.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Post>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Tags);

            modelBuilder.Entity<Models.Tag>()
                .HasMany(p => p.posts)*/
           
        }
    }
}
