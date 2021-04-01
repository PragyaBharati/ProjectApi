using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabourZillaWebApi.Models;

namespace LabourZillaWebApi.Data
{
    public class LabourDbContext : DbContext
    {
        public LabourDbContext (DbContextOptions<LabourDbContext> options)
            : base(options)
        {
        }

        public DbSet<LabourZillaWebApi.Models.Labour> Labour { get; set; }
    }
}
