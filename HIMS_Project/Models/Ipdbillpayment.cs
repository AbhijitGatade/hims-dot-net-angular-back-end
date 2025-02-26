using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("ipdbillpayments")]
public partial class Ipdbillpayment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ipdid")]
    public int? Ipdid { get; set; }

    [Column("paymentdate", TypeName = "datetime")]
    public DateTime? Paymentdate { get; set; }

    [Column("amount", TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [Column("paymentmethodid")]
    public int Paymentmethodid { get; set; }

    [Column("remark")]
    [StringLength(255)]
    public string? Remark { get; set; }

    [Column("createdby")]
    public int Createdby { get; set; }

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [ForeignKey("Ipdid")]
    [InverseProperty("Ipdbillpayments")]
    public virtual Ipdpatient? Ipd { get; set; }

    [ForeignKey("Paymentmethodid")]
    [InverseProperty("Ipdbillpayments")]
    public virtual Paymentmode? Paymentmethod { get; set; } = null!;
}
