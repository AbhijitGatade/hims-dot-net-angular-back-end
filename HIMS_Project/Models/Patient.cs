using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("patients")]
[Index("AadhaarNo", Name = "UQ__patients__5A86BC8FF0BECAC6", IsUnique = true)]
[Index("MobileNo", Name = "UQ__patients__D7B19EFA4F6551E1", IsUnique = true)]
[Index("Uidno", Name = "UQ__patients__F12A885D99608CDA", IsUnique = true)]
public partial class Patient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("prefix")]

    public string Prefix { get; set; } = null!;


    [Column("name")]
    [StringLength(100)]

    public string? Name { get; set; } = null!;

    [Column("uidno")]
    [StringLength(50)]
    public string? Uidno { get; set; } = null!;

    [Column("birthdate")]
    public DateOnly? Birthdate { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("gender")]
    [StringLength(10)]
    public string? Gender { get; set; } = null!;

    [Column("blood_group")]
    [StringLength(10)]
    public string? BloodGroup { get; set; }

    [Column("address")]
    public string address { get; set; } 

    [Column("townid")]
    public int townid { get; set; } 

    [Column("mobile_no")]
    //[StringLength(15)]
    public string? MobileNo { get; set; } = null!;

    [Column("alt_mobile_no")]
    [StringLength(15)]
    public string? AltMobileNo { get; set; }

    [Column("marital_status")]
    [StringLength(20)]
    public string? MaritalStatus { get; set; }

    [Column("occupation")]
    [StringLength(100)]
    public string? Occupation { get; set; }

    [Column("aadhaar_no")]
    [StringLength(20)]
    public string? AadhaarNo { get; set; }

    [Column("createdby")]
    public int? Createdby { get; set; }

    [Column("updatedby")]
    public int? Updatedby { get; set; }

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [Column("updatedon", TypeName = "datetime")]
    public DateTime? Updatedon { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Ipdpatient> Ipdpatients { get; set; } = new List<Ipdpatient>();

    [InverseProperty("Patient")]
    public virtual ICollection<Opdpatient> Opdpatients { get; set; } = new List<Opdpatient>();
}
