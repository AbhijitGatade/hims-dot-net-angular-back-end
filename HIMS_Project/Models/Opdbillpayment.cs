using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdbillpayments")]
public partial class Opdbillpayment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("billid")]
    public int Billid { get; set; }

    [Column("paymentdate")]
    public DateOnly Paymentdate { get; set; }

    [Column("amount")]
    public double BillAmount { get; set; }


    [Column("paidamount")]
    public double PaidAmount { get; set; }
    

    [Column("pendingamount")]
    public double PendingAmount { get; set; }

    [Column("paymentmodeid")]
    public int Paymentid { get; set; }

    [Column("remark")]
    [StringLength(500)]
    public string? Remark { get; set; }

    [Column("createdby")]
    public int Createdby { get; set; }

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [ForeignKey("Billid")]
    [InverseProperty("Opdbillpayments")]
    public virtual Opdbill? Bill { get; set; } = null!;

    //[ForeignKey("paymentmodeid")]
    //[InverseProperty("Opdbillpayments")]
    //public virtual Paymentmode? Paymentmode { get; set; } = null!;
}
