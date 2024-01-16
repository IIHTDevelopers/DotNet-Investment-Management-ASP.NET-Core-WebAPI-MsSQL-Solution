using InvestmentManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentManagement.DataLayer
{
    public class InvestmentDbContext : DbContext
    {
        public InvestmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; }
    }

}