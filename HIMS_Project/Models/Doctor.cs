using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("doctors")]
public partial class Doctor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("dtype")]
    [StringLength(100)]
    public string Dtype { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("mobileno")]
    [StringLength(20)]
    public string? Mobileno { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("qualification")]
    [StringLength(50)]
    public string? Qualification { get; set; }

    [Column("medical_reg_no")]
    public int MedicalRegNo { get; set; }

    [Column("bankname")]
    [StringLength(100)]
    public string Bankname { get; set; } = null!;

    [Column("accountno")]
    [StringLength(15)]
    public string Accountno { get; set; } = null!;

    [Column("ifsccode")]
    [StringLength(12)]
    public string Ifsccode { get; set; } = null!;

    [InverseProperty("Doctor")]
    public virtual ICollection<Ipdpatient>? Ipdpatients { get; set; } = new List<Ipdpatient>();

    [InverseProperty("Doctor")]
    public virtual ICollection<Opdpatient>? Opdpatients { get; set; } = new List<Opdpatient>();

    [InverseProperty("RefDoctor")]
    public virtual ICollection<Opdpatient>? RefDoctorOpdpatients { get; set; } = new List<Opdpatient>();

    [InverseProperty("RefDoctor")]
    public virtual ICollection<Ipdpatient>? RefDoctorIpdpatients { get; set; } = new List<Ipdpatient>();

    [InverseProperty("Doctor")]
    public virtual ICollection<OpdCompanyServiceRate>? OpdCompanyServiceRates { get; set; } = new List<OpdCompanyServiceRate>();


    //[InverseProperty("Doctor")]
    //public virtual ICollection<Opdbillservice>? Opdbillservices { get; set; }= new List<Opdbillservice>();
}
