using CS_EFcore.Models;
using System;
using System.Linq;

namespace CS_EFcore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManageDatabse();
                using (var ctx=new PersonDbContext())
                {
                    var person = new Person()
                    {
                       
                        PersonName = "Sonam",
                        Age = 43,
                        Gender = "Female"
                    };
                    ctx.Persons.Add(person);
                    ctx.SaveChanges();
                    Console.WriteLine("Added Person");
                    foreach(var p in ctx.Persons.ToList())
                    {
                        Console.WriteLine($"{p.PersonId} {p.PersonName} {p.Age} {p.Gender}");                     

                     }
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// This method will make sure that if the DB is already available then delete it.
        /// 
        /// </summary>
        static void ManageDatabse()
        {
            using (var ctx=new PersonDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}
