using HW11_Notes_Contacts_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HW11_Notes_Contacts_MVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
