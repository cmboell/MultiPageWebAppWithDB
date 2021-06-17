 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//page that updates data and applies business rules, validates data
namespace MultiPageWebAppWithDB.Models
{
    public class ContactContext : DbContext  //class that inherits the DbContext class
    {
        public ContactContext(DbContextOptions<ContactContext> options)
                    : base(options)
        { }
        //entity classes (Working with DbSet to map to database)
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //OnModelCreating method to override to configure the context
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Relationship>().HasData( //creates realtionships
                new Relationship { RelationshipId = "R",  Type = "Realitive" },
                new Relationship { RelationshipId = "F", Type = "Friend" },
                new Relationship { RelationshipId = "C", Type = "Coworker" },
                new Relationship { RelationshipId = "A", Type = "Acquaintance" },
                new Relationship { RelationshipId = "CM", Type = "Classmate" },
                new Relationship { RelationshipId = "S", Type = "Services" },
                new Relationship { RelationshipId = "N", Type = "Neighbor" });
            modelBuilder.Entity<Contact>().HasData( //seeds initial data in database
                //creates new contacts in table
                new Contact
                {
                    ContactId = 1,
                    Name = "Ted Lamp",
                    PhoneNumber = "712-292-0000",
                    Address = "123 N. Road St.",
                    Note = "Neighbor with a dog",
                    RelationshipId = "N"
                },
            new Contact
            {
                ContactId = 2,
                Name = "Mary Sue",
                PhoneNumber = "712-292-0001",
                Address = "111 Grand Ave.",
                Note = "HTML and CSS class",
                RelationshipId = "CM"


            },
             new Contact
             {
                 ContactId = 3,
                 Name = "Jon Jon",
                 PhoneNumber = "712-292-1043",
                 Address = "888 Hotdog St.",
                 Note = "Cousin",
                 RelationshipId = "R"
             }
                ) ;
        }

    }
}
