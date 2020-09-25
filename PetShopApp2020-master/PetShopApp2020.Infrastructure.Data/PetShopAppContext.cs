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

        
        public DbSet<Pet> PetTable { get; set; }
        public DbSet<Owner> OwnerTable { get; set; }
        public DbSet<PetTypes> PetTypeTable { get; set; }


    }
}
