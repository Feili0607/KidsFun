using KidsFun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFun.Repositories
{
    public class KidsFunContext : DbContext
    {
        public DbSet<KidDetail> Kids { get; set; }

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<TaskAssignment> TaskAssignments { get; set; }

        public KidsFunContext(DbContextOptions<KidsFunContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KidDetail>()
            .Ignore(u => u.Email);

            modelBuilder.Entity<TaskAssignment>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<TaskAssignment>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(e => e.Kid)
                .WithMany()
                .HasForeignKey(e => e.KidId);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId);
        }
    }
}
