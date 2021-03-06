﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vinmonopolet.Models;

namespace Vinmonopolet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WatchedBeer> WatchedBeers { get; set; }

        public DbSet<BeerLocation> BeerLocations { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<UserStorePreference> UserStorePreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BeerLocation>().HasKey(x => new {x.StoreId, x.WatchedBeerId});
            builder.Entity<BeerLocation>().HasIndex(x => x.AnnouncedDate);
            builder.Entity<BeerLocation>().HasIndex(x => x.StockStatus);
            builder.Entity<WatchedBeer>().HasIndex(x => x.Name);
            builder.Entity<WatchedBeer>().HasIndex(x => x.BeerCategory);
            base.OnModelCreating(builder);
        }
    }
}
