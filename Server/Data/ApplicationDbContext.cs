using Workings.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workings.Shared;

namespace Workings.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions
        ) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<BlindBottomBar> BlindBottomBars { get; set; }
        public DbSet<BlindLining> BlindLinings { get; set; }
        public DbSet<BlindModel> BlindModels { get; set; }
        public DbSet<BlindProfile> BlindProfiles { get; set; }
        public DbSet<BlindRailing> BlindRailings { get; set; }
        public DbSet<BlindRod> BlindRods { get; set; }
        public DbSet<BlindStack> BlindStacks { get; set; }
        public DbSet<BusinessClient> BusinessClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BlindBottomBar>().ToTable("BlindBottomBar");
            modelBuilder.Entity<BlindLining>().ToTable("BlindLining");
            modelBuilder.Entity<BlindModel>().ToTable("BlindModel");
            modelBuilder.Entity<BlindProfile>().ToTable("BlindProfile");
            modelBuilder.Entity<BlindRailing>().ToTable("BlindRailing");
            modelBuilder.Entity<BlindRod>().ToTable("BlindRod");
            modelBuilder.Entity<BlindStack>().ToTable("BlindStack");
            modelBuilder.Entity<BusinessClient>().ToTable("BusinessClient");
        }
    }
}