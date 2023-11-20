using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IOTBTL.Models;

public partial class MachineLbtnContext : DbContext
{
   
    public MachineLbtnContext(DbContextOptions<MachineLbtnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Weather> Weathers { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weather>(entity =>
        {
            entity.ToTable("weathers");
        });

        
    }

    
}
