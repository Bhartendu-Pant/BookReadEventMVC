using LearningMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC.Data
{
    public class BookReadContext : IdentityDbContext<ApplicationUser>
    {
        public BookReadContext(DbContextOptions<BookReadContext>options)
            : base(options)
        {

        }

        public DbSet<Events> Events { get; set; }
     /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookEvent;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
     */
    }
}
