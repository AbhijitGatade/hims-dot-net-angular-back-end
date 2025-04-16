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

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Ipdpatient> Ipdpatients { get; set; }

    public virtual DbSet<Ipdservice> Ipdservices { get; set; }

    public virtual DbSet<Ipdservicecategory> Ipdservicecategories { get; set; }

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




    public virtual DbSet<OpdCompanyServiceRate> OpdCompanyServiceRates { get; set; }    
    public virtual DbSet<IpdCompanyServiceRate> IpdCompanyServiceRates { get; set; }
    public virtual DbSet<DischargeSpecialInstruction> DischargeSpecialInstruction { get; set; }
    public virtual DbSet<DischargeDiet> DischargeDiets { get; set; }
    public virtual DbSet<DischargeEmergency> DischargeEmergency { get; set; }
    public virtual DbSet<DischargeExercise> DischargeExercises { get; set; }

public DbSet<HIMS_Project.Models.IpdBill> IpdBill { get; set; } = default!;
    public DbSet<DischargeSummaries> DischargeSummaries { get; set; }
}