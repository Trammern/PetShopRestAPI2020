using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data
{
   public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt)
            : base(opt) { }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                 .HasOne(p => p.owner)
                 .WithMany(o => o.Pet)
                 .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Pet> PetTable { get; set; }
        public DbSet<Owner> OwnerTable { get; set; }
        public DbSet<PetTypes> PetTypeTable { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
