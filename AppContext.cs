using GerenciamentoDeContatosWeduka.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeContatosWeduka
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Contacts)
                .WithOne()
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "John Doe" },
                new Person { Id = 2, Name = "Jane Smith" },
                new Person { Id = 3, Name = "Alice Johnson" },
                new Person { Id = 4, Name = "Bob Brown" },
                new Person { Id = 5, Name = "Carol White" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, PersonId = 1, Type = "Phone", Value = "123-456-7890" },
                new Contact { Id = 2, PersonId = 1, Type = "Email", Value = "john.doe@example.com" },
                new Contact { Id = 3, PersonId = 2, Type = "Phone", Value = "234-567-8901" },
                new Contact { Id = 4, PersonId = 2, Type = "Email", Value = "jane.smith@example.com" },
                new Contact { Id = 5, PersonId = 3, Type = "Phone", Value = "345-678-9012" },
                new Contact { Id = 6, PersonId = 3, Type = "Email", Value = "alice.johnson@example.com" },
                new Contact { Id = 7, PersonId = 4, Type = "Phone", Value = "456-789-0123" },
                new Contact { Id = 8, PersonId = 4, Type = "Email", Value = "bob.brown@example.com" },
                new Contact { Id = 9, PersonId = 5, Type = "Phone", Value = "567-890-1234" },
                new Contact { Id = 10, PersonId = 5, Type = "Email", Value = "carol.white@example.com" }
            );
        }

    }
}
