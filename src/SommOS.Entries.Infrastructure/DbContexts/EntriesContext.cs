using Microsoft.EntityFrameworkCore;
using SommOS.Entries.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SommOS.Entries.Infrastructure.DbContexts
{
    public class EntriesContext : DbContext
    {
        public EntriesContext(DbContextOptions<EntriesContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<EntryEntity> Entries { get; set; }
        public DbSet<VarietalEntity> Varietals { get; set; }
        public DbSet<EntryLabelEntity> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VarietalEntity>()
                .HasOne(v => v.Entry)
                .WithMany(v => v.Varietals);

            builder.Entity<EntryEntity>()
                .HasOne(e => e.WineLabel)
                .WithOne(w => w.Entry);
        }
    }
}
