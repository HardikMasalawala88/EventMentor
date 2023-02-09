using EMS.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperatorWork> OperatorWorks { get; set; }
        public DbSet<StaffWork> StaffWorks { get; set; }
    }
}
