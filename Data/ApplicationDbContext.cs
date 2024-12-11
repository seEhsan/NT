namespace WebApplication1.Data
{
    using Microsoft.EntityFrameworkCore;
    //  using NearbyTeachers.Models;
    using WebApplication1.Models;

    using System.Collections.Generic;
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //: base(options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
            // Teachers = null;//new List<Teacher>(); // Initialize with a default value
             public DbSet<Teacher> Teachers { get; set; }
        }
        // public DbSet<Teacher> Teachers { get; set; }
       // public List<Teacher>? Teachers { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Teachers = new List<Teacher>(); // Set default value here
        //    base.OnModelCreating(modelBuilder);
        //}
    }

