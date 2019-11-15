using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMl
{
    public class BloggingContext : DbContext
    {
        public DbSet<PointData> PointData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=ml;Integrated Security=True");
        }
    }
}
