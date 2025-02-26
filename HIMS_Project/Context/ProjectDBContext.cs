using System;
using System.Collections.Generic;
using HIMS_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Context;

public partial class ProjectDBContext : DbContext
{
  

    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<ConcessionBy> ConcessionBies { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<HInformation> HInformations { get; set; }

    public virtual DbSet<Ipdbillpayment> Ipdbillpayments { get; set; }

    public virtual DbSet<Ipdcompany> Ipdcompanies { get; set; }

    public virtual DbSet<Ipdpatient> Ipdpatients { get; set; }

    public virtual DbSet<Ipdservice> Ipdservices { get; set; }

    public virtual DbSet<Ipdservicecategory> Ipdservicecategories { get; set; }

    public virtual DbSet<Ipdservicecompanyrate> Ipdservicecompanyrates { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Opdbill> Opdbills { get; set; }

    public virtual DbSet<Opdbillpayment> Opdbillpayments { get; set; }

    public virtual DbSet<Opdbillservice> Opdbillservices { get; set; }

    public virtual DbSet<Opdpatient> Opdpatients { get; set; }

    public virtual DbSet<Opdservice> Opdservices { get; set; }

    public virtual DbSet<Opdservicecategory> Opdservicecategories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Paymentmode> Paymentmodes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleMenu> RoleMenus { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R04LOKR\\SQLEXPRESS;Initial Catalog=HIMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Bed>(entity =>
//        {
//            entity.HasOne(d => d.Room).WithMany(p => p.Beds)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_beds_rooms");
//        });

//        modelBuilder.Entity<Ipdbillpayment>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdbillp__3213E83F5FB688C3");

//            entity.HasOne(d => d.Ipd).WithMany(p => p.Ipdbillpayments).HasConstraintName("FK_ipdbillpayments_ipdpatients");

//            entity.HasOne(d => d.Paymentmethod).WithMany(p => p.Ipdbillpayments)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ipdbillpayments_paymentmodes");
//        });

//        modelBuilder.Entity<Ipdcompany>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdcompa__3213E83F894D7698");
//        });

//        modelBuilder.Entity<Ipdpatient>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdpatie__3213E83F1AC9B635");

//            entity.HasOne(d => d.Bed).WithMany(p => p.Ipdpatients).HasConstraintName("FK_ipdpatients_beds");

//            entity.HasOne(d => d.Concessionby).WithMany(p => p.Ipdpatients).HasConstraintName("FK_ipdpatients_concession_by");

//            entity.HasOne(d => d.Doctor).WithMany(p => p.Ipdpatients)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ipdpatients_doctors");

//            entity.HasOne(d => d.Patient).WithMany(p => p.Ipdpatients).HasConstraintName("FK_ipdpatients_patients");

//            entity.HasOne(d => d.Room).WithMany(p => p.Ipdpatients).HasConstraintName("FK_ipdpatients_rooms");
//        });

//        modelBuilder.Entity<Ipdservice>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdservi__3213E83FBE95D5EF");

//            entity.HasOne(d => d.Ipdservicecategory).WithMany(p => p.Ipdservices).HasConstraintName("FK_ipdservices_ipdservicecategories");
//        });

//        modelBuilder.Entity<Ipdservicecategory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdservi__3213E83F50881773");
//        });

//        modelBuilder.Entity<Ipdservicecompanyrate>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ipdservi__3213E83F2755F9C6");

//            entity.HasOne(d => d.Company).WithMany(p => p.Ipdservicecompanyrates).HasConstraintName("FK_ipdservicecompanyrates_ipdcompanies");

//            entity.HasOne(d => d.Ipdservice).WithMany(p => p.Ipdservicecompanyrates).HasConstraintName("FK_ipdservicecompanyrates_ipdservices");
//        });

//        modelBuilder.Entity<Opdbill>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdbills__3213E83FD2DFE7DF");

//            entity.HasOne(d => d.Concessionby).WithMany(p => p.Opdbills).HasConstraintName("FK_opdbills_concession_by");

//            entity.HasOne(d => d.Opd).WithMany(p => p.Opdbills)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdbills_opdpatients");
//        });

//        modelBuilder.Entity<Opdbillpayment>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdbillp__3213E83FDC3DEFE6");

//            entity.HasOne(d => d.Bill).WithMany(p => p.Opdbillpayments)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdbillpayments_opdbills");

//            entity.HasOne(d => d.Paymentmode).WithMany(p => p.Opdbillpayments)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdbillpayments_paymentmodes");
//        });

//        modelBuilder.Entity<Opdbillservice>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdbills__3213E83F0ED8ABD1");

//            entity.HasOne(d => d.Bill).WithMany(p => p.Opdbillservices)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdbillservices_opdbills");

//            entity.HasOne(d => d.Opdservice).WithMany(p => p.Opdbillservices)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdbillservices_opdservices");
//        });

//        modelBuilder.Entity<Opdpatient>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdpatie__3213E83FCDE91C72");

//            entity.HasOne(d => d.Doctor).WithMany(p => p.Opdpatients).HasConstraintName("FK_opdpatients_doctors");

//            entity.HasOne(d => d.Patient).WithMany(p => p.Opdpatients)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_opdpatients_patients");
//        });

//        modelBuilder.Entity<Opdservice>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdservi__3213E83F5CEA60ED");

//            entity.HasOne(d => d.Opdservicecategory).WithMany(p => p.Opdservices).HasConstraintName("FK_opdservices_opdservicecategories");
//        });

//        modelBuilder.Entity<Opdservicecategory>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__opdservi__3213E83FC60CCEBD");
//        });

//        modelBuilder.Entity<Patient>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__patients__3213E83F197A0E6A");
//        });

//        modelBuilder.Entity<Paymentmode>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__paymentm__3213E83FB9BB7469");
//        });

//        modelBuilder.Entity<RoleMenu>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_rolemenus");

//            entity.HasOne(d => d.Menu).WithMany(p => p.RoleMenus)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_role_menus_menus");

//            entity.HasOne(d => d.Role).WithMany(p => p.RoleMenus)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_role_menus_roles");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasOne(d => d.Role).WithMany(p => p.Users)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_users_roles");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
