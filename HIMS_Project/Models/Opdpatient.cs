using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdpatients")]
public partial class Opdpatient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("patientid")]
    public int Patientid { get; set; }

    [Column("opddate")]
    public DateOnly? Opddate { get; set; }

    [Column("opdtime")]
    public TimeOnly? Opdtime { get; set; }

    [Column("height")]
    public double? Height { get; set; }

    [Column("weight")]
    public double? Weight { get; set; }

    [Column("doctorid")]
    public int Doctorid { get; set; }

    [Column("remark")]
    [StringLength(500)]
    public string? Remark { get; set; }

    [Column("createdby")]
    public int Createdby { get; set; }

    [Column("updatedby")]
    public int? Updatedby { get; set; }

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [Column("updatedon", TypeName = "datetime")]
    public DateTime? Updatedon { get; set; }

    [ForeignKey("Doctorid")]
    [InverseProperty("Opdpatients")]
    public virtual Doctor? Doctor { get; set; }

    [InverseProperty("Opd")]
    public virtual ICollection<Opdbill> Opdbills { get; set; } = new List<Opdbill>();

    [ForeignKey("Patientid")]
    [InverseProperty("Opdpatients")]
    public virtual Patient? Patient { get; set; } = null!;
}
