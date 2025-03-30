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
    public int? Id { get; set; }

    [Column("patientid")]
    public int? Patientid { get; set; }

    [Column("companyid")]
    public int? Companyid { get; set; }

    [Column("admissiondate")]
    public DateOnly Admissiondate { get; set; }

    [Column("admissiontime")]
    public string? Admissiontime { get; set; }

    [Column("doctorid")]
    public int? Doctorid { get; set; }

    [Column("refdoctorid")]
    public int Refdoctorid { get; set; }

    [Column("dischargedate")]
    public DateOnly? Dischargedate { get; set; }

    [Column("dischargetime")]
    public string? Dischargetime { get; set; }

    [Column("dischargedas")]
    [StringLength(50)]
    public string? Dischargedas { get; set; }

    [Column("roomid")]
    public int? Roomid { get; set; }

    [Column("bedid")]
    public int? Bedid { get; set; }
    [Column("remark")]
    public string? Remark { get; set; }

    [Column("totalamount", TypeName = "float")]
    public float? Totalamount { get; set; }

    [Column("discountamount", TypeName = "float")]
    public float? Discountamount { get; set; }

    [Column("billamount", TypeName = "float")]
    public float? Billamount { get; set; }

    [Column("paidamount", TypeName = "float")]
    public float? Paidamount { get; set; }

    [Column("concessionbyid")]
    public int? Concessionbyid { get; set; }

    [ForeignKey("Bedid")]
    [InverseProperty("Ipdpatients")]
    public virtual Bed? Bed { get; set; }

    [Column("createdby")]
    public int? Createdby { get; set; }
    
    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }


    [ForeignKey("Concessionbyid")]
    [InverseProperty("Ipdpatients")]
    public virtual ConcessionBy? Concessionby { get; set; }

    [ForeignKey("Doctorid")]
    [InverseProperty("Ipdpatients")]
    public virtual Doctor? Doctor { get; set; } = null!;

    [ForeignKey("Refdoctorid")]
    [InverseProperty("RefDoctorIpdpatients")]
    public virtual Doctor? RefDoctor { get; set; }

    [InverseProperty("Ipd")]
    public virtual ICollection<Ipdbillpayment> Ipdbillpayments { get; set; } = new List<Ipdbillpayment>();

    [ForeignKey("Patientid")]
    [InverseProperty("Ipdpatients")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey("Roomid")]
    [InverseProperty("Ipdpatients")]
    public virtual Room? Room { get; set; }

    [ForeignKey("Companyid")]
    [InverseProperty("Ipdpatients")]
    public virtual Company? Company { get; set; }
}
