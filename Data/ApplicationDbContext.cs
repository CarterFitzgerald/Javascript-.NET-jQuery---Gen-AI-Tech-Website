using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Final_Assignment_Carter_Fitzgerald.Models;

namespace Final_Assignment_Carter_Fitzgerald.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Final_Assignment_Carter_Fitzgerald.Models.GenAIs>? GenAIs { get; set; }
    }
}