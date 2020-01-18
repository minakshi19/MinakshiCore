using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CS_EFcore.Models
{
   public class PersonDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonDbContext()
        {
           
        }
        /// <summary>
        /// Configure Db-Connection with Application
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PersonDb;Integrated Security=SSPI");
        }
        /// <summary>
        /// Provide mechanism of model mapping while database and table created.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
