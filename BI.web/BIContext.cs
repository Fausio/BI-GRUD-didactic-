using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  

namespace BI.web
{
    public class BIContext : DbContext
    {
        
        public BIContext(DbContextOptions<BIContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<BI.web.Models.BI> BIs { get; set; }


    }
}
