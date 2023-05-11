using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace person_crud.DataAccess.DataModel;

public partial class InterviewPersonContext : DbContext
{
    public InterviewPersonContext()
    {
    }

    public InterviewPersonContext(DbContextOptions<InterviewPersonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFBE5083F4772");

            entity.ToTable("Person");

            entity.Property(e => e.Age)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
