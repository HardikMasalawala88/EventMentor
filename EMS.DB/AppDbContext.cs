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
        public DbSet<Event> EventList { get; set; }
        public DbSet<Inquiry> InquiryList { get; set; }
        public DbSet<Category> CategoryList { get; set; }
        public DbSet<Services> ServicesList { get; set; }
    }
}
