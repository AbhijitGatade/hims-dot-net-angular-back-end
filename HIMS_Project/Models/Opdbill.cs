using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HIMS_Project.Models;

[Table("opdbills")]
public partial class Opdbill
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("opdid")]
    public int Opdid { get; set; }

    [Column("paymentmodeid")]
    public int Paymentmodeid { get; set; }


    [Column("totalamount")]
    public double Totalamount { get; set; }

    [Column("discountamount")]
    public double? Discountamount { get; set; }

    [Column("billamount")]
    public double Billamount { get; set; }

    [Column("paidamount")]
    public double? Paidamount { get; set; }

    [Column("pendingamount")]
    public int Pendingamount { get; set; }

    

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [Column("createdby")]
    public int Createdby { get; set; }

    [Column("concessionbyid")]
    public int Concessionbyid { get; set; }

    [ForeignKey("Concessionbyid")]
    [InverseProperty("Opdbills")]
    public virtual ConcessionBy? Concessionby { get; set; }

    [ForeignKey("Opdid")]
    [InverseProperty("Opdbills")]
    public virtual Opdpatient? Opd { get; set; }

    //[ForeignKey("paymentmodeid")]
    //[InverseProperty("Opdbills")]
    //public virtual Paymentmode? Paymentmodes { get; set; }

    [InverseProperty("Bill")]
    public virtual ICollection<Opdbillpayment> Opdbillpayments { get; set; } = new List<Opdbillpayment>();

    [InverseProperty("Bill")]
    public virtual ICollection<Opdbillservice> Opdbillservices { get; set; } = new List<Opdbillservice>();
}
