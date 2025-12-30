using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class CoreUMSContext : DbContext
    {
        public CoreUMSContext(DbContextOptions<CoreUMSContext>options)
        : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
