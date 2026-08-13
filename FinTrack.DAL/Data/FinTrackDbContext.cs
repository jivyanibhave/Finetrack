using FinTrack.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Data
{
    public class FinTrackDbContext : DbContext
    {
        public FinTrackDbContext(DbContextOptions<FinTrackDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Budget> Budgets { get; set; }
    }
}
