using System;
using System.Collections.Generic;
using System.Text;
using LibraryAssessment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAssessment.Data
{
    public class AssessmentDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Rented> Rented { get; set; }

        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options)
            : base(options)
        {
        }
        public AssessmentDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
