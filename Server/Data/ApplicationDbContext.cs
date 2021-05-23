using workings.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workings.Shared;

namespace workings.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
        ) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<BlindProfile> BlindProfiles { get; set; }
        public DbSet<BusinessClient> BusinessClients { get; set; }
        public DbSet<BlindRailing> BlindRailings { get; set; }
        public DbSet<BlindRod> BlindRods { get; set; }
        public DbSet<BlindStack> BlindStacks { get; set; }
        
        public DbSet<BlindModel> BlindModels { get; set; }
        public DbSet<BlindBottomBar> BlindBottomBars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BlindProfile>().ToTable("BlindProfile");
            modelBuilder.Entity<BusinessClient>().ToTable("BusinessClient");
            modelBuilder.Entity<BlindRailing>().ToTable("BlindRailing");
            modelBuilder.Entity<BlindRod>().ToTable("BlindRod");
            modelBuilder.Entity<BlindStack>().ToTable("BlindStack");
            modelBuilder.Entity<BlindModel>().ToTable("BlindModel");
            modelBuilder.Entity<BlindBottomBar>().ToTable("BlindBottomBar");
        }
    }
}