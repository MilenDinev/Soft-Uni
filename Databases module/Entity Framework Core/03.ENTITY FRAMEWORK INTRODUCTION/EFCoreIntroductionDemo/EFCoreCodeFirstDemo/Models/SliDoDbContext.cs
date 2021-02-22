using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreCodeFirstDemo.Models
{
  public  class SliDoDbContext : DbContext
    {

        public SliDoDbContext()
        {

        }

        public SliDoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Server=.;Database=SliDo;Integrated Security=true");
            }
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
