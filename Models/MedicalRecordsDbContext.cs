using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAppDBF.Models;

public partial class MedicalRecordsDbContext : DbContext
{
    public MedicalRecordsDbContext()
    {
    }

    public MedicalRecordsDbContext(DbContextOptions<MedicalRecordsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MedicalChart> MedicalCharts { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=desktop-ab199u8;Initial Catalog=MedicalRecordsDB;User ID=Tapash;Password=Db123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalChart>(entity =>
        {
            entity.HasKey(e => e.ChartId).HasName("PK__MedicalC__E7B41C4FBDB575BF");

            entity.Property(e => e.ChartId).HasColumnName("ChartID");
            entity.Property(e => e.ChartType).HasMaxLength(20);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalCharts)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalCh__Patie__3D5E1FD2");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC34648959976");

            entity.HasIndex(e => e.Mrn, "UQ__Patients__C790FDB4AB42EB00").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Mrn)
                .HasMaxLength(20)
                .HasColumnName("MRN");
            entity.Property(e => e.PatientName)
                .HasMaxLength(201)
                .HasComputedColumnSql("(([FirstName]+' ')+[LastName])", false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
