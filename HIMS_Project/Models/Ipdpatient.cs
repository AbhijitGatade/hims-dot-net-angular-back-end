using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdpatients")]
public partial class Ipdpatient
{
    [Key]
    [Column("id")]
    public int? id { get; set; }

    [Column("patientid")]
    public int? Patientid { get; set; }

    [Column("admissiondate")]
    public DateOnly? Admissiondate { get; set; }

    [Column("admissiontime")]
    public TimeOnly? Admissiontime { get; set; }

    [Column("doctorid")]
    public int? Doctorid { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [Column("dischargedate")]
    public DateOnly? Dischargedate { get; set; }

    [Column("dischargetime")]
    public TimeOnly? Dischargetime { get; set; }

    [Column("dischargedas")]
    [StringLength(50)]
    public string? Dischargedas { get; set; }

    [Column("roomid")]
    public int? Roomid { get; set; }

    [Column("bedid")]
    public int? Bedid { get; set; }

    [Column("totalamount", TypeName = "decimal(10, 2)")]
    public decimal? Totalamount { get; set; }

    [Column("discountamount", TypeName = "decimal(10, 2)")]
    public decimal? Discountamount { get; set; }

    [Column("billamount", TypeName = "decimal(10, 2)")]
    public decimal? Billamount { get; set; }

    [Column("paidamount", TypeName = "decimal(10, 2)")]
    public decimal? Paidamount { get; set; }

    [Column("concessionbyid")]
    public int? Concessionbyid { get; set; }

    [ForeignKey("Bedid")]
    [InverseProperty("Ipdpatients")]
    public virtual Bed? Bed { get; set; }

    [ForeignKey("Concessionbyid")]
    [InverseProperty("Ipdpatients")]
    public virtual ConcessionBy? Concessionby { get; set; }

    [ForeignKey("Doctorid")]
    [InverseProperty("Ipdpatients")]
    public virtual Doctor? Doctor { get; set; } = null!;

    [InverseProperty("Ipd")]
    public virtual ICollection<Ipdbillpayment> Ipdbillpayments { get; set; } = new List<Ipdbillpayment>();

    [ForeignKey("Patientid")]
    [InverseProperty("Ipdpatients")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey("Roomid")]
    [InverseProperty("Ipdpatients")]
    public virtual Room? Room { get; set; }
}
